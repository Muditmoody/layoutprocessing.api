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
    public class SupplierVendorController : ControllerBase
    {
        private readonly ILogger<SupplierVendorController> _logger;
        private readonly IConfiguration _configuration;
        private readonly DatabaseProvider _databaseProvider;
        private readonly QueryBuilder _queryBuilder;
        private readonly LayoutProcessingDbContext _dbContext;

        private readonly bool _useQuery;

        public SupplierVendorController(ILogger<SupplierVendorController> logger, IConfiguration configuration,
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

        [HttpGet("GetSupplierVendors")]
        public IEnumerable<Extract.ExtractSupplierVendor> GetSupplierVendors()
        {
            _logger.LogDebug("Get Supplier Vendor info");
            var result = default(IEnumerable<SupplierVendor>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("SupplierVendor.sql");
                result = _databaseProvider.ExecuteQuery(sql, SupplierVendor.Map);
            }
            else
            {
                result = _dbContext.SupplierVendors.ToList();
            }

            return result?.Select(Extract.ExtractSupplierVendor.Map);
        }

        [HttpGet("GetSupplierVendorByCode")]
        public IEnumerable<Extract.ExtractSupplierVendor> GetSupplierVendorsByCode([FromQuery] IEnumerable<string> name)
        {
            _logger.LogDebug("Get Supplier Vendor  info");

            var result = default(IEnumerable<SupplierVendor>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("SupplierVendor.sql");
                result = _databaseProvider.ExecuteQuery(sql, SupplierVendor.Map)
                                          .Where(p => name.Contains(p.SupplierVendorCode))
                                          .ToList();
            }
            else
            {
                result = _dbContext.SupplierVendors
                                   .Where(p => name.Contains(p.SupplierVendorCode))
                                   .ToList();
            }

            return result?.Select(Extract.ExtractSupplierVendor.Map);
        }

        [HttpPost("AddSupplierVendor")]
        public ActionResult AddSupplierVendor(IEnumerable<Import.ImportSupplierVendor> supplierVendors)
        {
            Func<SupplierVendor, Import.ImportSupplierVendor, bool> finder = (existingItem, importItem) =>
            {
                return existingItem.SupplierVendorCode == importItem.SupplierVendorCode;
            };

            Func<Import.ImportSupplierVendor, SupplierVendor, SupplierVendor> transformer = (importItem, extistingItem) =>
            {
                if (extistingItem is null)
                {
                    return new SupplierVendor
                    {
                        SupplierVendorId = 0,
                        SupplierVendorCode = importItem.SupplierVendorCode,
                    };
                }
                else
                {
                    return new SupplierVendor
                    {
                        SupplierVendorId = extistingItem.SupplierVendorId,
                        SupplierVendorCode = importItem.SupplierVendorCode,
                    };
                }
            };

            var result = EntityUtil.AddEntity(_dbContext, _dbContext.SupplierVendors, supplierVendors, finder, transformer, true);

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