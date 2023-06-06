using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PWCLayoutProcessingWebApp.Data;
using PWCLayoutProcessingWebApp.Models;
using PWCLayoutProcessingWebApp.Models.Model;
using PWCLayoutProcessingWebApp.BusinessLogic;
using Import = PWCLayoutProcessingWebApp.Models.Import;
using Extract = PWCLayoutProcessingWebApp.Models.Extract;

namespace PWCLayoutProcessingWebApp.Controllers.Modelling
{
#nullable enable

    /// <summary>
    /// The model data processed controller.
    /// </summary>
    [ApiController]
    [Route("api/model/[controller]")]
    public class ModelDataProcessedController : Controller
    {
        private readonly ILogger<ModelDataProcessedController> _logger;
        private readonly IConfiguration _configuration;
        private readonly DatabaseProvider _databaseProvider;
        private readonly QueryBuilder _queryBuilder;
        private readonly LayoutProcessingDbContext _dbContext;

        private readonly bool _useQuery;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelDataProcessedController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="databaseProvider">The database provider.</param>
        /// <param name="queryBuilder">The query builder.</param>
        /// <param name="dbContext">The db context.</param>
        public ModelDataProcessedController(ILogger<ModelDataProcessedController> logger, IConfiguration configuration,
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

        /// <summary>
        /// Gets the model clean data.
        /// </summary>
        /// <param name="train">If true, train.</param>
        /// <returns>A list of Extract.ExtractCleanModelInput.</returns>
        [HttpGet("GetModelCleanData")]
        public IEnumerable<Extract.ExtractCleanModelInput> GetModelCleanData(bool train)
        {
            _logger.LogDebug("Get Clean Model input data");
            var result = default(IEnumerable<CleanModelInput>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("ModelInputData.sql");
                result = _databaseProvider.ExecuteQuery(sql, CleanModelInput.Map);
            }
            else
            {
                var maxRunDate = _dbContext.CleanModelInputs.Max(r => r.RunDate);
                result = _dbContext.CleanModelInputs.Include(r => r.CodingCode)
                    .Where(e => train ? e.IsTaskCompleted : (!e.IsTaskCompleted && e.CreatedDate.Year >= 2015))
                    .Where(r => r.RunDate == maxRunDate).ToList();
            }

            return result?.Select(Extract.ExtractCleanModelInput.Map);
        }

        /// <summary>
        /// Gets the task duration predictions.
        /// </summary>
        /// <returns>A list of Extract.ExtractTaskDurationPrediction.</returns>
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

        /// <summary>
        /// Saves the clean model input.
        /// </summary>
        /// <param name="modelInputs">The model inputs.</param>
        /// <param name="runDate">The run date.</param>
        /// <param name="deleteExisting">If true, delete existing.</param>
        /// <returns>An ActionResult.</returns>
        [HttpPost("SaveCleanModelInput")]
        public ActionResult SaveCleanModelInput(IEnumerable<Import.ImportCleanModelInput> modelInputs, DateTime runDate, bool deleteExisting)
        {
            runDate = runDate == default ? DateTime.Now : runDate;

            if (deleteExisting)
            {
                var existingRecords = _dbContext.CleanModelInputs.Where(e => e.RunDate == runDate).ToList();

                if (existingRecords.Any())
                {
                    EntityUtil.RemoveEntity(_dbContext, _dbContext.CleanModelInputs, existingRecords);
                }
            }

            Func<CleanModelInput, Import.ImportCleanModelInput, bool> finder = (_, _) => false;

            Func<Import.ImportCleanModelInput, CleanModelInput, CleanModelInput> transformer = (importItem, existingItem) =>
            {
                if (existingItem is null)
                {
                    return new CleanModelInput
                    {
                        Id = 0,
                        Available = importItem.Available,
                        Category = importItem.Category,
                        CategoryId = importItem.CategoryId,
                        CauseCode = importItem.CauseCode,
                        CauseCodeId = importItem.CauseCodeId,
                        CodingCodeId = importItem.CodingCodeId,
                        CompletedDate = importItem.CompletedDate,
                        EngineProgram = importItem.EngineProgram,
                        GeneralCode = importItem.GeneralCode ?? string.Empty,
                        IsTaskCompleted = importItem.IsTaskCompleted || importItem.CompletedDate is not null,
                        IsItemCompleted = importItem.IsItemCompleted,
                        IsTurnback = importItem.IsTurnback,
                        IsLife = importItem.IsLife,
                        IsPlanning = importItem.IsPlanning,
                        CreatedDate = importItem.CreatedDate,
                        DamageCode = importItem.DamageCode,
                        DamageCodeId = importItem.DamageCodeId,
                        GroupCode = importItem.GroupCode,
                        GroupCodeId = importItem.GroupCodeId,
                        ItemNumber = importItem.ItemNumber,
                        LayoutTaskId = importItem.LayoutTaskId,
                        MaterialCode = importItem.MaterialCode,
                        NotificationCode = importItem.NotificationCode,
                        PlannedFinish = importItem.PlannedFinish,
                        PlannedStart = importItem.PlannedStart,
                        RunDate = runDate,
                        SupplierVendorCode = importItem.SupplierVendorCode,
                        SupplierVendorId = importItem.SupplierVendorId,
                        TaskCode = importItem.TaskCode,
                        TaskCodeId = importItem.TaskCodeId,
                        TaskCodeText = importItem.TaskCodeText,
                        TaskNumber = importItem.TaskNumber,
                        TaskOwnerCode = importItem.TaskOwnerCode,
                        TaskOwnerId = importItem.TaskOwnerId,
                        TaskStatusCode = importItem.TaskStatusCode,
                        TaskStatusId = importItem.TaskStatusId,
                        TaskText = importItem.TaskText
                    };
                }
                else
                {
                    return new CleanModelInput
                    {
                        Id = existingItem.Id,
                        Available = existingItem.Available,
                        Category = existingItem.Category,
                        CategoryId = existingItem.CategoryId,
                        CauseCode = existingItem.CauseCode,
                        CauseCodeId = existingItem.CauseCodeId,
                        CodingCodeId = existingItem.CodingCodeId,
                        CompletedDate = existingItem.CompletedDate,
                        EngineProgram = existingItem.EngineProgram,
                        GeneralCode = existingItem.GeneralCode ?? string.Empty,
                        IsTaskCompleted = existingItem.IsTaskCompleted || importItem.CompletedDate is not null,
                        IsItemCompleted = existingItem.IsItemCompleted,
                        IsTurnback = existingItem.IsTurnback,
                        IsLife = existingItem.IsLife,
                        IsPlanning = existingItem.IsPlanning,
                        CreatedDate = existingItem.CreatedDate,
                        DamageCode = existingItem.DamageCode,
                        DamageCodeId = existingItem.DamageCodeId,
                        GroupCode = existingItem.GroupCode,
                        GroupCodeId = existingItem.GroupCodeId,
                        ItemNumber = existingItem.ItemNumber,
                        LayoutTaskId = existingItem.LayoutTaskId,
                        MaterialCode = existingItem.MaterialCode,
                        NotificationCode = existingItem.NotificationCode,
                        PlannedFinish = existingItem.PlannedFinish,
                        PlannedStart = existingItem.PlannedStart,
                        SupplierVendorCode = existingItem.SupplierVendorCode,
                        SupplierVendorId = existingItem.SupplierVendorId,
                        TaskCode = existingItem.TaskCode,
                        TaskCodeId = existingItem.TaskCodeId,
                        TaskCodeText = existingItem.TaskCodeText,
                        TaskNumber = existingItem.TaskNumber,
                        TaskOwnerCode = existingItem.TaskOwnerCode,
                        TaskOwnerId = existingItem.TaskOwnerId,
                        TaskStatusCode = existingItem.TaskStatusCode,
                        TaskStatusId = existingItem.TaskStatusId,
                        TaskText = existingItem.TaskText,
                        RunDate = existingItem.RunDate
                    };
                }
            };

            var result = EntityUtil.AddEntity(_dbContext, _dbContext.CleanModelInputs, modelInputs, finder, transformer, false);

            return result switch
            {
                Result r when r.GetType().IsAssignableFrom(typeof(Result.Ok<bool>)) => Ok(),
                Result r when r.GetType().IsAssignableFrom(typeof(Result.Ok<int>)) => Ok(r),
                Result.Error error => Ok(error),
                _ => throw new NotImplementedException(),
            };
        }

        /// <summary>
        /// Saves the task duration result.
        /// </summary>
        /// <param name="durationPredictions">The duration predictions.</param>
        /// <param name="runDate">The run date.</param>
        /// <param name="deleteExisting">If true, delete existing.</param>
        /// <returns>An ActionResult.</returns>
        [HttpPost("SaveTaskDurationResult")]
        public ActionResult SaveTaskDurationResult(IEnumerable<Import.ImportTaskDurationPrediction> durationPredictions, DateTime runDate, bool deleteExisting)
        {
            runDate = runDate == default ? DateTime.Now : runDate;

            if (deleteExisting)
            {
                var existingRecords = _dbContext.TaskDurationPredictions.Where(e => e.RunDate == runDate).ToList();

                if (existingRecords.Any())
                {
                    EntityUtil.RemoveEntity(_dbContext, _dbContext.TaskDurationPredictions, existingRecords);
                }
            }

            CleanModelInput findModelInput(int inputId)
            {
                return _dbContext.CleanModelInputs.Where(i => i.Id == inputId).FirstOrDefault();
            }

            Func<TaskDurationPrediction, Import.ImportTaskDurationPrediction, bool> finder = (_, _) => false;

            Func<Import.ImportTaskDurationPrediction, TaskDurationPrediction, TaskDurationPrediction> transformer = (importItem, existingItem) =>
            {
                if (existingItem is null)
                {
                    return new TaskDurationPrediction
                    {
                        Id = 0,
                        ModelDataInputId = importItem.ModelDataInputId,
                        ModelDataInput = findModelInput(importItem.ModelDataInputId),
                        PredictionResult = importItem.PredictionResult,
                        RunDate = runDate,
                    };
                }
                else
                {
                    return new TaskDurationPrediction
                    {
                        Id = existingItem.Id,
                        ModelDataInputId = importItem.ModelDataInputId,
                        ModelDataInput = findModelInput(importItem.ModelDataInputId),
                        PredictionResult = importItem.PredictionResult,
                        RunDate = runDate,
                    };
                }
            };

            var result = EntityUtil.AddEntity(_dbContext, _dbContext.TaskDurationPredictions, durationPredictions, finder, transformer, false);

            return result switch
            {
                Result r when r.GetType().IsAssignableFrom(typeof(Result.Ok<bool>)) => Ok(),
                Result r when r.GetType().IsAssignableFrom(typeof(Result.Ok<int>)) => Ok(r),
                Result.Error error => Ok(error),
                _ => throw new NotImplementedException(),
            };
        }
    }
}