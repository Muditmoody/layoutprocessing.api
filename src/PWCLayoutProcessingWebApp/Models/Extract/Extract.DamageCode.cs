using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract;
public class ExtractDamageCode : IExtractObjects
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
    [JsonProperty(PropertyName = "DamageCodeName")]
    [ModelViewColumn(DisplayName = "DamageCode", ToDisplay = true)]
    public string DamageCodeName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the damage code text.
    /// </summary>
    [JsonProperty(PropertyName = "DamageCodeText")]
    [ModelViewColumn(DisplayName = "DamageText", ToDisplay = true)]
    public string DamageCodeText { get; set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtractDamageCode"/> class.
    /// </summary>
    public ExtractDamageCode()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtractDamageCode"/> class.
    /// </summary>
    /// <param name="codeId">The code id.</param>
    /// <param name="codeName">The code name.</param>
    /// <param name="codeText">The code text.</param>
    public ExtractDamageCode(int codeId, string codeName, string codeText)
    {
        DamageCodeId = codeId;
        DamageCodeName = codeName;
        DamageCodeText = codeText;
    }

    /// <summary>
    /// Maps the Entity.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>An ExtractDamageCode.</returns>
    public static ExtractDamageCode Map(ETL.DamageCode item) => new ExtractDamageCode
    {
        DamageCodeId = item.DamageCodeId,
        DamageCodeName = item.DamageCodeName,
        DamageCodeText = item.DamageCodeText
    };
}