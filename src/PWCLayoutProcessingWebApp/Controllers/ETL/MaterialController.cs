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
    [ApiController]
    [Route("api/etl/[controller]")]
    public class MaterialController : ControllerBase
    {
        private readonly ILogger<MaterialController> _logger;
        private readonly IConfiguration _configuration;
        private readonly DatabaseProvider _databaseProvider;
        private readonly QueryBuilder _queryBuilder;
        private readonly LayoutProcessingDbContext _dbContext;

        private readonly bool _useQuery;

        public MaterialController(ILogger<MaterialController> logger, IConfiguration configuration,
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

        [HttpGet("GetMaterials")]
        public IEnumerable<Extract.ExtractMaterial> GetMaterials()
        {
            _logger.LogDebug("Get Material info");
            var result = default(IEnumerable<Material>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("Material.sql");
                result = _databaseProvider.ExecuteQuery(sql, Material.Map);
            }
            else
            {
                result = _dbContext.Materials.Include(e => e.Category).ToList();
            }

            return result?.Select(Extract.ExtractMaterial.Map);
        }

        [HttpGet("GetMaterialsByCode")]
        public IEnumerable<Extract.ExtractMaterial> GetMaterialsByCode([FromQuery] IEnumerable<string> name)
        {
            _logger.LogDebug("Get Material  info");

            var result = default(IEnumerable<Material>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("Material.sql");
                result = _databaseProvider.ExecuteQuery(sql, Material.Map)
                                          .Where(p => name.Contains(p.MaterialCode))
                                          .ToList();
            }
            else
            {
                result = _dbContext.Materials
                                   .Include(e => e.Category)
                                   .Where(p => name.Contains(p.MaterialCode))
                                   .ToList();
            }

            return result?.Select(Extract.ExtractMaterial.Map);
        }

        [HttpPost("AddMaterial")]
        public ActionResult AddMaterial(IEnumerable<Import.ImportMaterial> materials)
        {
            Func<Material, Import.ImportMaterial, bool> finder = (existingItem, importItem) =>
            {
                return existingItem.MaterialCode == importItem.MaterialCode;
            };

            Func<Import.ImportMaterial, Material, Material> transformer = (importItem, extistingItem) =>
            {
                if (extistingItem is null)
                {
                    return new Material
                    {
                        MaterialId = 0,
                        MaterialCode = importItem.MaterialCode,
                        Description = importItem.Description
                    };
                }
                else
                {
                    return new Material
                    {
                        MaterialId = extistingItem.MaterialId,
                        MaterialCode = importItem.MaterialCode,
                        Description = importItem.Description
                    };
                }
            };

            var result = EntityUtil.AddEntity(_dbContext, _dbContext.Materials, materials, finder, transformer, true);

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