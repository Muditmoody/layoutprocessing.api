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
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly IConfiguration _configuration;
        private readonly DatabaseProvider _databaseProvider;
        private readonly QueryBuilder _queryBuilder;
        private readonly LayoutProcessingDbContext _dbContext;

        private readonly bool _useQuery;

        public CategoryController(ILogger<CategoryController> logger, IConfiguration configuration,
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

        [HttpGet("GetCategory")]
        public IEnumerable<Extract.ExtractCategory> GetCategory()
        {
            _logger.LogDebug("Get Task Owner info");
            var result = default(IEnumerable<Category>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("Category.sql");
                result = _databaseProvider.ExecuteQuery(sql, Category.Map);
            }
            else
            {
                result = _dbContext.Categories.ToList();
            }

            return result?.Select(Extract.ExtractCategory.Map);
        }

        [HttpGet("GetCategoriesByName")]
        public IEnumerable<Extract.ExtractCategory> GetCategoriesByName([FromQuery] IEnumerable<string> name)
        {
            _logger.LogDebug("Get Category  info");

            var result = default(IEnumerable<Category>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("Category.sql");
                result = _databaseProvider.ExecuteQuery(sql, Category.Map)
                                          .Where(p => name.Contains(p.CategoryName))
                                          .ToList();
            }
            else
            {
                result = _dbContext.Categories
                                   .Where(p => name.Contains(p.CategoryName))
                                   .ToList();
            }

            return result?.Select(Extract.ExtractCategory.Map);
        }

        [HttpPost("AddCategory")]
        public ActionResult AddCategory(IEnumerable<Import.ImportCategory> categories)
        {

            Func<Category, Import.ImportCategory, bool> finder = (existingItem, importItem) =>
            {
                return existingItem.CategoryName == importItem.CategoryName;
            };

            Func<Import.ImportCategory, Category, Category> transformer = (importItem, extistingItem) =>
            {
                if (extistingItem is null)
                {
                    return new Category
                    {
                        CategoryId = 0,
                        CategoryName = importItem.CategoryName
                    };
                }
                else
                {
                    return new Category
                    {
                        CategoryId = extistingItem.CategoryId,
                        CategoryName = importItem.CategoryName
                    };
                }
            };

            var result = EntityUtil.AddEntity(_dbContext, _dbContext.Categories, categories, finder, transformer, true);

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