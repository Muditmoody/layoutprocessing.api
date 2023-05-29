using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Import;
public class ImportTaskStatus : IImportObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "TaskStatusId")]
    [ModelViewColumn(DisplayName = "TaskStatusId", ToDisplay = true)]
    public int TaskStatusId { get; set; }

    [ModelViewColumn(DisplayName = "TaskStatusCode", ToDisplay = true)]
    public string TaskStatusCode { get; set; } = string.Empty;

    public ImportTaskStatus() { }

    public ImportTaskStatus(int codeId, string codeName)
    {
        TaskStatusId = codeId;
        TaskStatusCode = codeName;
    }
}