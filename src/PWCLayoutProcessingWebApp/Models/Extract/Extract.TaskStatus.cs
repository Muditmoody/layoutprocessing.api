using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract;
public class ExtractTaskStatus : IExtractObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "TaskStatusId")]
    [ModelViewColumn(DisplayName = "TaskStatusId", ToDisplay = true)]
    public int TaskStatusId { get; set; }

    [JsonProperty(PropertyName = "TaskStatusCode")]
    [ModelViewColumn(DisplayName = "TaskStatusCode", ToDisplay = true)]
    public string TaskStatusCode { get; set; } = string.Empty;

    public ExtractTaskStatus() { }

    public ExtractTaskStatus(int codeId, string codeName)
    {
        TaskStatusId = codeId;
        TaskStatusCode = codeName;
    }

    public static ExtractTaskStatus Map(ETL.TaskStatus item) => new ExtractTaskStatus
    {
        TaskStatusId = item.TaskStatusId,
        TaskStatusCode = item.TaskStatusCode,
    };
}