using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract;
public class ExtractCodeGroup : IExtractObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "CodeGroupId")]
    [ModelViewColumn(DisplayName = "CodeGroupId", ToDisplay = true)]
    public int CodeGroupId { get; set; }

    [JsonProperty(PropertyName = "CodeGroupName")]
    [ModelViewColumn(DisplayName = "GroupCode", ToDisplay = true)]
    public string CodeGroupName { get; set; } = string.Empty;

    [JsonProperty(PropertyName = "CodeGroupText")]
    [ModelViewColumn(DisplayName = "GroupText", ToDisplay = true)]
    public string CodeGroupText { get; set; } = string.Empty;

    [JsonIgnore]
    public ICollection<ExtractTaskCode>? TaskCodes { get; set; }

    public ExtractCodeGroup() { }

    public ExtractCodeGroup(int codeId, string codeName, string codeText)
    {
        CodeGroupId = codeId;
        CodeGroupName = codeName;
        CodeGroupText = codeText;
    }

    public static ExtractCodeGroup Map(ETL.CodeGroup item) => new ExtractCodeGroup
    {
        CodeGroupId = item.CodeGroupId,
        CodeGroupName = item.CodeGroupName,
        CodeGroupText = item.CodeGroupText
    };
}