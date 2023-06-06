using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract;
public class ExtractTaskOwner : IExtractObjects
{
    /// <summary>
    /// Gets or sets the task owner id.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "TaskOwnerId")]
    [ModelViewColumn(DisplayName = "TaskOwnerId", ToDisplay = true)]
    public int TaskOwnerId { get; set; }

    /// <summary>
    /// Gets or sets the task owner code.
    /// </summary>
    [JsonProperty(PropertyName = "TaskOwnerCode")]
    [ModelViewColumn(DisplayName = "TaskOwnerCode", ToDisplay = true)]
    public string TaskOwnerCode { get; set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtractTaskOwner"/> class.
    /// </summary>
    public ExtractTaskOwner()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtractTaskOwner"/> class.
    /// </summary>
    /// <param name="codeId">The code id.</param>
    /// <param name="codeName">The code name.</param>
    public ExtractTaskOwner(int codeId, string codeName)
    {
        TaskOwnerId = codeId;
        TaskOwnerCode = codeName;
    }

    /// <summary>
    /// Maps the Entity.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>An ExtractTaskOwner.</returns>
    public static ExtractTaskOwner Map(ETL.TaskOwner item) => new ExtractTaskOwner
    {
        TaskOwnerId = item.TaskOwnerId,
        TaskOwnerCode = item.TaskOwnerCode,
    };
}