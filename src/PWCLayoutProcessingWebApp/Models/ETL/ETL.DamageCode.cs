using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.ETL;
public class DamageCode : LayoutProcessingObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "DamageCodeId")]
    [ModelViewColumn(DisplayName = "DamageCodeId", ToDisplay = true)]
    public int DamageCodeId { get; set; }

    [ModelViewColumn(DisplayName = "DamageCode", ToDisplay = true)]
    public string DamageCodeName { get; set; } = string.Empty;

    [ModelViewColumn(DisplayName = "DamageText", ToDisplay = true)]
    public string DamageCodeText { get; set; } = string.Empty;

    public DamageCode() { }

    public DamageCode(int codeId, string codeName, string codeText)
    {
        DamageCodeId = codeId;
        DamageCodeName = codeName;
        DamageCodeText = codeText;
    }

    public static DamageCode Map(SqlDataReader reader) => new DamageCode
    {
        DamageCodeId = reader.GetFieldValue<int>(reader.GetOrdinal("Id")),
        DamageCodeName = reader.GetFieldValue<string>(reader.GetOrdinal("DamageCode")),
        DamageCodeText = reader.GetFieldValue<string>(reader.GetOrdinal("DamageText"))
    };
}