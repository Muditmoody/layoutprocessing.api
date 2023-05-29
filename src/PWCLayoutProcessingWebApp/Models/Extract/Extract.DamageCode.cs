using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract;
public class ExtractDamageCode : IExtractObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "DamageCodeId")]
    [ModelViewColumn(DisplayName = "DamageCodeId", ToDisplay = true)]
    public int DamageCodeId { get; set; }

    [JsonProperty(PropertyName = "DamageCodeName")]
    [ModelViewColumn(DisplayName = "DamageCode", ToDisplay = true)]
    public string DamageCodeName { get; set; } = string.Empty;

    [JsonProperty(PropertyName = "DamageCodeText")]
    [ModelViewColumn(DisplayName = "DamageText", ToDisplay = true)]
    public string DamageCodeText { get; set; } = string.Empty;

    public ExtractDamageCode() { }

    public ExtractDamageCode(int codeId, string codeName, string codeText)
    {
        DamageCodeId = codeId;
        DamageCodeName = codeName;
        DamageCodeText = codeText;
    }

    public static ExtractDamageCode Map(ETL.DamageCode item) => new ExtractDamageCode
    {
        DamageCodeId = item.DamageCodeId,
        DamageCodeName = item.DamageCodeName,
        DamageCodeText = item.DamageCodeText
    };
}