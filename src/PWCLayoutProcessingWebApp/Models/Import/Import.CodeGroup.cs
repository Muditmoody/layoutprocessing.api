using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Import;
public class ImportCodeGroup : IImportObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "CodeGroupId")]
    [ModelViewColumn(DisplayName = "CodeGroupId", ToDisplay = true)]
    public int CodeGroupId { get; set; }

    [ModelViewColumn(DisplayName = "GroupCode", ToDisplay = true)]
    public string CodeGroupName { get; set; } = string.Empty;

    [ModelViewColumn(DisplayName = "GroupText", ToDisplay = true)]
    public string CodeGroupText { get; set; } = string.Empty;

    [JsonIgnore]
    public ICollection<ImportTaskCode>? TaskCodes { get; set; }

    public ImportCodeGroup() { }

    public ImportCodeGroup(int codeId, string codeName, string codeText)
    {
        CodeGroupId = codeId;
        CodeGroupName = codeName;
        CodeGroupText = codeText;
    }
}