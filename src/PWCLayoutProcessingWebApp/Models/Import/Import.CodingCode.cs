using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Import;
public class ImportCodingCode : IImportObjects
{
    /// <summary>
    /// Gets or sets the coding code id.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "CodingCodeId")]
    [ModelViewColumn(DisplayName = "CodingCodeId", ToDisplay = true)]
    public int CodingCodeId { get; set; }

    /// <summary>
    /// Gets or sets the coding code name.
    /// </summary>
    [ModelViewColumn(DisplayName = "CodingCodeName", ToDisplay = true)]
    public string CodingCodeName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the coding code text.
    /// </summary>
    [ModelViewColumn(DisplayName = "CodingText", ToDisplay = true)]
    public string CodingCodeText { get; set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="ImportCodingCode"/> class.
    /// </summary>
    public ImportCodingCode()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ImportCodingCode"/> class.
    /// </summary>
    /// <param name="codeId">The code id.</param>
    /// <param name="codeName">The code name.</param>
    /// <param name="codeText">The code text.</param>
    public ImportCodingCode(int codeId, string codeName, string codeText)
    {
        CodingCodeId = codeId;
        CodingCodeName = codeName;
        CodingCodeText = codeText;
    }
}