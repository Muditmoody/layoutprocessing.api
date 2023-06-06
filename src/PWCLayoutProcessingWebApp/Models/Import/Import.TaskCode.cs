using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Import;
public class ImportTaskCode : IImportObjects
{
    /// <summary>
    /// Gets or sets the task code id.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "TaskCodeId")]
    [ModelViewColumn(DisplayName = "TaskCodeId", ToDisplay = true)]
    public int TaskCodeId { get; set; }

    /// <summary>
    /// Gets or sets the task code name.
    /// </summary>
    [ModelViewColumn(DisplayName = "TaskCodeName", ToDisplay = true)]
    public string TaskCodeName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the task code text.
    /// </summary>
    [ModelViewColumn(DisplayName = "TaskCodeText", ToDisplay = true)]
    public string TaskCodeText { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the group code id.
    /// </summary>
    [ModelViewColumn(DisplayName = "GroupCodeId", ToDisplay = true)]
    public int GroupCodeId { get; set; }

    /// <summary>
    /// Gets or sets the group code.
    /// </summary>
    [ModelViewColumn(DisplayName = "GroupCode", ToDisplay = true)]
    public string GroupCode { get; set; } = String.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="ImportTaskCode"/> class.
    /// </summary>
    public ImportTaskCode()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ImportTaskCode"/> class.
    /// </summary>
    /// <param name="codeId">The code id.</param>
    /// <param name="codeName">The code name.</param>
    /// <param name="codeText">The code text.</param>
    /// <param name="groupCodeId">The group code id.</param>
    /// <param name="groupCode">The group code.</param>
    public ImportTaskCode(int codeId, string codeName, string codeText, int groupCodeId, string groupCode)
    {
        TaskCodeId = codeId;
        TaskCodeName = codeName;
        TaskCodeText = codeText;
        GroupCodeId = groupCodeId;
        GroupCode = groupCode;
    }
}