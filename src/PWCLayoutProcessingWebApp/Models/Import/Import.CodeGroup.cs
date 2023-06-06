using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Import;
public class ImportCodeGroup : IImportObjects
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
    [ModelViewColumn(DisplayName = "GroupCode", ToDisplay = true)]
    public string CodeGroupName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the code group text.
    /// </summary>
    [ModelViewColumn(DisplayName = "GroupText", ToDisplay = true)]
    public string CodeGroupText { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the task codes.
    /// </summary>
    [JsonIgnore]
    public ICollection<ImportTaskCode>? TaskCodes { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ImportCodeGroup"/> class.
    /// </summary>
    public ImportCodeGroup()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ImportCodeGroup"/> class.
    /// </summary>
    /// <param name="codeId">The code id.</param>
    /// <param name="codeName">The code name.</param>
    /// <param name="codeText">The code text.</param>
    public ImportCodeGroup(int codeId, string codeName, string codeText)
    {
        CodeGroupId = codeId;
        CodeGroupName = codeName;
        CodeGroupText = codeText;
    }
}