using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Import;
public class ImportCodingCode : IImportObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "CodingCodeId")]
    [ModelViewColumn(DisplayName = "CodingCodeId", ToDisplay = true)]
    public int CodingCodeId { get; set; }

    [ModelViewColumn(DisplayName = "CodingCodeName", ToDisplay = true)]
    public string CodingCodeName { get; set; } = string.Empty;

    [ModelViewColumn(DisplayName = "CodingText", ToDisplay = true)]
    public string CodingCodeText { get; set; } = string.Empty;

    public ImportCodingCode()
    { }

    public ImportCodingCode(int codeId, string codeName, string codeText)
    {
        CodingCodeId = codeId;
        CodingCodeName = codeName;
        CodingCodeText = codeText;
    }

}