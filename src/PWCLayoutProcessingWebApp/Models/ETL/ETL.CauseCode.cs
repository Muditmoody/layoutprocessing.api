using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Text.Json.Serialization;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.ETL;
public class CauseCode : LayoutProcessingObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "CauseCodeId")]
    [ModelViewColumn(DisplayName = "Id", ToDisplay = true)]
    public int CauseCodeId { get; set; }

    [ModelViewColumn(DisplayName = "CauseCode", ToDisplay = true)]
    public string CauseCodeName { get; set; } = string.Empty;

    [ModelViewColumn(DisplayName = "CauseText", ToDisplay = true)]
    public string CauseText { get; set; } = string.Empty;

    public CauseCode() { }

    public CauseCode(int codeId, string codeName, string codeText)
    {
        CauseCodeId = codeId;
        CauseCodeName = codeName;
        CauseText = codeText;
    }

    public static CauseCode Map(SqlDataReader reader) => new CauseCode
    {
        CauseCodeId = reader.GetFieldValue<int>(reader.GetOrdinal("Id")),
        CauseCodeName = reader.GetFieldValue<string>(reader.GetOrdinal("CauseCode")),
        CauseText = reader.GetFieldValue<string>(reader.GetOrdinal("CauseText"))
    };
}