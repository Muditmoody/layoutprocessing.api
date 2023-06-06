using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract;
public class ExtractTaskCode : IExtractObjects
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
    [JsonProperty(PropertyName = "TaskCodeName")]
    [ModelViewColumn(DisplayName = "TaskCodeName", ToDisplay = true)]
    public string TaskCodeName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the task code text.
    /// </summary>
    [JsonProperty(PropertyName = "TaskCodeText")]
    [ModelViewColumn(DisplayName = "TaskCodeText", ToDisplay = true)]
    public string TaskCodeText { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the group code id.
    /// </summary>
    [JsonProperty(PropertyName = "GroupCodeId")]
    [ModelViewColumn(DisplayName = "GroupCodeId", ToDisplay = true)]
    public int GroupCodeId { get; set; }

    /// <summary>
    /// Gets or sets the group code name.
    /// </summary>
    [JsonProperty(PropertyName = "GroupCodeName")]
    [ModelViewColumn(DisplayName = "GroupCodeName", ToDisplay = true)]
    public string GroupCodeName { get; set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtractTaskCode"/> class.
    /// </summary>
    public ExtractTaskCode()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtractTaskCode"/> class.
    /// </summary>
    /// <param name="codeId">The code id.</param>
    /// <param name="codeName">The code name.</param>
    /// <param name="codeText">The code text.</param>
    /// <param name="groupCodeId">The group code id.</param>
    /// <param name="groupCodeName">The group code name.</param>
    public ExtractTaskCode(int codeId, string codeName, string codeText, int groupCodeId, string groupCodeName)
    {
        TaskCodeId = codeId;
        TaskCodeName = codeName;
        TaskCodeText = codeText;
        GroupCodeId = groupCodeId;
        GroupCodeName = groupCodeName;
    }

    /// <summary>
    /// Maps the Entity.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>An ExtractTaskCode.</returns>
    public static ExtractTaskCode Map(ETL.TaskCode item) => new ExtractTaskCode
    {
        TaskCodeId = item.TaskCodeId,
        TaskCodeName = item.TaskCodeName,
        TaskCodeText = item.TaskCodeText,
        GroupCodeId = item.GroupCodeId,
        GroupCodeName = item.GroupCode?.CodeGroupName
    };
}