using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract;
public class ExtractTaskOwner : IExtractObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "TaskOwnerId")]
    [ModelViewColumn(DisplayName = "TaskOwnerId", ToDisplay = true)]
    public int TaskOwnerId { get; set; }

    [JsonProperty(PropertyName = "TaskOwnerCode")]
    [ModelViewColumn(DisplayName = "TaskOwnerCode", ToDisplay = true)]
    public string TaskOwnerCode { get; set; } = string.Empty;

    public ExtractTaskOwner() { }

    public ExtractTaskOwner(int codeId, string codeName)
    {
        TaskOwnerId = codeId;
        TaskOwnerCode = codeName;
    }

    public static ExtractTaskOwner Map(ETL.TaskOwner item) => new ExtractTaskOwner
    {
        TaskOwnerId = item.TaskOwnerId,
        TaskOwnerCode = item.TaskOwnerCode,
    };
}