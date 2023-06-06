using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract;
public class ExtractCodeGroup : IExtractObjects
{
    /// <summary>
    /// Gets or sets the code group id.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "CodeGroupId")]
    [ModelViewColumn(DisplayName = "CodeGroupId", ToDisplay = true)]
    public int CodeGroupId { get; set; }

    /// <summary>
    /// Gets or sets the code group name.
    /// </summary>
    [JsonProperty(PropertyName = "CodeGroupName")]
    [ModelViewColumn(DisplayName = "GroupCode", ToDisplay = true)]
    public string CodeGroupName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the code group text.
    /// </summary>
    [JsonProperty(PropertyName = "CodeGroupText")]
    [ModelViewColumn(DisplayName = "GroupText", ToDisplay = true)]
    public string CodeGroupText { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the task codes.
    /// </summary>
    [JsonIgnore]
    public ICollection<ExtractTaskCode>? TaskCodes { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtractCodeGroup"/> class.
    /// </summary>
    public ExtractCodeGroup()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtractCodeGroup"/> class.
    /// </summary>
    /// <param name="codeId">The code id.</param>
    /// <param name="codeName">The code name.</param>
    /// <param name="codeText">The code text.</param>
    public ExtractCodeGroup(int codeId, string codeName, string codeText)
    {
        CodeGroupId = codeId;
        CodeGroupName = codeName;
        CodeGroupText = codeText;
    }

    /// <summary>
    /// Maps the Entity.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>An ExtractCodeGroup.</returns>
    public static ExtractCodeGroup Map(ETL.CodeGroup item) => new ExtractCodeGroup
    {
        CodeGroupId = item.CodeGroupId,
        CodeGroupName = item.CodeGroupName,
        CodeGroupText = item.CodeGroupText
    };
}