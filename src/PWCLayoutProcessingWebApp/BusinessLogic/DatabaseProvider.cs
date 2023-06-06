using System.Data.SqlClient;

namespace PWCLayoutProcessingWebApp.BusinessLogic
{
#nullable enable

    /// <summary>
    /// The database provider.
    /// </summary>
    public class DatabaseProvider
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseProvider"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="logger">The logger.</param>
        public DatabaseProvider(IConfiguration configuration, ILogger<DatabaseProvider> logger)
        {
            _logger = logger;
            _configuration = configuration;
            this.TestConnection();
        }

        /// <summary>
        /// Tests the connection.
        /// </summary>
        /// <returns>A bool.</returns>
        public bool TestConnection()
        {
            var success = true;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("layoutProcessing")))
                {
                    sqlConnection.Open();
                    var sql = "Select 1";
                    SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                    var reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        _logger.LogInformation("Connection tested");
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                success = false;
            }
            return success;
        }

        /// <summary>
        /// Creates the connection.
        /// </summary>
        /// <returns>A SqlConnection.</returns>
        private SqlConnection CreateConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("layoutProcessing"));
        }

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="strQuery">The str query.</param>
        /// <param name="mapper">The mapper.</param>
        /// <returns>A list of TS.</returns>
        public List<T> ExecuteQuery<T>(string strQuery, Func<SqlDataReader, T> mapper)
        {
            var retObj = new List<T>();
            using (var conn = this.CreateConnection())
            {
                conn.Open();
                using (var command = new SqlCommand(strQuery, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                            while (reader.Read())
                            {
                                retObj.Add(mapper(reader));
                            }
                    }
                }
            }
            return retObj;
        }
    }
}