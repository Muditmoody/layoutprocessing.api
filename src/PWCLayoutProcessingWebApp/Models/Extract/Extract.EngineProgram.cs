using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract;
public class ExtractEngineProgram : IExtractObjects
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
    [JsonProperty(PropertyName = "NotificationCode")]
    [ModelViewColumn(DisplayName = "NotificationId", ToDisplay = true)]
    public string NotificationCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    [JsonProperty(PropertyName = "Description")]
    [ModelViewColumn(DisplayName = "Description", ToDisplay = true)]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the coding code id.
    /// </summary>
    [JsonProperty(PropertyName = "CodingCodeId")]
    [ModelViewColumn(DisplayName = "CodingCodeId", ToDisplay = true)]
    public int CodingCodeId { get; set; }

    /// <summary>
    /// Gets or sets the coding code name.
    /// </summary>
    [JsonProperty(PropertyName = "CodingCodeName")]
    [ModelViewColumn(DisplayName = "CodingCodeName", ToDisplay = true)]
    public string CodingCodeName { get; set; }

    /// <summary>
    /// Gets or sets the layouts.
    /// </summary>
    [JsonIgnore]
    public ICollection<ExtractLayoutType> layouts { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtractEngineProgram"/> class.
    /// </summary>
    public ExtractEngineProgram()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtractEngineProgram"/> class.
    /// </summary>
    /// <param name="engineProgramId">The engine program id.</param>
    /// <param name="notificationId">The notification id.</param>
    /// <param name="description">The description.</param>
    /// <param name="codingCodeId">The coding code id.</param>
    /// <param name="codingCode">The coding code.</param>
    public ExtractEngineProgram(int engineProgramId, string notificationId, string description, int codingCodeId, ExtractCodingCode? codingCode)
    {
        EngineProgramId = engineProgramId;
        NotificationCode = notificationId;
        Description = description;
        CodingCodeId = codingCodeId;
        CodingCodeName = codingCode?.CodingCodeName;
    }

    /// <summary>
    /// Maps the Entity.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>An ExtractEngineProgram.</returns>
    public static ExtractEngineProgram Map(ETL.EngineProgram item) => new ExtractEngineProgram
    {
        EngineProgramId = item.EngineProgramId,
        NotificationCode = item.NotificationCode,
        Description = item.Description?.Trim(),
        CodingCodeId = item.CodingCodeId,
        CodingCodeName = item.CodingCode.CodingCodeName,
    };
}