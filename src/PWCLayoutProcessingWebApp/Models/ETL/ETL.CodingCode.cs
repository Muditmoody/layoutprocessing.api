using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.ETL;
public class CodingCode : LayoutProcessingObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "CodingCodeId")]
    [ModelViewColumn(DisplayName = "CodingCodeId", ToDisplay = true)]
    public int CodingCodeId { get; set; }

    [ModelViewColumn(DisplayName = "CodingCodeName", ToDisplay = true)]
    public string CodingCodeName { get; set; } = string.Empty;

    [ModelViewColumn(DisplayName = "CodingText", ToDisplay = true)]
    public string CodingCodeText { get; set; } = string.Empty;

    public CodingCode()
    { }

    public CodingCode(int codeId, string codeName, string codeText)
    {
        CodingCodeId = codeId;
        CodingCodeName = codeName;
        CodingCodeText = codeText;
    }

    public static CodingCode Map(SqlDataReader reader) => new CodingCode
    {
        CodingCodeId = reader.GetFieldValue<int>(reader.GetOrdinal("Id")),
        CodingCodeName = reader.GetFieldValue<string>(reader.GetOrdinal("Coding")),
        CodingCodeText = reader.GetFieldValue<string>(reader.GetOrdinal("CodingText"))
    };
}