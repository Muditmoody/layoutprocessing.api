using System.Data;
using Microsoft.AspNetCore.Mvc;
using PWCLayoutProcessingWebApp.Data;
using PWCLayoutProcessingWebApp.Models;
using PWCLayoutProcessingWebApp.Models.Model;
using PWCLayoutProcessingWebApp.BusinessLogic;
using Import = PWCLayoutProcessingWebApp.Models.Import;
using Extract = PWCLayoutProcessingWebApp.Models.Extract;

namespace PWCLayoutProcessingWebApp.Controllers.Modelling
{
#nullable enable

    /// <summary>
    /// The sequence similarity controller.
    /// </summary>
    [ApiController]
    [Route("api/model/[controller]")]
    public class SequenceSimilarityController : Controller
    {
        private readonly ILogger<SequenceSimilarityController> _logger;
        private readonly IConfiguration _configuration;
        private readonly DatabaseProvider _databaseProvider;
        private readonly QueryBuilder _queryBuilder;
        private readonly LayoutProcessingDbContext _dbContext;

        private readonly bool _useQuery;

        /// <summary>
        /// Initializes a new instance of the <see cref="SequenceSimilarityController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="databaseProvider">The database provider.</param>
        /// <param name="queryBuilder">The query builder.</param>
        /// <param name="dbContext">The db context.</param>
        public SequenceSimilarityController(ILogger<SequenceSimilarityController> logger, IConfiguration configuration,
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
        /// Gets the sequence similarity.
        /// </summary>
        /// <returns>A list of Extract.ExtractSequenceSimilarity.</returns>
        [HttpGet("GetSequenceSimilarity")]
        public IEnumerable<Extract.ExtractSequenceSimilarity> GetSequenceSimilarity()
        {
            _logger.LogDebug("Get Cause Code info");
            var result = default(IEnumerable<SequenceSimilarity>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("SequenceSimilarity.sql");
                result = _databaseProvider.ExecuteQuery(sql, SequenceSimilarity.Map);
            }
            else
            {
                var maxRunDate = _dbContext.SequenceSimilarities.Max(r => r.RunDate);
                result = _dbContext.SequenceSimilarities.Where(r => r.RunDate == maxRunDate).ToList();
            }

            return result?.Select(Extract.ExtractSequenceSimilarity.Map);
        }

        /// <summary>
        /// Gets the cause codes.
        /// </summary>
        /// <param name="notificationCode">The notification code.</param>
        /// <returns>A list of Extract.ExtractSequenceSimilarity.</returns>
        [HttpGet("GetSequenceSimilarityByNotification")]
        public IEnumerable<Extract.ExtractSequenceSimilarity> GetCauseCodes([FromQuery] string notificationCode)
        {
            _logger.LogDebug("Get Cause Code  info");

            var result = default(IEnumerable<SequenceSimilarity>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("SequenceSimilarity.sql");
            }
            else
            {
                var layouts = _dbContext.LayoutTypes.Where(l => l.EngineProgram.NotificationCode == notificationCode).Select(l => l.LayoutTypeId).ToList();

                result = _dbContext.SequenceSimilarities.Where(i => layouts.Contains(i.LayoutIdRef) || layouts.Contains(i.LayoutIdTest))
                                   .ToList();
            }

            return result?.Select(Extract.ExtractSequenceSimilarity.Map);
        }

        /// <summary>
        /// Adds the sequence similarity.
        /// </summary>
        /// <param name="similarityScores">The similarity scores.</param>
        /// <param name="runDate">The run date.</param>
        /// <returns>An ActionResult.</returns>
        [HttpPost("AddSequenceSimilarity")]
        public ActionResult AddSequenceSimilarity(IEnumerable<Import.ImportSequenceSimilarity> similarityScores, DateTime runDate)
        {
            runDate = runDate == default ? DateTime.Now : runDate;

            Func<SequenceSimilarity, Import.ImportSequenceSimilarity, bool> finder = (existingItem, importItem) =>
            {
                return existingItem.LayoutIdRef == importItem.LayoutIdRef && existingItem.LayoutIdTest == importItem.LayoutIdTest;
            };

            Func<Import.ImportSequenceSimilarity, SequenceSimilarity, SequenceSimilarity> transformer = (importItem, extistingItem) =>
            {
                if (extistingItem is null)
                {
                    return new SequenceSimilarity
                    {
                        Id = 0,
                        LayoutIdRef = importItem.LayoutIdRef,
                        LayoutIdTest = importItem.LayoutIdTest,
                        AlignTaskSequenceRef = string.Join(" ,", importItem.AlignTaskSequenceRef),
                        AlignTaskSequenceTest = string.Join(" ,", importItem.AlignTaskSequenceTest),
                        TaskSequenceRef = string.Join(" ,", importItem.TaskSequenceRef),
                        TaskSequenceTest = string.Join(" ,", importItem.TaskSequenceTest),
                        Score = importItem.Score,
                        RunDate = runDate
                    };
                }
                else
                {
                    return new SequenceSimilarity
                    {
                        Id = extistingItem.Id,
                        LayoutIdRef = importItem.LayoutIdRef,
                        LayoutIdTest = importItem.LayoutIdTest,
                        AlignTaskSequenceRef = string.Join(" ,", importItem.AlignTaskSequenceRef),
                        AlignTaskSequenceTest = string.Join(" ,", importItem.AlignTaskSequenceTest),
                        TaskSequenceRef = string.Join(" ,", importItem.TaskSequenceRef),
                        TaskSequenceTest = string.Join(" ,", importItem.TaskSequenceTest),
                        Score = importItem.Score,
                        RunDate = runDate
                    };
                }
            };

            var result = EntityUtil.AddEntity(_dbContext, _dbContext.SequenceSimilarities, similarityScores, finder, transformer, true);

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