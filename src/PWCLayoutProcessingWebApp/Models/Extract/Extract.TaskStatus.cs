using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract;
public class ExtractTaskStatus : IExtractObjects
{
    /// <summary>
    /// Gets or sets the task status id.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "TaskStatusId")]
    [ModelViewColumn(DisplayName = "TaskStatusId", ToDisplay = true)]
    public int TaskStatusId { get; set; }

    /// <summary>
    /// Gets or sets the task status code.
    /// </summary>
    [JsonProperty(PropertyName = "TaskStatusCode")]
    [ModelViewColumn(DisplayName = "TaskStatusCode", ToDisplay = true)]
    public string TaskStatusCode { get; set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtractTaskStatus"/> class.
    /// </summary>
    public ExtractTaskStatus()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtractTaskStatus"/> class.
    /// </summary>
    /// <param name="codeId">The code id.</param>
    /// <param name="codeName">The code name.</param>
    public ExtractTaskStatus(int codeId, string codeName)
    {
        TaskStatusId = codeId;
        TaskStatusCode = codeName;
    }

    /// <summary>
    /// Maps the Entity.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>An ExtractTaskStatus.</returns>
    public static ExtractTaskStatus Map(ETL.TaskStatus item) => new ExtractTaskStatus
    {
        TaskStatusId = item.TaskStatusId,
        TaskStatusCode = item.TaskStatusCode,
    };
}