using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract;

/// <summary>
/// Cause Code Class model
/// </summary>
public class ExtractCauseCode : IExtractObjects
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
    [JsonProperty(PropertyName = "CauseCode")]
    [ModelViewColumn(DisplayName = "CauseCode", ToDisplay = true)]
    public string CauseCodeName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the cause text.
    /// </summary>
    [JsonProperty(PropertyName = "CauseText")]
    [ModelViewColumn(DisplayName = "CauseText", ToDisplay = true)]
    public string CauseText { get; set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtractCauseCode"/> class.
    /// </summary>
    public ExtractCauseCode()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtractCauseCode"/> class.
    /// </summary>
    /// <param name="codeId">The code id.</param>
    /// <param name="codeName">The code name.</param>
    /// <param name="codeText">The code text.</param>
    public ExtractCauseCode(int codeId, string codeName, string codeText)
    {
        CauseCodeId = codeId;
        CauseCodeName = codeName;
        CauseText = codeText;
    }

    /// <summary>
    /// Maps the Entity.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>An ExtractCauseCode.</returns>
    public static ExtractCauseCode Map(ETL.CauseCode item) => new ExtractCauseCode
    {
        CauseCodeId = item.CauseCodeId,
        CauseCodeName = item.CauseCodeName,
        CauseText = item.CauseText
    };
}