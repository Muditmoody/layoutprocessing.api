using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract;
public class ExtractCodingCode : IExtractObjects
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
    [JsonProperty(PropertyName = "CodingCodeName")]
    [ModelViewColumn(DisplayName = "CodingCodeName", ToDisplay = true)]
    public string CodingCodeName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the coding code text.
    /// </summary>
    [JsonProperty(PropertyName = "CodingCodeText")]
    [ModelViewColumn(DisplayName = "CodingText", ToDisplay = true)]
    public string CodingCodeText { get; set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtractCodingCode"/> class.
    /// </summary>
    public ExtractCodingCode()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtractCodingCode"/> class.
    /// </summary>
    /// <param name="codeId">The code id.</param>
    /// <param name="codeName">The code name.</param>
    /// <param name="codeText">The code text.</param>
    public ExtractCodingCode(int codeId, string codeName, string codeText)
    {
        CodingCodeId = codeId;
        CodingCodeName = codeName;
        CodingCodeText = codeText;
    }

    /// <summary>
    /// Maps the Entity.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>An ExtractCodingCode.</returns>
    public static ExtractCodingCode Map(ETL.CodingCode item) => new ExtractCodingCode
    {
        CodingCodeId = item.CodingCodeId,
        CodingCodeName = item.CodingCodeName,
        CodingCodeText = item.CodingCodeText
    };
}