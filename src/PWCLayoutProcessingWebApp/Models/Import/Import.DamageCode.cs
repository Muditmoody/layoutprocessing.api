using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Import;
public class ImportDamageCode : IImportObjects
{
    /// <summary>
    /// Gets or sets the damage code id.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "DamageCodeId")]
    [ModelViewColumn(DisplayName = "DamageCodeId", ToDisplay = true)]
    public int DamageCodeId { get; set; }

    /// <summary>
    /// Gets or sets the damage code name.
    /// </summary>
    [ModelViewColumn(DisplayName = "DamageCode", ToDisplay = true)]
    public string DamageCodeName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the damage code text.
    /// </summary>
    [ModelViewColumn(DisplayName = "DamageText", ToDisplay = true)]
    public string DamageCodeText { get; set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="ImportDamageCode"/> class.
    /// </summary>
    public ImportDamageCode()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ImportDamageCode"/> class.
    /// </summary>
    /// <param name="codeId">The code id.</param>
    /// <param name="codeName">The code name.</param>
    /// <param name="codeText">The code text.</param>
    public ImportDamageCode(int codeId, string codeName, string codeText)
    {
        DamageCodeId = codeId;
        DamageCodeName = codeName;
        DamageCodeText = codeText;
    }
}