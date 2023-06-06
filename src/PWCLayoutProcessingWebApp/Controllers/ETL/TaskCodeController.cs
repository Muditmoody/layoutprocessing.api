using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PWCLayoutProcessingWebApp.Data;
using PWCLayoutProcessingWebApp.Models;
using PWCLayoutProcessingWebApp.Models.ETL;
using PWCLayoutProcessingWebApp.BusinessLogic;
using Import = PWCLayoutProcessingWebApp.Models.Import;
using Extract = PWCLayoutProcessingWebApp.Models.Extract;

namespace PWCLayoutProcessingWebApp.Controllers.ETL
{
    /// <summary>
    /// The task code controller.
    /// </summary>
    [ApiController]
    [Route("api/etl/[controller]")]
    public class TaskCodeController : ControllerBase
    {
        private readonly ILogger<TaskCodeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly DatabaseProvider _databaseProvider;
        private readonly QueryBuilder _queryBuilder;
        private readonly LayoutProcessingDbContext _dbContext;

        private readonly bool _useQuery;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskCodeController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="databaseProvider">The database provider.</param>
        /// <param name="queryBuilder">The query builder.</param>
        /// <param name="dbContext">The db context.</param>
        public TaskCodeController(ILogger<TaskCodeController> logger, IConfiguration configuration,
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
        /// Gets the task codes.
        /// </summary>
        /// <returns>A list of Extract.ExtractTaskCode.</returns>
        [HttpGet("GetTaskCodes")]
        public IEnumerable<Extract.ExtractTaskCode> GetTaskCodes()
        {
            _logger.LogDebug("Get Task Code info");
            var result = default(IEnumerable<TaskCode>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("TaskCode.sql");
                result = _databaseProvider.ExecuteQuery(sql, TaskCode.Map);
            }
            else
            {
                result = _dbContext.TaskCodes
                                   .Include(e => e.GroupCode)
                                   .ToList();
            }

            return result?.Select(Extract.ExtractTaskCode.Map);
        }

        /// <summary>
        /// Gets the task codes.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>A list of Extract.ExtractTaskCode.</returns>
        [HttpGet("GetTaskCodeByName")]
        public IEnumerable<Extract.ExtractTaskCode> GetTaskCodes([FromQuery] IEnumerable<string> name)
        {
            _logger.LogDebug("Get Task Code  info");

            var result = default(IEnumerable<TaskCode>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("TaskCode.sql");
                result = _databaseProvider.ExecuteQuery(sql, TaskCode.Map)
                                          .Where(p => name.Contains(p.TaskCodeName))
                                          .ToList();
            }
            else
            {
                result = _dbContext.TaskCodes
                                   .Include(e => e.GroupCode)
                                   .Where(p => name.Contains(p.TaskCodeName))
                                   .ToList();
            }

            return result?.Select(Extract.ExtractTaskCode.Map);
        }

        /// <summary>
        /// Adds the task code.
        /// </summary>
        /// <param name="taskCodes">The task codes.</param>
        /// <returns>An ActionResult.</returns>
        [HttpPost("AddTaskCode")]
        public ActionResult AddTaskCode(IEnumerable<Import.ImportTaskCode> taskCodes)
        {
            var groupCodes = _dbContext.GroupCodes.ToList();

            bool hasValidGroupCode(Import.ImportTaskCode item)
            {
                return groupCodes.Select(c => c.CodeGroupId).ToList().Contains(item.GroupCodeId)
                      || groupCodes.Select(c => c.CodeGroupName).ToList().Contains(item.GroupCode);
            }

            int getGroupCodeId(string groupCodeName)
            {
                return groupCodes?.Find(c => c.CodeGroupName == groupCodeName)?.CodeGroupId ?? 0;
            }

            CodeGroup getCodeGroup(int groupCodeId)
            {
                return groupCodes.Find(c => c.CodeGroupId == groupCodeId);
            }

            var (toProcess, skippedItem) = taskCodes.PartitionBy(i => hasValidGroupCode(i));

            Func<TaskCode, Import.ImportTaskCode, bool> finder = (existingItem, importItem) =>
            existingItem.TaskCodeName == importItem.TaskCodeName && (existingItem.GroupCode?.CodeGroupName == importItem.GroupCode || existingItem.GroupCodeId == importItem.GroupCodeId);

            Func<Import.ImportTaskCode, TaskCode, TaskCode> transformer = (importItem, extistingItem) =>
            {
                if (extistingItem is null)
                {
                    return new TaskCode
                    {
                        TaskCodeId = 0,
                        TaskCodeName = importItem.TaskCodeName,
                        TaskCodeText = importItem.TaskCodeText,
                        GroupCodeId = importItem.GroupCodeId == 0 ? getGroupCodeId(importItem.GroupCode) : importItem.GroupCodeId,
                        GroupCode = importItem.GroupCodeId == 0 ? getCodeGroup(getGroupCodeId(importItem.GroupCode)) : getCodeGroup(importItem.GroupCodeId)
                    };
                }
                else
                {
                    return new TaskCode
                    {
                        TaskCodeId = extistingItem.TaskCodeId,
                        TaskCodeName = importItem.TaskCodeName,
                        TaskCodeText = importItem.TaskCodeText,
                        GroupCodeId = importItem.GroupCodeId == 0 ? getGroupCodeId(importItem.GroupCode) : importItem.GroupCodeId,
                        GroupCode = importItem.GroupCodeId == 0 ? getCodeGroup(getGroupCodeId(importItem.GroupCode)) : getCodeGroup(importItem.GroupCodeId)
                    };
                }
            };

            var result = EntityUtil.AddEntity(_dbContext, _dbContext.TaskCodes, toProcess, finder, transformer, true);
            if (!skippedItem.Any())
            {
                return result switch
                {
                    Result r when r.GetType().IsAssignableFrom(typeof(Result.Ok<bool>)) => Ok(),
                    Result r when r.GetType().IsAssignableFrom(typeof(Result.Ok<int>)) => Ok(r),
                    Result.Error error => Ok(error),
                    _ => throw new NotImplementedException(),
                };
            }
            else
            {
                return Ok(new Result.Ok<Import.SkippedImport<IEnumerable<Import.ImportTaskCode>>>(new Import.SkippedImport<IEnumerable<Import.ImportTaskCode>>("Skipped values", skippedItem)));
            }
        }
    }
}