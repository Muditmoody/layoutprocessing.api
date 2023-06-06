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
    /// The cause code controller.
    /// </summary>
    [ApiController]
    [Route("api/etl/[controller]")]
    public class CauseCodeController : ControllerBase
    {
        private readonly ILogger<CauseCodeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly DatabaseProvider _databaseProvider;
        private readonly QueryBuilder _queryBuilder;
        private readonly LayoutProcessingDbContext _dbContext;

        private readonly bool _useQuery;

        /// <summary>
        /// Initializes a new instance of the <see cref="CauseCodeController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="databaseProvider">The database provider.</param>
        /// <param name="queryBuilder">The query builder.</param>
        /// <param name="dbContext">The db context.</param>
        public CauseCodeController(ILogger<CauseCodeController> logger, IConfiguration configuration,
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
        /// Gets the cause codes.
        /// </summary>
        /// <returns>A list of Extract.ExtractCauseCode.</returns>
        [HttpGet("GetCauseCodes")]
        public IEnumerable<Extract.ExtractCauseCode> GetCauseCodes()
        {
            _logger.LogDebug("Get Cause Code info");
            var result = default(IEnumerable<CauseCode>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("CauseCode.sql");
                result = _databaseProvider.ExecuteQuery(sql, CauseCode.Map);
            }
            else
            {
                result = _dbContext.CauseCodes.ToList();
            }

            return result?.Select(Extract.ExtractCauseCode.Map);
        }

        /// <summary>
        /// Gets the cause codes.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>A list of Extract.ExtractCauseCode.</returns>
        [HttpGet("GetCauseCodeByName")]
        public IEnumerable<Extract.ExtractCauseCode> GetCauseCodes([FromQuery] IEnumerable<string> name)
        {
            _logger.LogDebug("Get Cause Code  info");

            var result = default(IEnumerable<CauseCode>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("CauseCode.sql");
                result = _databaseProvider.ExecuteQuery(sql, CauseCode.Map)
                                          .Where(p => name.Contains(p.CauseCodeName))
                                          .ToList();
            }
            else
            {
                result = _dbContext.CauseCodes
                                   .Where(p => name.Contains(p.CauseCodeName))
                                   .ToList();
            }

            return result?.Select(Extract.ExtractCauseCode.Map);
        }

        /// <summary>
        /// Adds the cause code.
        /// </summary>
        /// <param name="causeCodes">The cause codes.</param>
        /// <returns>An ActionResult.</returns>
        [HttpPost("AddCauseCode")]
        public ActionResult AddCauseCode(IEnumerable<Import.ImportCauseCode> causeCodes)
        {
            Func<CauseCode, Import.ImportCauseCode, bool> finder = (existingItem, importItem) =>
            {
                return existingItem.CauseCodeName == importItem.CauseCodeName;
            };

            Func<Import.ImportCauseCode, CauseCode, CauseCode> transformer = (importItem, extistingItem) =>
            {
                if (extistingItem is null)
                {
                    return new CauseCode
                    {
                        CauseCodeId = 0,
                        CauseCodeName = importItem.CauseCodeName,
                        CauseText = importItem.CauseText,
                    };
                }
                else
                {
                    return new CauseCode
                    {
                        CauseCodeId = extistingItem.CauseCodeId,
                        CauseCodeName = importItem.CauseCodeName,
                        CauseText = importItem.CauseText,
                    };
                }
            };

            var result = EntityUtil.AddEntity(_dbContext, _dbContext.CauseCodes, causeCodes, finder, transformer, true);

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