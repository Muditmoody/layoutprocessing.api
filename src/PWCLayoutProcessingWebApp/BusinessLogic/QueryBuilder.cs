using System.Reflection;
using PWCLayoutProcessingWebApp.Models.Constants;

namespace PWCLayoutProcessingWebApp.BusinessLogic
{
    public class QueryBuilder
    {
        private ILogger _logger;
        private IConfiguration _configuration;

        public QueryBuilder(ILogger<QueryBuilder> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

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

        public string GetQueryFromQueryDictionary(string keyName)
        {
            var strQuery = string.Empty;
            return QueryDictionary.QueryLookUp.TryGetValue(keyName, out strQuery)
                ? strQuery
                : throw new Exception("Query not found");
        }
    }
}