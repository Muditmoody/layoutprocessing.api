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
    /// The layoutType controller.
    /// </summary>
    [ApiController]
    [Route("api/etl/[controller]")]
    public class LayoutTypeController : ControllerBase
    {
        private readonly ILogger<LayoutTypeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly DatabaseProvider _databaseProvider;
        private readonly QueryBuilder _queryBuilder;
        private readonly LayoutProcessingDbContext _dbContext;

        private readonly bool _useQuery;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutTypeController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="databaseProvider">The database provider.</param>
        /// <param name="queryBuilder">The query builder.</param>
        /// <param name="dbContext">The db context.</param>
        public LayoutTypeController(ILogger<LayoutTypeController> logger, IConfiguration configuration,
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
        /// Gets the layout type.
        /// </summary>
        /// <returns>A list of Extract.ExtractLayoutType.</returns>
        [HttpGet("GetLayoutTypes")]
        public IEnumerable<Extract.ExtractLayoutType> GetLayoutType()
        {
            _logger.LogDebug("Get Engine Program  info");
            var result = default(IEnumerable<LayoutType>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("LayoutType.sql");
                result = _databaseProvider.ExecuteQuery(sql, LayoutType.Map);
            }
            else
            {
                result = _dbContext.LayoutTypes
                                   .Include(e => e.CauseCode)
                                   .Include(e => e.DamageCode)
                                   .Include(e => e.EngineProgram)
                                   .ToList();
            }

            return result.Select(Extract.ExtractLayoutType.Map);
        }

        /// <summary>
        /// Gets the layout type.
        /// </summary>
        /// <param name="notificationRef">The notification ref.</param>
        /// <returns>A list of Extract.ExtractLayoutType.</returns>
        [HttpGet("GetLayoutTypeByNotification")]
        public IEnumerable<Extract.ExtractLayoutType> GetLayoutType([FromQuery] IEnumerable<string> notificationRef)
        {
            _logger.LogDebug("Get Engine program info");

            var result = default(IEnumerable<LayoutType>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("LayoutType.sql");
                result = _databaseProvider.ExecuteQuery(sql, LayoutType.Map)
                                          .Where(p => notificationRef.Contains(p.EngineProgram == null ? default : p.EngineProgram.NotificationCode))
                                          .ToList();
            }
            else
            {
                result = _dbContext.LayoutTypes
                                   .Include(e => e.CauseCode)
                                   .Include(e => e.DamageCode)
                                   .Include(e => e.EngineProgram)
                                   .Where(p => notificationRef.Contains(p.EngineProgram == null ? default : p.EngineProgram.NotificationCode))
                                   .ToList();
            }

            return result.Select(Extract.ExtractLayoutType.Map);
        }

        /// <summary>
        /// Adds the layout type.
        /// </summary>
        /// <param name="layoutTypes">The layout types.</param>
        /// <returns>An ActionResult.</returns>
        [HttpPost("AddLayoutType")]
        public ActionResult AddLayoutType(IEnumerable<Import.ImportLayoutType> layoutTypes)
        {
            var damageCodes = _dbContext.DamageCodes.ToList();
            var causeCodes = _dbContext.CauseCodes.ToList();

            var enginePrograms = _dbContext.EnginePrograms.ToList();

            bool hasValidDamageCode(Import.ImportLayoutType item)
            {
                return damageCodes.Select(c => c.DamageCodeId).ToList().Contains(item.DamageCodeId)
                      || damageCodes.Select(c => c.DamageCodeName).ToList().Contains(item.DamageCodeName);
            }

            bool hasValidCauseCode(Import.ImportLayoutType item)
            {
                return causeCodes.Select(c => c.CauseCodeId).ToList().Contains(item.CauseCodeId)
                      || causeCodes.Select(c => c.CauseCodeName).ToList().Contains(item.CauseCodeName);
            }

            bool hasValidEngineProgramNotificationCode(Import.ImportLayoutType item)
            {
                return enginePrograms.Select(c => c.EngineProgramId).ToList().Contains(item.NotificationId)
                      || enginePrograms.Select(c => c.NotificationCode).ToList().Contains(item.EngineProgramNotificationCode);
            }

            int getDamageCodeId(string damageCodeName)
            {
                return damageCodes?.Find(c => c.DamageCodeName == damageCodeName)?.DamageCodeId ?? 0;
            }

            DamageCode getDamageCode(int damageCodeId)
            {
                return damageCodes?.Find(c => c.DamageCodeId == damageCodeId);
            }

            int getCauseCodeId(string causeCodeName)
            {
                return causeCodes?.Find(c => c.CauseCodeName == causeCodeName)?.CauseCodeId ?? 0;
            }

            CauseCode getCauseCode(int causeCodeId)
            {
                return causeCodes?.Find(c => c.CauseCodeId == causeCodeId);
            }

            int getEngineProgramId(string engineProgramNotificationCode)
            {
                return enginePrograms?.Find(c => c.NotificationCode == engineProgramNotificationCode)?.EngineProgramId ?? 0;
            }

            EngineProgram getEngineProgram(int engineProgramId)
            {
                return enginePrograms?.Find(c => c.EngineProgramId == engineProgramId);
            }

            var (toProcess, skippedItem) = layoutTypes.PartitionBy(i => hasValidCauseCode(i) && hasValidDamageCode(i));

            Func<LayoutType, Import.ImportLayoutType, bool> finder = (existingItem, importItem) =>
            existingItem.ItemNumber == importItem.ItemNumber &&
            (existingItem.EngineProgram.NotificationCode == importItem.EngineProgramNotificationCode || existingItem.NotificationId == importItem.NotificationId)
            &&
            (existingItem.DamageCode?.DamageCodeName == importItem.DamageCodeName || existingItem.DamageCodeId == importItem.DamageCodeId) &&
            (existingItem.CauseCode?.CauseCodeName == importItem.CauseCodeName || existingItem.CauseCodeId == importItem.CauseCodeId);

            Func<Import.ImportLayoutType, LayoutType, LayoutType> transformer = (importItem, extistingItem) =>
            {
                if (extistingItem is null)
                {
                    return new LayoutType
                    {
                        LayoutTypeId = 0,
                        NotificationId = importItem.NotificationId == 0 ? getEngineProgramId(importItem.EngineProgramNotificationCode) : importItem.NotificationId,
                        EngineProgram = importItem.NotificationId == 0 ? getEngineProgram(getEngineProgramId(importItem.EngineProgramNotificationCode)) : getEngineProgram(importItem.NotificationId),
                        ItemNumber = importItem.ItemNumber,
                        CauseCodeId = importItem.CauseCodeId == 0 ? getCauseCodeId(importItem.CauseCodeName) : importItem.CauseCodeId,
                        CauseCode = importItem.CauseCodeId == 0 ? getCauseCode(getCauseCodeId(importItem.CauseCodeName)) : getCauseCode(importItem.CauseCodeId),
                        DamageCodeId = importItem.DamageCodeId == 0 ? getDamageCodeId(importItem.CauseCodeName) : importItem.DamageCodeId,
                        DamageCode = importItem.DamageCodeId == 0 ? getDamageCode(getDamageCodeId(importItem.CauseCodeName)) : getDamageCode(importItem.DamageCodeId),
                        LayoutText = importItem.LayoutText
                    };
                }
                else
                {
                    return new LayoutType
                    {
                        LayoutTypeId = extistingItem.LayoutTypeId,
                        NotificationId = importItem.NotificationId == 0 ? getEngineProgramId(importItem.EngineProgramNotificationCode) : importItem.NotificationId,
                        EngineProgram = importItem.NotificationId == 0 ? getEngineProgram(getEngineProgramId(importItem.EngineProgramNotificationCode)) : getEngineProgram(importItem.NotificationId),
                        ItemNumber = importItem.ItemNumber,
                        CauseCodeId = importItem.CauseCodeId == 0 ? getCauseCodeId(importItem.CauseCodeName) : importItem.CauseCodeId,
                        CauseCode = importItem.CauseCodeId == 0 ? getCauseCode(getCauseCodeId(importItem.CauseCodeName)) : getCauseCode(importItem.CauseCodeId),
                        DamageCodeId = importItem.DamageCodeId == 0 ? getDamageCodeId(importItem.CauseCodeName) : importItem.DamageCodeId,
                        DamageCode = importItem.DamageCodeId == 0 ? getDamageCode(getDamageCodeId(importItem.CauseCodeName)) : getDamageCode(importItem.DamageCodeId),
                        LayoutText = importItem.LayoutText
                    };
                }
            };

            var result = EntityUtil.AddEntity(_dbContext, _dbContext.LayoutTypes, toProcess, finder, transformer, true);
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
                return Ok(new Result.Ok<Import.SkippedImport<IEnumerable<Import.ImportLayoutType>>>(new Import.SkippedImport<IEnumerable<Import.ImportLayoutType>>("Skipped values", skippedItem)));
            }
        }
    }
}