using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Import;
public class ImportTaskCode : IImportObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "TaskCodeId")]
    [ModelViewColumn(DisplayName = "TaskCodeId", ToDisplay = true)]
    public int TaskCodeId { get; set; }

    [ModelViewColumn(DisplayName = "TaskCodeName", ToDisplay = true)]
    public string TaskCodeName { get; set; } = string.Empty;

    [ModelViewColumn(DisplayName = "TaskCodeText", ToDisplay = true)]
    public string TaskCodeText { get; set; } = string.Empty;

    [ModelViewColumn(DisplayName = "GroupCodeId", ToDisplay = true)]
    public int GroupCodeId { get; set; }

    [ModelViewColumn(DisplayName = "GroupCode", ToDisplay = true)]
    public string GroupCode { get; set; } = String.Empty;

    public ImportTaskCode() { }

    public ImportTaskCode(int codeId, string codeName, string codeText, int groupCodeId, string groupCode)
    {
        TaskCodeId = codeId;
        TaskCodeName = codeName;
        TaskCodeText = codeText;
        GroupCodeId = groupCodeId;
        GroupCode = groupCode;
    }
}