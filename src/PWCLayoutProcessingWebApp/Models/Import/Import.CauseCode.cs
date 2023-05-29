using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Text.Json.Serialization;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Import;
public class ImportCauseCode : IImportObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "CauseCodeId")]
    [ModelViewColumn(DisplayName = "Id", ToDisplay = true)]
    public int CauseCodeId { get; set; }

    [ModelViewColumn(DisplayName = "CauseCode", ToDisplay = true)]
    public string CauseCodeName { get; set; } = string.Empty;

    [ModelViewColumn(DisplayName = "CauseText", ToDisplay = true)]
    public string CauseText { get; set; } = string.Empty;

    public ImportCauseCode() { }

    public ImportCauseCode(int codeId, string codeName, string codeText)
    {
        CauseCodeId = codeId;
        CauseCodeName = codeName;
        CauseText = codeText;
    }
}