﻿using System.Data;
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
    /// The model ref data controller.
    /// </summary>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelRefDataController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="databaseProvider">The database provider.</param>
        /// <param name="queryBuilder">The query builder.</param>
        /// <param name="dbContext">The db context.</param>
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

        /// <summary>
        /// Gets the group task code match map.
        /// </summary>
        /// <returns>A list of Extract.ExtractGroupTaskCodeMatchMap.</returns>
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

        /// <summary>
        /// Adds the seq add group task code match mapuence similarity.
        /// </summary>
        /// <param name="groupTaskCodeMatchMaps">The group task code match maps.</param>
        /// <returns>An ActionResult.</returns>
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