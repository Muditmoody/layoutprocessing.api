using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PWCLayoutProcessingWebApp.Data;
using PWCLayoutProcessingWebApp.Models.ETL;
using PWCLayoutProcessingWebApp.BusinessLogic;
using Extract = PWCLayoutProcessingWebApp.Models.Extract;

namespace PWCLayoutProcessingWebApp.Controllers.ETL
{
    [ApiController]
    [Route("api/etl/[controller]")]
    public class LayoutTaskController : ControllerBase
    {
        private readonly ILogger<LayoutTaskController> _logger;
        private readonly IConfiguration _configuration;
        private readonly DatabaseProvider _databaseProvider;
        private readonly QueryBuilder _queryBuilder;
        private readonly LayoutProcessingDbContext _dbContext;

        private readonly bool _useQuery;

        public LayoutTaskController(ILogger<LayoutTaskController> logger, IConfiguration configuration,
            DatabaseProvider databaseProvider, QueryBuilder queryBuilder,
            LayoutProcessingDbContext dbContext)
        {
            _logger = logger;
            _configuration = configuration;
            _databaseProvider = databaseProvider;
            _queryBuilder = queryBuilder;
            _dbContext = dbContext;
            var section = _configuration.GetSection("FeatureFlags");
            if (section!.Exists() && section.GetChildren().Any(item => item.Key == "UseQuery"))
            {
                _useQuery = _configuration.GetValue<bool>("FeatureFlags:UseQuery");
            }
        }

        [HttpGet("GetLayoutTasks")]
        public IEnumerable<Extract.ExtractLayoutProcessingTask> GetLayoutTasks(bool excludePlanning = false)
        {
            _logger.LogDebug("Get Layout Tasks  info");

            var planningTaskCodes = _dbContext.PlanningTaskCodes
                                              .Include(e => e.TaskCode)
                                              .ToList();

            var result = default(List<LayoutProcessingTask>);
            var inactiveItems = _dbContext.InactiveItemConfigs.ToList();

            var removeItemWhenAnyInactive = inactiveItems.Where(e => e.IgnoreInactiveItem).Select(e => new { e.NotificationCode, e.ItemNumber }).ToList();
            var removeTaskWhenAnyInactive = inactiveItems.Where(e => e.IgnoreInactiveTask).Select(e => new { e.NotificationCode, e.ItemNumber }).ToList();



            result = _dbContext.LayoutProcessingTasks
                               .Include(e => e.TaskCode)
                               .Include(e => e.Layout).ThenInclude(e => e.CauseCode)
                               .Include(e => e.Layout).ThenInclude(e => e.DamageCode)
                               .Include(e => e.Layout).ThenInclude(e => e.EngineProgram).ThenInclude(e => e.CodingCode)
                               .Include(e => e.Material)
                               .Include(e => e.SupplierVendor)
                               .Include(e => e.TaskOwner)
                               .Include(e => e.TaskStatus)
                               .ToList();

            result = !excludePlanning ? result : result.Where(i => !planningTaskCodes.Select(t => t.TaskCodeId).Contains(i.TaskCodeId)).ToList();

            var groups = result.GroupBy(e => new { e.Layout.EngineProgram.NotificationCode, e.Layout.ItemNumber }).ToList();

            foreach (var g in groups)
            {
                if (g.Any(i => i.TaskCode.TaskCodeName == "INAC"))
                {
                    var toRemove = removeItemWhenAnyInactive.Any(k => k.NotificationCode == g.Key.NotificationCode && g.Key.ItemNumber == k.ItemNumber);
                    if (toRemove)
                    {
                        g.ToList().ForEach(i => result.Remove(i));
                    }

                    toRemove = removeTaskWhenAnyInactive.Any(k => k.NotificationCode == g.Key.NotificationCode && g.Key.ItemNumber == k.ItemNumber);
                    if (toRemove)
                    {
                        g.Where(i => i.TaskCode.TaskCodeName == "INAC").ToList().ForEach(i => result.Remove(i));
                    }

                    g.Where(i => i.TaskCode.TaskCodeName == "INAC").ToList().ForEach(i =>
                    {
                        if (result.Contains(i))
                        {
                            result.Remove(i);
                        }
                    });
                }
            }

            result = result.Where(i => i.TaskCode.TaskCodeText != "DELETED, USE DEXPORTC-0010 INSTEAD").ToList();

            return result.Select(Extract.ExtractLayoutProcessingTask.Map);
        }

        [HttpGet("GetLayoutTypeByNotification")]
        public IEnumerable<Extract.ExtractLayoutProcessingTask> GetLayoutType([FromQuery] IEnumerable<string> notificationRef, bool excludePlanning = false)
        {
            _logger.LogDebug("Get Layout Tasks info");

            var planningTaskCodes = _dbContext.PlanningTaskCodes
                                              .Include(e => e.TaskCode)
                                              .ToList();

            var inactiveItems = _dbContext.InactiveItemConfigs.ToList();

            var removeItemWhenAnyInactive = inactiveItems.Where(e => e.IgnoreInactiveItem).Select(e => new { e.NotificationCode, e.ItemNumber }).ToList();
            var removeTaskWhenAnyInactive = inactiveItems.Where(e => e.IgnoreInactiveTask).Select(e => new { e.NotificationCode, e.ItemNumber }).ToList();


            var result = default(List<LayoutProcessingTask>);

            result = _dbContext.LayoutProcessingTasks
                               .Include(e => e.Layout).ThenInclude(e => e.CauseCode)
                               .Include(e => e.Layout).ThenInclude(e => e.DamageCode)
                               .Include(e => e.Layout).ThenInclude(e => e.EngineProgram).ThenInclude(e => e.CodingCode)
                               .Include(e => e.TaskCode)
                               .Include(e => e.TaskCode).ThenInclude(e => e.GroupCode)
                               .Include(e => e.Layout)
                               .Include(e => e.Material)
                               .Include(e => e.SupplierVendor)
                               .Include(e => e.TaskOwner)
                               .Include(e => e.TaskStatus)
                               .Where(p => notificationRef.Contains(p.Layout == null ?
                                                default : p.Layout.EngineProgram == null
                                                ? default : p.Layout.EngineProgram.NotificationCode))
                               .ToList();

            result = !excludePlanning ? result : result.Where(i => !planningTaskCodes.Select(t => t.TaskCodeId).Contains(i.TaskCodeId)).ToList();

            var groups = result.GroupBy(e => new { e.Layout.EngineProgram.NotificationCode, e.Layout.ItemNumber }).ToList();

            foreach (var g in groups)
            {
                if (g.Any(i => i.TaskCode.TaskCodeName == "INAC"))
                {
                    var toRemove = removeItemWhenAnyInactive.Any(k => k.NotificationCode == g.Key.NotificationCode && g.Key.ItemNumber == k.ItemNumber);
                    if (toRemove)
                    {
                        g.ToList().ForEach(i => result.Remove(i));
                    }

                    toRemove = removeTaskWhenAnyInactive.Any(k => k.NotificationCode == g.Key.NotificationCode && g.Key.ItemNumber == k.ItemNumber);
                    if (toRemove)
                    {
                        g.Where(i => i.TaskCode.TaskCodeName == "INAC").ToList().ForEach(i => result.Remove(i));
                    }

                    g.Where(i => i.TaskCode.TaskCodeName == "INAC").ToList().ForEach(i =>
                    {
                        if (result.Contains(i))
                        {
                            result.Remove(i);
                        }
                    });
                }
            }


            //result = result.Where(e => !(removeItemWhenAnyInactive.Any(i => i.NotificationCode == e.Layout.EngineProgram.NotificationCode
            //                                                                      && i.ItemNumber == e.Layout.ItemNumber)
            //                                      ));

            //result = result.Where(e => !(removeTaskWhenAnyInactive.Any(i => i.NotificationCode == e.Layout.EngineProgram.NotificationCode
            //                                                                      && i.ItemNumber == e.Layout.ItemNumber)
            //                                      && e.TaskCode.TaskCodeName == "INAC"));

            result = result.Where(i => i.TaskCode.TaskCodeText != "DELETED, USE DEXPORTC-0010 INSTEAD").ToList();
            return result.Select(Extract.ExtractLayoutProcessingTask.Map);
        }
    }
}