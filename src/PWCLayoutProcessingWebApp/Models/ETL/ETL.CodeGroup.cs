using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.ETL;
public class CodeGroup : LayoutProcessingObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "CodeGroupId")]
    [ModelViewColumn(DisplayName = "CodeGroupId", ToDisplay = true)]
    public int CodeGroupId { get; set; }

    [ModelViewColumn(DisplayName = "GroupCode", ToDisplay = true)]
    public string CodeGroupName { get; set; } = string.Empty;

    [ModelViewColumn(DisplayName = "GroupText", ToDisplay = true)]
    public string CodeGroupText { get; set; } = string.Empty;

    [JsonIgnore]
    public ICollection<TaskCode>? TaskCodes { get; set; }

    public CodeGroup() { }

    public CodeGroup(int codeId, string codeName, string codeText)
    {
        CodeGroupId = codeId;
        CodeGroupName = codeName;
        CodeGroupText = codeText;
    }

    public static CodeGroup Map(SqlDataReader reader) => new CodeGroup
    {
        CodeGroupId = reader.GetFieldValue<int>(reader.GetOrdinal("Id")),
        CodeGroupName = reader.GetFieldValue<string>(reader.GetOrdinal("GroupCode")),
        CodeGroupText = reader.GetFieldValue<string>(reader.GetOrdinal("GroupText"))
    };
}