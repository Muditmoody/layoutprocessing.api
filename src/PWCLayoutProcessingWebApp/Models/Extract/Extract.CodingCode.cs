using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract;
public class ExtractCodingCode : IExtractObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "CodingCodeId")]
    [ModelViewColumn(DisplayName = "CodingCodeId", ToDisplay = true)]
    public int CodingCodeId { get; set; }

    [JsonProperty(PropertyName = "CodingCodeName")]
    [ModelViewColumn(DisplayName = "CodingCodeName", ToDisplay = true)]
    public string CodingCodeName { get; set; } = string.Empty;

    [JsonProperty(PropertyName = "CodingCodeText")]
    [ModelViewColumn(DisplayName = "CodingText", ToDisplay = true)]
    public string CodingCodeText { get; set; } = string.Empty;

    public ExtractCodingCode()
    { }

    public ExtractCodingCode(int codeId, string codeName, string codeText)
    {
        CodingCodeId = codeId;
        CodingCodeName = codeName;
        CodingCodeText = codeText;
    }

    public static ExtractCodingCode Map(ETL.CodingCode item) => new ExtractCodingCode
    {
        CodingCodeId = item.CodingCodeId,
        CodingCodeName = item.CodingCodeName,
        CodingCodeText = item.CodingCodeText
    };
}