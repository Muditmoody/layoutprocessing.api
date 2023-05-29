using System.Linq;
using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract;
public class ExtractTaskCode : IExtractObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "TaskCodeId")]
    [ModelViewColumn(DisplayName = "TaskCodeId", ToDisplay = true)]
    public int TaskCodeId { get; set; }

    [JsonProperty(PropertyName = "TaskCodeName")]
    [ModelViewColumn(DisplayName = "TaskCodeName", ToDisplay = true)]
    public string TaskCodeName { get; set; } = string.Empty;

    [JsonProperty(PropertyName = "TaskCodeText")]
    [ModelViewColumn(DisplayName = "TaskCodeText", ToDisplay = true)]
    public string TaskCodeText { get; set; } = string.Empty;

    [JsonProperty(PropertyName = "GroupCodeId")]
    [ModelViewColumn(DisplayName = "GroupCodeId", ToDisplay = true)]
    public int GroupCodeId { get; set; }

    [JsonProperty(PropertyName = "GroupCodeName")]
    [ModelViewColumn(DisplayName = "GroupCodeName", ToDisplay = true)]
    public string GroupCodeName { get; set; } = string.Empty;

    public ExtractTaskCode() { }

    public ExtractTaskCode(int codeId, string codeName, string codeText, int groupCodeId, string groupCodeName)
    {
        TaskCodeId = codeId;
        TaskCodeName = codeName;
        TaskCodeText = codeText;
        GroupCodeId = groupCodeId;
        GroupCodeName = groupCodeName;
    }

    public static ExtractTaskCode Map(ETL.TaskCode item) => new ExtractTaskCode
    {
        TaskCodeId = item.TaskCodeId,
        TaskCodeName = item.TaskCodeName,
        TaskCodeText = item.TaskCodeText,
        GroupCodeId = item.GroupCodeId,
        GroupCodeName = item.GroupCode?.CodeGroupName
    };
}