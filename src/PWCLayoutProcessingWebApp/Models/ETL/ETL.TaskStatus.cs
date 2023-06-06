using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.ETL;
public class TaskStatus : LayoutProcessingObjects
{
    /// <summary>
    /// Gets or sets the task status id.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "TaskStatusId")]
    [ModelViewColumn(DisplayName = "TaskStatusId", ToDisplay = true)]
    public int TaskStatusId { get; set; }

    /// <summary>
    /// Gets or sets the task status code.
    /// </summary>
    [ModelViewColumn(DisplayName = "TaskStatusCode", ToDisplay = true)]
    public string TaskStatusCode { get; set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="TaskStatus"/> class.
    /// </summary>
    public TaskStatus()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="TaskStatus"/> class.
    /// </summary>
    /// <param name="codeId">The code id.</param>
    /// <param name="codeName">The code name.</param>
    public TaskStatus(int codeId, string codeName)
    {
        TaskStatusId = codeId;
        TaskStatusCode = codeName;
    }

    /// <summary>
    /// Maps the Entity.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <returns>A TaskStatus.</returns>
    public static TaskStatus Map(SqlDataReader reader) => new TaskStatus
    {
        TaskStatusId = reader.GetFieldValue<int>(reader.GetOrdinal("Id")),
        TaskStatusCode = reader.GetFieldValue<string>(reader.GetOrdinal("TaskStatus")),
    };
}