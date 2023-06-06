using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Import;
public class ImportTaskStatus : IImportObjects
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
    [ModelViewColumn(DisplayName = "TaskStatusCode", ToDisplay = true)]
    public string TaskStatusCode { get; set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="ImportTaskStatus"/> class.
    /// </summary>
    public ImportTaskStatus()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ImportTaskStatus"/> class.
    /// </summary>
    /// <param name="codeId">The code id.</param>
    /// <param name="codeName">The code name.</param>
    public ImportTaskStatus(int codeId, string codeName)
    {
        TaskStatusId = codeId;
        TaskStatusCode = codeName;
    }
}