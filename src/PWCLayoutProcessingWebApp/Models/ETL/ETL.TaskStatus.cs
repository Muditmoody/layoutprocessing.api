using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.ETL;
public class TaskStatus : LayoutProcessingObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "TaskStatusId")]
    [ModelViewColumn(DisplayName = "TaskStatusId", ToDisplay = true)]
    public int TaskStatusId { get; set; }

    [ModelViewColumn(DisplayName = "TaskStatusCode", ToDisplay = true)]
    public string TaskStatusCode { get; set; } = string.Empty;

    public TaskStatus()
    { }

    public TaskStatus(int codeId, string codeName)
    {
        TaskStatusId = codeId;
        TaskStatusCode = codeName;
    }

    public static TaskStatus Map(SqlDataReader reader) => new TaskStatus
    {
        TaskStatusId = reader.GetFieldValue<int>(reader.GetOrdinal("Id")),
        TaskStatusCode = reader.GetFieldValue<string>(reader.GetOrdinal("TaskStatus")),
    };
}