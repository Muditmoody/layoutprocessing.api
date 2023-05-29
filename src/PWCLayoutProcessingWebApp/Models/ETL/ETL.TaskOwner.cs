using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.ETL;
public class TaskOwner : LayoutProcessingObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "TaskOwnerId")]
    [ModelViewColumn(DisplayName = "TaskOwnerId", ToDisplay = true)]
    public int TaskOwnerId { get; set; }

    [ModelViewColumn(DisplayName = "TaskOwnerCode", ToDisplay = true)]
    public string TaskOwnerCode { get; set; } = string.Empty;

    public TaskOwner() { }

    public TaskOwner(int codeId, string codeName)
    {
        TaskOwnerId = codeId;
        TaskOwnerCode = codeName;
    }

    public static TaskOwner Map(SqlDataReader reader) => new TaskOwner
    {
        TaskOwnerId = reader.GetFieldValue<int>(reader.GetOrdinal("Id")),
        TaskOwnerCode = reader.GetFieldValue<string>(reader.GetOrdinal("TaskOwner_Id")),
    };
}