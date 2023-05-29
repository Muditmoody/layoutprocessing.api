using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PWCLayoutProcessingWebApp.Data;
using PWCLayoutProcessingWebApp.Models;
using PWCLayoutProcessingWebApp.Models.Model;
using PWCLayoutProcessingWebApp.BusinessLogic;
using PWCLayoutProcessingWebApp.Models.Import;
using Import = PWCLayoutProcessingWebApp.Models.Import;
using Extract = PWCLayoutProcessingWebApp.Models.Extract;

namespace PWCLayoutProcessingWebApp.Controllers.Modelling
{
    [ApiController]
    [Route("api/model/[controller]")]
    public class ModelRefDataController : Controller
    {
        private readonly ILogger<ModelRefDataController> _logger;
        private readonly IConfiguration _configuration;
        private readonly DatabaseProvider _databaseProvider;
        private readonly QueryBuilder _queryBuilder;
        private readonly LayoutProcessingDbContext _dbContext;

        private readonly bool _useQuery;

        public ModelRefDataController(ILogger<ModelRefDataController> logger, IConfiguration configuration,
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

        [HttpGet("GetGroupTaskCodeMatchMap")]
        public IEnumerable<Extract.ExtractGroupTaskCodeMatchMap> GetGroupTaskCodeMatchMap()
        {
            _logger.LogDebug("Get Group Task code match map info");
            var result = default(IEnumerable<GroupTaskCodeMatchMap>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("GroupTaskCodeMatchMap.sql");
                result = _databaseProvider.ExecuteQuery(sql, GroupTaskCodeMatchMap.Map);
            }
            else
            {
                result = _dbContext.GroupTaskCodeMatches.ToList();
            }

            return result?.Select(Extract.ExtractGroupTaskCodeMatchMap.Map);
        }

        [HttpPost("AddGroupTaskCodeMatchMap")]
        public ActionResult AddSeqAddGroupTaskCodeMatchMapuenceSimilarity(IEnumerable<Import.ImportGroupTaskCodeMatchMap> groupTaskCodeMatchMaps)
        {
            Func<GroupTaskCodeMatchMap, Import.ImportGroupTaskCodeMatchMap, bool> finder = (existingItem, importItem) =>
            {
                return existingItem.CodeGroup == importItem.CodeGroup && existingItem.TaskCode == importItem.TaskCode;
            };

            Func<Import.ImportGroupTaskCodeMatchMap, GroupTaskCodeMatchMap, GroupTaskCodeMatchMap> transformer = (importItem, extistingItem) =>
            {
                if (extistingItem is null)
                {
                    return new GroupTaskCodeMatchMap
                    {
                        Id = 0,
                        CodeGroup = importItem.CodeGroup,
                        TaskCode = importItem.TaskCode,
                        GeneralCode = importItem.GeneralCode
                    };
                }
                else
                {
                    return new GroupTaskCodeMatchMap
                    {
                        Id = extistingItem.Id,
                        CodeGroup = importItem.CodeGroup,
                        TaskCode = importItem.TaskCode,
                        GeneralCode = importItem.GeneralCode
                    };
                }
            };

            var result = EntityUtil.AddEntity(_dbContext, _dbContext.GroupTaskCodeMatches, groupTaskCodeMatchMaps, finder, transformer, true);

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