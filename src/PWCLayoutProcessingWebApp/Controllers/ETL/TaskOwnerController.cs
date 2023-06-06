using System.Data;
using Microsoft.AspNetCore.Mvc;
using PWCLayoutProcessingWebApp.Data;
using PWCLayoutProcessingWebApp.Models;
using PWCLayoutProcessingWebApp.Models.ETL;
using PWCLayoutProcessingWebApp.BusinessLogic;
using Import = PWCLayoutProcessingWebApp.Models.Import;
using Extract = PWCLayoutProcessingWebApp.Models.Extract;

namespace PWCLayoutProcessingWebApp.Controllers.ETL
{
    /// <summary>
    /// The task owner controller.
    /// </summary>
    [ApiController]
    [Route("api/etl/[controller]")]
    public class TaskOwnerController : ControllerBase
    {
        private readonly ILogger<TaskOwnerController> _logger;
        private readonly IConfiguration _configuration;
        private readonly DatabaseProvider _databaseProvider;
        private readonly QueryBuilder _queryBuilder;
        private readonly LayoutProcessingDbContext _dbContext;

        private readonly bool _useQuery;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskOwnerController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="databaseProvider">The database provider.</param>
        /// <param name="queryBuilder">The query builder.</param>
        /// <param name="dbContext">The db context.</param>
        public TaskOwnerController(ILogger<TaskOwnerController> logger, IConfiguration configuration,
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
        /// Gets the task owners.
        /// </summary>
        /// <returns>A list of Extract.ExtractTaskOwner.</returns>
        [HttpGet("GetTaskOwners")]
        public IEnumerable<Extract.ExtractTaskOwner> GetTaskOwners()
        {
            _logger.LogDebug("Get Task Owner info");
            var result = default(IEnumerable<TaskOwner>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("TaskOwner.sql");
                result = _databaseProvider.ExecuteQuery(sql, TaskOwner.Map);
            }
            else
            {
                result = _dbContext.TaskOwners.ToList();
            }

            return result?.Select(Extract.ExtractTaskOwner.Map);
        }

        /// <summary>
        /// Gets the task owners by code.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>A list of Extract.ExtractTaskOwner.</returns>
        [HttpGet("GetTaskOwnerByCdode")]
        public IEnumerable<Extract.ExtractTaskOwner> GetTaskOwnersByCode([FromQuery] IEnumerable<string> name)
        {
            _logger.LogDebug("Get Task Owner  info");

            var result = default(IEnumerable<TaskOwner>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("TaskOwner.sql");
                result = _databaseProvider.ExecuteQuery(sql, TaskOwner.Map)
                                          .Where(p => name.Contains(p.TaskOwnerCode))
                                          .ToList();
            }
            else
            {
                result = _dbContext.TaskOwners
                                   .Where(p => name.Contains(p.TaskOwnerCode))
                                   .ToList();
            }

            return result?.Select(Extract.ExtractTaskOwner.Map);
        }

        /// <summary>
        /// Adds the task owners.
        /// </summary>
        /// <param name="owners">The owners.</param>
        /// <returns>An ActionResult.</returns>
        [HttpPost("AddTaskOwner")]
        public ActionResult AddTaskOwners(IEnumerable<Import.ImportTaskOwner> owners)
        {
            Func<TaskOwner, Import.ImportTaskOwner, bool> finder = (existingItem, importItem) =>
            {
                return existingItem.TaskOwnerCode == importItem.TaskOwnerCode;
            };

            Func<Import.ImportTaskOwner, TaskOwner, TaskOwner> transformer = (importItem, extistingItem) =>
            {
                if (extistingItem is null)
                {
                    return new TaskOwner
                    {
                        TaskOwnerId = 0,
                        TaskOwnerCode = importItem.TaskOwnerCode
                    };
                }
                else
                {
                    return new TaskOwner
                    {
                        TaskOwnerId = extistingItem.TaskOwnerId,
                        TaskOwnerCode = importItem.TaskOwnerCode
                    };
                }
            };

            var result = EntityUtil.AddEntity(_dbContext, _dbContext.TaskOwners, owners, finder, transformer, true);

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