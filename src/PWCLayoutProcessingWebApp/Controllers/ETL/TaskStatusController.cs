using System.Data;
using Microsoft.AspNetCore.Mvc;
using PWCLayoutProcessingWebApp.Data;
using PWCLayoutProcessingWebApp.Models;
using PWCLayoutProcessingWebApp.BusinessLogic;
using Import = PWCLayoutProcessingWebApp.Models.Import;
using Extract = PWCLayoutProcessingWebApp.Models.Extract;

namespace PWCLayoutProcessingWebApp.Controllers.ETL
{
    /// <summary>
    /// The task status controller.
    /// </summary>
    [ApiController]
    [Route("api/etl/[controller]")]
    public class TaskStatusController : ControllerBase
    {
        private readonly ILogger<TaskStatusController> _logger;
        private readonly IConfiguration _configuration;
        private readonly DatabaseProvider _databaseProvider;
        private readonly QueryBuilder _queryBuilder;
        private readonly LayoutProcessingDbContext _dbContext;

        private readonly bool _useQuery;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskStatusController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="databaseProvider">The database provider.</param>
        /// <param name="queryBuilder">The query builder.</param>
        /// <param name="dbContext">The db context.</param>
        public TaskStatusController(ILogger<TaskStatusController> logger, IConfiguration configuration,
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
        /// Gets the task statuses.
        /// </summary>
        /// <returns>A list of Extract.ExtractTaskStatus.</returns>
        [HttpGet("GetTaskStatuses")]
        public IEnumerable<Extract.ExtractTaskStatus> GetTaskStatuses()
        {
            _logger.LogDebug("Get Task Code info");
            var result = default(IEnumerable<Models.ETL.TaskStatus>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("TaskStatus.sql");
                result = _databaseProvider.ExecuteQuery(sql, Models.ETL.TaskStatus.Map);
            }
            else
            {
                result = _dbContext.TaskStatuses.ToList();
            }

            return result?.Select(Extract.ExtractTaskStatus.Map);
        }

        /// <summary>
        /// Gets the task status by code.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>A list of Extract.ExtractTaskStatus.</returns>
        [HttpGet("GetTaskStatusByCode")]
        public IEnumerable<Extract.ExtractTaskStatus> GetTaskStatusByCode([FromQuery] IEnumerable<string> name)
        {
            _logger.LogDebug("Get Task Code  info");

            var result = default(IEnumerable<Models.ETL.TaskStatus>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("TaskStatus.sql");
                result = _databaseProvider.ExecuteQuery(sql, Models.ETL.TaskStatus.Map)
                                          .Where(p => name.Contains(p.TaskStatusCode))
                                          .ToList();
            }
            else
            {
                result = _dbContext.TaskStatuses
                                   .Where(p => name.Contains(p.TaskStatusCode))
                                   .ToList();
            }

            return result?.Select(Extract.ExtractTaskStatus.Map);
        }

        /// <summary>
        /// Adds the task status.
        /// </summary>
        /// <param name="statuses">The statuses.</param>
        /// <returns>An ActionResult.</returns>
        [HttpPost("AddTaskStatus")]
        public ActionResult AddTaskStatus(IEnumerable<Import.ImportTaskStatus> statuses)
        {
            Func<Models.ETL.TaskStatus, Import.ImportTaskStatus, bool> finder = (existingItem, importItem) => existingItem.TaskStatusCode == importItem.TaskStatusCode;

            Func<Import.ImportTaskStatus, Models.ETL.TaskStatus, Models.ETL.TaskStatus> transformer = (importItem, extistingItem) =>
            {
                if (extistingItem is null)
                {
                    return new Models.ETL.TaskStatus
                    {
                        TaskStatusId = 0,
                        TaskStatusCode = importItem.TaskStatusCode
                    };
                }
                else
                {
                    return new Models.ETL.TaskStatus
                    {
                        TaskStatusId = extistingItem.TaskStatusId,
                        TaskStatusCode = importItem.TaskStatusCode
                    };
                }
            };

            var result = EntityUtil.AddEntity(_dbContext, _dbContext.TaskStatuses, statuses, finder, transformer, true);

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