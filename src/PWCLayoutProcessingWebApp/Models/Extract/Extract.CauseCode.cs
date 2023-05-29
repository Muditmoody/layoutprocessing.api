using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Text.Json.Serialization;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract;
public class ExtractCauseCode : IExtractObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "CauseCodeId")]
    [ModelViewColumn(DisplayName = "Id", ToDisplay = true)]
    public int CauseCodeId { get; set; }

    [JsonProperty(PropertyName = "CauseCode")]
    [ModelViewColumn(DisplayName = "CauseCode", ToDisplay = true)]
    public string CauseCodeName { get; set; } = string.Empty;

    [JsonProperty(PropertyName = "CauseText")]
    [ModelViewColumn(DisplayName = "CauseText", ToDisplay = true)]
    public string CauseText { get; set; } = string.Empty;

    public ExtractCauseCode() { }

    public ExtractCauseCode(int codeId, string codeName, string codeText)
    {
        CauseCodeId = codeId;
        CauseCodeName = codeName;
        CauseText = codeText;
    }

    public static ExtractCauseCode Map(ETL.CauseCode item) => new ExtractCauseCode
    {
        CauseCodeId = item.CauseCodeId,
        CauseCodeName = item.CauseCodeName,
        CauseText = item.CauseText
    };
}