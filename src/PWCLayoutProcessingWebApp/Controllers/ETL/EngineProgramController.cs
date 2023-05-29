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
    public class EngineProgramController : ControllerBase
    {
        private readonly ILogger<EngineProgramController> _logger;
        private readonly IConfiguration _configuration;
        private readonly DatabaseProvider _databaseProvider;
        private readonly QueryBuilder _queryBuilder;
        private readonly LayoutProcessingDbContext _dbContext;

        private readonly bool _useQuery;

        public EngineProgramController(ILogger<EngineProgramController> logger, IConfiguration configuration,
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

        [HttpGet("GetEnginePrograms")]
        public IEnumerable<Extract.ExtractEngineProgram> GetEngineProgram()
        {
            _logger.LogDebug("Get Engine Program  info");
            var result = default(IEnumerable<EngineProgram>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("EngineProgram.sql");
                result = _databaseProvider.ExecuteQuery(sql, EngineProgram.Map);
            }
            else
            {
                result = _dbContext.EnginePrograms.Include(e => e.CodingCode).ToList();
            }

            return result.Select(Extract.ExtractEngineProgram.Map);
        }

        [HttpGet("GetEngineProgramByName")]
        public IEnumerable<Extract.ExtractEngineProgram> GetEngineProgram([FromQuery] IEnumerable<string> name)
        {
            _logger.LogDebug("Get Engine program info");

            var result = default(IEnumerable<EngineProgram>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("EngineProgram.sql");
                result = _databaseProvider.ExecuteQuery(sql, EngineProgram.Map)
                                          .Where(p => name.Contains(p.NotificationCode))
                                          .ToList();
            }
            else
            {
                result = _dbContext.EnginePrograms.Include(e => e.CodingCode)
                                   .Where(p => name.Contains(p.NotificationCode))
                                   .ToList();
            }

            return result.Select(Extract.ExtractEngineProgram.Map);
        }


        [HttpPost("AddEngineProgram")]
        public ActionResult AddEngineProgram(IEnumerable<Import.ImportEngineProgram> enginePrograms)
        {

            var codingCodes = _dbContext.CodingCodes.ToList();

            bool hasValidCodingCode(Import.ImportEngineProgram item)
            {
                return codingCodes.Select(c => c.CodingCodeId).ToList().Contains(item.CodingCodeId)
                      || codingCodes.Select(c => c.CodingCodeName).ToList().Contains(item.CodingCodeName);
            }

            int getCodingCodeId(string codingCodeName)
            {
                return codingCodes?.Find(c => c.CodingCodeName == codingCodeName)?.CodingCodeId ?? 0;
            }

            CodingCode getCodingCode(int codingCodeId)
            {
                return codingCodes?.Find(c => c.CodingCodeId == codingCodeId);
            }

            var (toProcess, skippedItem) = enginePrograms.PartitionBy(i => hasValidCodingCode(i));

            Func<EngineProgram, Import.ImportEngineProgram, bool> finder = (existingItem, importItem) =>
            existingItem.NotificationCode == importItem.NotificationCode &&
            (existingItem.CodingCode?.CodingCodeName == importItem.CodingCodeName
            || existingItem.CodingCode.CodingCodeId == importItem.CodingCodeId);

            Func<Import.ImportEngineProgram, EngineProgram, EngineProgram> transformer = (importItem, extistingItem) =>
            {
                if (extistingItem is null)
                {
                    return new EngineProgram
                    {
                        EngineProgramId = 0,
                        NotificationCode = importItem.NotificationCode,
                        Description = importItem.Description,
                        CodingCodeId = importItem.CodingCodeId == 0 ? getCodingCodeId(importItem.CodingCodeName) : importItem.CodingCodeId,
                        CodingCode = importItem.CodingCodeId == 0 ? getCodingCode(getCodingCodeId(importItem.CodingCodeName)) : getCodingCode(importItem.CodingCodeId)
                    };
                }
                else
                {
                    return new EngineProgram
                    {
                        EngineProgramId = extistingItem.EngineProgramId,
                        NotificationCode = importItem.NotificationCode,
                        Description = importItem.Description,
                        CodingCodeId = importItem.CodingCodeId == 0 ? getCodingCodeId(importItem.CodingCodeName) : importItem.CodingCodeId,
                        CodingCode = importItem.CodingCodeId == 0 ? getCodingCode(getCodingCodeId(importItem.CodingCodeName)) : getCodingCode(importItem.CodingCodeId)
                    };
                }
            };

            var result = EntityUtil.AddEntity(_dbContext, _dbContext.EnginePrograms, toProcess, finder, transformer, true);
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
                return Ok(new Result.Ok<Import.SkippedImport<IEnumerable<Import.ImportEngineProgram>>>(new Import.SkippedImport<IEnumerable<Import.ImportEngineProgram>>("Skipped values", skippedItem)));
            }
        }
    }
}