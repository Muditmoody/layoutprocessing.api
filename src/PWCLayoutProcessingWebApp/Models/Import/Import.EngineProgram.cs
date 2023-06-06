using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Import;
public class ImportEngineProgram : IImportObjects
{
    /// <summary>
    /// Gets or sets the engine program id.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "EngineProgramId")]
    [ModelViewColumn(DisplayName = "EngineProgramId", ToDisplay = true)]
    public int EngineProgramId { get; set; }

    /// <summary>
    /// Gets or sets the notification code.
    /// </summary>
    [ModelViewColumn(DisplayName = "NotificationId", ToDisplay = true)]
    public string NotificationCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    [ModelViewColumn(DisplayName = "Description", ToDisplay = true)]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the coding code id.
    /// </summary>
    [ModelViewColumn(DisplayName = "CodingCodeId", ToDisplay = true)]
    public int CodingCodeId { get; set; }

    /// <summary>
    /// Gets or sets the coding code name.
    /// </summary>
    public string CodingCodeName { get; set; }

    /// <summary>
    /// Gets or sets the layouts.
    /// </summary>
    [JsonIgnore]
    public ICollection<ImportLayoutType> layouts { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ImportEngineProgram"/> class.
    /// </summary>
    public ImportEngineProgram()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ImportEngineProgram"/> class.
    /// </summary>
    /// <param name="engineProgramId">The engine program id.</param>
    /// <param name="notificationId">The notification id.</param>
    /// <param name="description">The description.</param>
    /// <param name="codingCodeId">The coding code id.</param>
    /// <param name="codingCodeName">The coding code name.</param>
    public ImportEngineProgram(int engineProgramId, string notificationId, string description, int codingCodeId, string codingCodeName)
    {
        EngineProgramId = engineProgramId;
        NotificationCode = notificationId;
        Description = description;
        CodingCodeId = codingCodeId;
        CodingCodeName = codingCodeName;
    }
}