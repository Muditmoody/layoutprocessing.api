using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PWCLayoutProcessingWebApp.Data;
using PWCLayoutProcessingWebApp.Models;
using PWCLayoutProcessingWebApp.Models.ETL;
using PWCLayoutProcessingWebApp.Models.Model;
using PWCLayoutProcessingWebApp.BusinessLogic;
using PWCLayoutProcessingWebApp.Models.Reporting;
using Extract = PWCLayoutProcessingWebApp.Models.Extract;

namespace PWCLayoutProcessingWebApp.Controllers.Reporting
{
    [ApiController]
    [Route("api/dashboard/[controller]")]
    public class DashboardController : Controller
    {

        private readonly ILogger<DashboardController> _logger;
        private readonly IConfiguration _configuration;
        private readonly DatabaseProvider _databaseProvider;
        private readonly QueryBuilder _queryBuilder;
        private readonly LayoutProcessingDbContext _dbContext;

        private readonly bool _useQuery;

        public DashboardController(ILogger<DashboardController> logger, IConfiguration configuration,
            DatabaseProvider databaseProvider, QueryBuilder queryBuilder,
            LayoutProcessingDbContext dbContext)
        {
            _logger = logger;
            _configuration = configuration;
            _databaseProvider = databaseProvider;
            _queryBuilder = queryBuilder;
            _dbContext = dbContext;
            var section = _configuration.GetSection("FeatureFlags");
            {
                if (section!.Exists() && section.GetChildren().Any(item => item.Key == "UseQuery"))
                {
                    _useQuery = _configuration.GetValue<bool>("FeatureFlags:UseQuery");
                }
            }
        }

        [HttpGet("GetSequenceSimilarity")]
        public IEnumerable<Extract.ExtractSequenceSimilarity> GetSequenceSimilarity()
        {
            _logger.LogDebug("Get Cause Code info");
            var result = default(List<Extract.ExtractSequenceSimilarity>);

            var maxRunDate = _dbContext.SequenceSimilarities.Max(r => r.RunDate);
            result = _dbContext.SequenceSimilarities.Where(r => r.RunDate == maxRunDate).Select(Extract.ExtractSequenceSimilarity.Map).ToList();


            if (result.Any())
            {
                var layouts = _dbContext.LayoutTypes
                                      .Include(i => i.EngineProgram)
                                      .Select(l => new { Id = l.LayoutTypeId, ItemNumber = l.ItemNumber, NotificationCode = l.EngineProgram.NotificationCode })
                                      .ToDictionary(t => t.Id, t => new { t.ItemNumber, t.NotificationCode });


                var layoutDurations = _dbContext.LayoutProcessingTasks
                                            .AsEnumerable()
                                            .GroupBy(i => i.LayoutId)
                                            .Select(i => new
                                            {
                                                LayoutId = i.Key,
                                                TotalDays = i.Sum(r => getDuration(r.CreatedOn, r.CompletedOn)),
                                                TaskCount = i.Count(),
                                            })
                                            .ToDictionary(t => t.LayoutId, t => new { TotalDays = t.TotalDays, TaskCount = t.TaskCount });

                var planningTaskCodes = _dbContext.PlanningTaskCodes
                                              .Include(e => e.TaskCode)
                                              .ToList();



                var layoutDurationsNonePlanning = _dbContext.LayoutProcessingTasks
                                                .AsEnumerable()
                                                .Where(i => !planningTaskCodes.Select(t => t.TaskCodeId).Contains(i.TaskCodeId))
                                                .GroupBy(i => i.LayoutId)
                                                .Select(i => new
                                                {
                                                    LayoutId = i.Key,
                                                    TotalDays = i.Sum(r => getDuration(r.CreatedOn, r.CompletedOn)),
                                                    TaskCount = i.Count(),
                                                })
                                            .ToDictionary(t => t.LayoutId, t => new { TotalDays = t.TotalDays, TaskCount = t.TaskCount });

                result?.ToList()
                       .ForEach(i =>
                       {
                           var haslayoutRefMap = layouts.ContainsKey(i.LayoutIdRef);
                           var haslayoutTestMap = layouts.ContainsKey(i.LayoutIdTest);

                           if (haslayoutRefMap)
                           {
                               var mapping = layouts.GetValueOrDefault(i.LayoutIdRef);
                               i.ItemNumberRef = mapping.ItemNumber;

                               i.NotificationCode = mapping.NotificationCode;
                           }

                           if (haslayoutTestMap)
                           {
                               var mapping = layouts.GetValueOrDefault(i.LayoutIdTest);
                               i.ItemNumberTest = mapping.ItemNumber;

                               i.NotificationCode = string.IsNullOrWhiteSpace(i.NotificationCode) ? mapping.NotificationCode : i.NotificationCode;
                           }

                           i.TaskSequenceRef = i.TaskSequenceRef.Replace(",", " -> ");
                           i.TaskSequenceTest = i.TaskSequenceTest.Replace(",", " -> ");

                           var hasReflayoutDurationMap = layoutDurations.ContainsKey(i.LayoutIdRef);
                           var hasTestlayoutDurationMap = layoutDurations.ContainsKey(i.LayoutIdTest);

                           if (hasReflayoutDurationMap)
                           {
                               var mapping = layoutDurations.GetValueOrDefault(i.LayoutIdRef);
                               i.RefPastDuration = mapping.TotalDays/ mapping.TaskCount;
                           }
                           if (hasTestlayoutDurationMap)
                           {
                               var mapping = layoutDurations.GetValueOrDefault(i.LayoutIdTest);
                               i.TestTimeElapsed = mapping.TotalDays / mapping.TaskCount;
                           }

                           var hasReflayoutDurationNonePlanningMap = layoutDurationsNonePlanning.ContainsKey(i.LayoutIdRef);
                           var hasTestlayoutDurationNonePlanningMap = layoutDurationsNonePlanning.ContainsKey(i.LayoutIdTest);

                           if (hasReflayoutDurationNonePlanningMap)
                           {
                               var mapping = layoutDurationsNonePlanning.GetValueOrDefault(i.LayoutIdRef);
                               i.RefPastDurationNonePlanning = mapping.TotalDays / mapping.TaskCount;
                           }
                           if (hasTestlayoutDurationNonePlanningMap)
                           {
                               var mapping = layoutDurationsNonePlanning.GetValueOrDefault(i.LayoutIdTest);
                               i.TestTimeElapsedNonePlanning = mapping.TotalDays / mapping.TaskCount;
                           }

                       });
            }

            return result;
        }


        [HttpGet("GetTaskDurationPredictions")]
        public IEnumerable<Extract.ExtractTaskDurationPrediction> GetTaskDurationPredictions()
        {
            _logger.LogDebug("Get model task predictions");
            var result = default(IEnumerable<TaskDurationPrediction>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("DurationPredictions.sql");
                result = _databaseProvider.ExecuteQuery(sql, TaskDurationPrediction.Map);
            }
            else
            {
                var maxRunDate = _dbContext.TaskDurationPredictions.Max(r => r.RunDate);
                result = _dbContext.TaskDurationPredictions.Include(r => r.ModelDataInput)
                                    .Where(r => r.RunDate == maxRunDate)
                                    .ToList();
            }

            return result?.Select(Extract.ExtractTaskDurationPrediction.Map);
        }

        [HttpGet("GetDashboardDescriptiveData")]
        public IEnumerable<Extract.ExtractDescriptiveDashboardData> GetDashboardDescriptiveData()
        {
            _logger.LogDebug("Get Clean Model input data");
            var result = default(List<DescriptiveDashboardData>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("ModelInputData.sql");
                //result = _databaseProvider.ExecuteQuery(sql, DescriptiveDashboardData.Map);
            }
            else
            {
                var enginePrograms = _dbContext.EnginePrograms.ToList();
                var codeGroups = _dbContext.GroupCodes.ToList();

                var maxRunDate = _dbContext.CleanModelInputs.Max(r => r.RunDate);
                result = _dbContext.CleanModelInputs.Include(r => r.CodingCode)
                                    .Where(r => r.RunDate == maxRunDate)
                                    .Select(DescriptiveDashboardData.Map)
                                    .ToList();



                result.ForEach(i => i.Description = (enginePrograms.FirstOrDefault(e => e.NotificationCode == i.Notification).Description));
                result.ForEach(i => i.CodeGroupText = (codeGroups.FirstOrDefault(e => e.CodeGroupName == i.CodeGroup).CodeGroupText));
            }

            return result?.Select(Extract.ExtractDescriptiveDashboardData.Map);
        }


        private static int getDuration(DateTime? createdOn, DateTime? completedOn)
        {
            var start = createdOn ?? DateTime.Today;
            var end = completedOn ?? DateTime.Today;

            var days = (end - start).Days + 1;
            return days <= 0 ? 1 : days;
        }

    }
}
