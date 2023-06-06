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
    /// The coding code controller.
    /// </summary>
    [ApiController]
    [Route("api/etl/[controller]")]
    public class CodingCodeController : ControllerBase
    {
        private readonly ILogger<CodingCodeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly DatabaseProvider _databaseProvider;
        private readonly QueryBuilder _queryBuilder;
        private readonly LayoutProcessingDbContext _dbContext;

        private readonly bool _useQuery;

        /// <summary>
        /// Initializes a new instance of the <see cref="CodingCodeController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="databaseProvider">The database provider.</param>
        /// <param name="queryBuilder">The query builder.</param>
        /// <param name="dbContext">The db context.</param>
        public CodingCodeController(ILogger<CodingCodeController> logger, IConfiguration configuration,
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
        /// Gets the coding code.
        /// </summary>
        /// <returns>A list of Extract.ExtractCodingCode.</returns>
        [HttpGet("GetCodingCodes")]
        public IEnumerable<Extract.ExtractCodingCode> GetCodingCode()
        {
            _logger.LogDebug("Get CodeGroup  info");
            var result = default(IEnumerable<CodingCode>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("CodingCode.sql");
                result = _databaseProvider.ExecuteQuery(sql, CodingCode.Map);
            }
            else
            {
                result = _dbContext.CodingCodes.ToList();
            }

            return result?.Select(Extract.ExtractCodingCode.Map);
        }

        /// <summary>
        /// Gets the coding code.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>A list of Extract.ExtractCodingCode.</returns>
        [HttpGet("GetCodingCodeByName")]
        public IEnumerable<Extract.ExtractCodingCode> GetCodingCode([FromQuery] IEnumerable<string> name)
        {
            _logger.LogDebug("Get CodeGroup info");

            var result = default(IEnumerable<CodingCode>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("CodingCode.sql");
                result = _databaseProvider.ExecuteQuery(sql, CodingCode.Map)
                                          .Where(p => name.Contains(p.CodingCodeName))
                                          .ToList();
            }
            else
            {
                result = _dbContext.CodingCodes
                                   .Where(p => name.Contains(p.CodingCodeName))
                                   .ToList();
            }

            return result?.Select(Extract.ExtractCodingCode.Map);
        }

        /// <summary>
        /// Adds the coding code.
        /// </summary>
        /// <param name="codingCodes">The coding codes.</param>
        /// <returns>An ActionResult.</returns>
        [HttpPost("AddCodingCode")]
        public ActionResult AddCodingCode(IEnumerable<Import.ImportCodingCode> codingCodes)
        {
            Func<CodingCode, Import.ImportCodingCode, bool> finder = (existingItem, importItem) =>
            {
                return existingItem.CodingCodeName == importItem.CodingCodeName;
            };

            Func<Import.ImportCodingCode, CodingCode, CodingCode> transformer = (importItem, extistingItem) =>
            {
                if (extistingItem is null)
                {
                    return new CodingCode
                    {
                        CodingCodeId = 0,
                        CodingCodeName = importItem.CodingCodeName,
                        CodingCodeText = importItem.CodingCodeText,
                    };
                }
                else
                {
                    return new CodingCode
                    {
                        CodingCodeId = extistingItem.CodingCodeId,
                        CodingCodeName = importItem.CodingCodeName,
                        CodingCodeText = importItem.CodingCodeText,
                    };
                }
            };

            var result = EntityUtil.AddEntity(_dbContext, _dbContext.CodingCodes, codingCodes, finder, transformer, true);

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