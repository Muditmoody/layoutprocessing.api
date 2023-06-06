using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Import;
public class ImportCauseCode : IImportObjects
{
    /// <summary>
    /// Gets or sets the cause code id.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "CauseCodeId")]
    [ModelViewColumn(DisplayName = "Id", ToDisplay = true)]
    public int CauseCodeId { get; set; }

    /// <summary>
    /// Gets or sets the cause code name.
    /// </summary>
    [ModelViewColumn(DisplayName = "CauseCode", ToDisplay = true)]
    public string CauseCodeName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the cause text.
    /// </summary>
    [ModelViewColumn(DisplayName = "CauseText", ToDisplay = true)]
    public string CauseText { get; set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="ImportCauseCode"/> class.
    /// </summary>
    public ImportCauseCode()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ImportCauseCode"/> class.
    /// </summary>
    /// <param name="codeId">The code id.</param>
    /// <param name="codeName">The code name.</param>
    /// <param name="codeText">The code text.</param>
    public ImportCauseCode(int codeId, string codeName, string codeText)
    {
        CauseCodeId = codeId;
        CauseCodeName = codeName;
        CauseText = codeText;
    }
}