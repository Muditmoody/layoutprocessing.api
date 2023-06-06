using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PWCLayoutProcessingWebApp.Data;
using PWCLayoutProcessingWebApp.Models.ETL;
using PWCLayoutProcessingWebApp.BusinessLogic;
using Extract = PWCLayoutProcessingWebApp.Models.Extract;

namespace PWCLayoutProcessingWebApp.Controllers.ETL
{
    /// <summary>
    /// The layout task controller.
    /// </summary>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutTaskController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="databaseProvider">The database provider.</param>
        /// <param name="queryBuilder">The query builder.</param>
        /// <param name="dbContext">The db context.</param>
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

        /// <summary>
        /// Gets the layout tasks.
        /// </summary>
        /// <param name="excludePlanning">If true, exclude planning.</param>
        /// <returns>A list of Extract.ExtractLayoutProcessingTask.</returns>
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

        /// <summary>
        /// Gets the layout type.
        /// </summary>
        /// <param name="notificationRef">The notification ref.</param>
        /// <param name="excludePlanning">If true, exclude planning.</param>
        /// <returns>A list of Extract.ExtractLayoutProcessingTask.</returns>
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

            result = result.Where(i => i.TaskCode.TaskCodeText != "DELETED, USE DEXPORTC-0010 INSTEAD").ToList();
            return result.Select(Extract.ExtractLayoutProcessingTask.Map);
        }
    }
}