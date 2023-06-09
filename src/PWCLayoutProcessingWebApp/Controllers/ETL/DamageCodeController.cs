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
    /// The damage code controller.
    /// </summary>
    [ApiController]
    [Route("api/etl/[controller]")]
    public class DamageCodeController : ControllerBase
    {
        private readonly ILogger<DamageCodeController> _logger;
        private readonly DatabaseProvider _databaseProvider;
        private readonly QueryBuilder _queryBuilder;
        private readonly LayoutProcessingDbContext _dbContext;

        private readonly bool _useQuery;

        /// <summary>
        /// Initializes a new instance of the <see cref="DamageCodeController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="databaseProvider">The database provider.</param>
        /// <param name="queryBuilder">The query builder.</param>
        /// <param name="dbContext">The db context.</param>
        public DamageCodeController(ILogger<DamageCodeController> logger, IConfiguration configuration,
            DatabaseProvider databaseProvider, QueryBuilder queryBuilder,
            LayoutProcessingDbContext dbContext)
        {
            IConfiguration _configuration;
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
        /// Gets the damage code.
        /// </summary>
        /// <returns>A list of Extract.ExtractDamageCode.</returns>
        [HttpGet("GetDamageCodes")]
        public IEnumerable<Extract.ExtractDamageCode> GetDamageCode()
        {
            _logger.LogDebug("Get Damage Code  info");
            var result = default(IEnumerable<DamageCode>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("DamageCode.sql");
                result = _databaseProvider.ExecuteQuery(sql, DamageCode.Map);
            }
            else
            {
                result = _dbContext.DamageCodes.ToList();
            }

            return result?.Select(Extract.ExtractDamageCode.Map);
        }

        /// <summary>
        /// Gets the damage code.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>A list of Extract.ExtractDamageCode.</returns>
        [HttpGet("GetDamageCodeByName")]
        public IEnumerable<Extract.ExtractDamageCode> GetDamageCode([FromQuery] IEnumerable<string> name)
        {
            _logger.LogDebug("Get CodeGroup info");

            var result = default(IEnumerable<DamageCode>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("DamageCode.sql");
                result = _databaseProvider.ExecuteQuery(sql, DamageCode.Map)
                                          .Where(p => name.Contains(p.DamageCodeName))
                                          .ToList();
            }
            else
            {
                result = _dbContext.DamageCodes
                                   .Where(p => name.Contains(p.DamageCodeName))
                                   .ToList();
            }

            return result?.Select(Extract.ExtractDamageCode.Map);
        }

        /// <summary>
        /// Adds the damage code.
        /// </summary>
        /// <param name="damageCodes">The damage codes.</param>
        /// <returns>An ActionResult.</returns>
        [HttpPost("AddDamageCode")]
        public ActionResult AddDamageCode(IEnumerable<Import.ImportDamageCode> damageCodes)
        {
            Func<DamageCode, Import.ImportDamageCode, bool> finder = (existingItem, importItem) =>
            {
                return existingItem.DamageCodeName == importItem.DamageCodeName;
            };

            Func<Import.ImportDamageCode, DamageCode, DamageCode> transformer = (importItem, extistingItem) =>
            {
                if (extistingItem is null)
                {
                    return new DamageCode
                    {
                        DamageCodeId = 0,
                        DamageCodeName = importItem.DamageCodeName,
                        DamageCodeText = importItem.DamageCodeText,
                    };
                }
                else
                {
                    return new DamageCode
                    {
                        DamageCodeId = extistingItem.DamageCodeId,
                        DamageCodeName = importItem.DamageCodeName,
                        DamageCodeText = importItem.DamageCodeText,
                    };
                }
            };

            var result = EntityUtil.AddEntity(_dbContext, _dbContext.DamageCodes, damageCodes, finder, transformer, true);

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