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
    [ApiController]
    [Route("api/etl/[controller]")]
    public class CodeGroupController : ControllerBase
    {
        private readonly ILogger<CodeGroupController> _logger;
        private readonly IConfiguration _configuration;
        private readonly DatabaseProvider _databaseProvider;
        private readonly QueryBuilder _queryBuilder;
        private readonly LayoutProcessingDbContext _dbContext;

        private readonly bool _useQuery;

        public CodeGroupController(ILogger<CodeGroupController> logger, IConfiguration configuration,
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

        [HttpGet("GetGroupCodes")]
        public IEnumerable<Extract.ExtractCodeGroup> GetGroupCodes()
        {
            _logger.LogDebug("Get Group Code info");
            var result = default(IEnumerable<CodeGroup>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("GroupCode.sql");
                result = _databaseProvider.ExecuteQuery(sql, CodeGroup.Map);
            }
            else
            {
                result = _dbContext.GroupCodes.ToList();
            }

            return result?.Select(Extract.ExtractCodeGroup.Map);
        }

        [HttpGet("GetCauseCodeByName")]
        public IEnumerable<Extract.ExtractCodeGroup> GetGroupCodes([FromQuery] IEnumerable<string> name)
        {
            _logger.LogDebug("Get Group Code  info");

            var result = default(IEnumerable<CodeGroup>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("GroupCode.sql");
                result = _databaseProvider.ExecuteQuery(sql, CodeGroup.Map)
                                          .Where(p => name.Contains(p.CodeGroupName))
                                          .ToList();
            }
            else
            {
                result = _dbContext.GroupCodes
                                   .Where(p => name.Contains(p.CodeGroupName))
                                   .ToList();
            }

            return result?.Select(Extract.ExtractCodeGroup.Map);
        }

        [HttpPost("AddCodeGroup")]
        public ActionResult AddCodeGroup(IEnumerable<Import.ImportCodeGroup> codeGroups)
        {
            Func<CodeGroup, Import.ImportCodeGroup, bool> finder = (existingItem, importItem) =>
            {
                return existingItem.CodeGroupName == importItem.CodeGroupName;
            };

            Func<Import.ImportCodeGroup, CodeGroup, CodeGroup> transformer = (importItem, extistingItem) =>
            {
                if (extistingItem is null)
                {
                    return new CodeGroup
                    {
                        CodeGroupId = 0,
                        CodeGroupName = importItem.CodeGroupName,
                        CodeGroupText = importItem.CodeGroupText,
                    };
                }
                else
                {
                    return new CodeGroup
                    {
                        CodeGroupId = extistingItem.CodeGroupId,
                        CodeGroupName = importItem.CodeGroupName,
                        CodeGroupText = importItem.CodeGroupText,
                    };
                }
            };

            var result = EntityUtil.AddEntity(_dbContext, _dbContext.GroupCodes, codeGroups, finder, transformer, true);

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