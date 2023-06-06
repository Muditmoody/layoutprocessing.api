using System.Reflection;
using PWCLayoutProcessingWebApp.Models.Constants;

namespace PWCLayoutProcessingWebApp.BusinessLogic
{
#nullable enable

    /// <summary>
    /// The query builder.
    /// </summary>
    public class QueryBuilder
    {
        private ILogger _logger;
        private IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBuilder"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="configuration">The configuration.</param>
        public QueryBuilder(ILogger<QueryBuilder> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        /// <summary>
        /// Gets the query from resouce.
        /// </summary>
        /// <param name="sourceName">The source name.</param>
        /// <returns>A string.</returns>
        public string GetQueryFromResouce(string sourceName)
        {
            var queryString = string.Empty;
            var assembly = Assembly.GetExecutingAssembly();

            var sourceItem = assembly.GetManifestResourceNames().FirstOrDefault(s => s.EndsWith(sourceName));

            if (sourceItem is not null)
            {
                using (var stream = new StreamReader(assembly.GetManifestResourceStream(sourceItem)))
                {
                    queryString = stream?.ReadToEnd();
                }
            }
            else
            {
                throw new IOException($"Specified query '{sourceName}' resource was not found");
            }
            return queryString;
        }

        /// <summary>
        /// Gets the query from query dictionary.
        /// </summary>
        /// <param name="keyName">The key name.</param>
        /// <returns>A string.</returns>
        public string GetQueryFromQueryDictionary(string keyName)
        {
            var strQuery = string.Empty;
            return QueryDictionary.QueryLookUp.TryGetValue(keyName, out strQuery)
                ? strQuery
                : throw new Exception("Query not found");
        }
    }
}