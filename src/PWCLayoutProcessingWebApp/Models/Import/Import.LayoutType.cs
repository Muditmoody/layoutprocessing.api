using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Import;
public class ImportLayoutType : IImportObjects
{
    /// <summary>
    /// Gets or sets the layout type id.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "LayoutTypeId")]
    [ModelViewColumn(DisplayName = "LayoutTypeId", ToDisplay = true)]
    public int LayoutTypeId { get; set; }

    /// <summary>
    /// Gets or sets the notification id.
    /// </summary>
    [ModelViewColumn(DisplayName = "NotificationId", ToDisplay = true)]
    public int NotificationId { get; set; }

    /// <summary>
    /// Gets or sets the engine program notification code.
    /// </summary>
    public string EngineProgramNotificationCode { get; set; }

    /// <summary>
    /// Gets or sets the item number.
    /// </summary>
    [ModelViewColumn(DisplayName = "ItemNumber", ToDisplay = true)]
    public string ItemNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the layout text.
    /// </summary>
    [ModelViewColumn(DisplayName = "LayoutText", ToDisplay = true)]
    public string LayoutText { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the damage code id.
    /// </summary>
    [ModelViewColumn(DisplayName = "DamageCodeId", ToDisplay = true)]
    public int DamageCodeId { get; set; }

    /// <summary>
    /// Gets or sets the damage code name.
    /// </summary>
    public string DamageCodeName { get; set; }

    /// <summary>
    /// Gets or sets the cause code id.
    /// </summary>
    [ModelViewColumn(DisplayName = "CauseCodeId", ToDisplay = true)]
    public int CauseCodeId { get; set; }

    /// <summary>
    /// Gets or sets the cause code name.
    /// </summary>
    public string CauseCodeName { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ImportLayoutType"/> class.
    /// </summary>
    public ImportLayoutType()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ImportLayoutType"/> class.
    /// </summary>
    /// <param name="layoutTypeId">The layout type id.</param>
    /// <param name="notificationId">The notification id.</param>
    /// <param name="engineProgramNotificationCode">The engine program notification code.</param>
    /// <param name="itemNumber">The item number.</param>
    /// <param name="layoutText">The layout text.</param>
    /// <param name="damageCodeId">The damage code id.</param>
    /// <param name="damageCodeName">The damage code name.</param>
    /// <param name="causeCodeId">The cause code id.</param>
    /// <param name="causeCodeName">The cause code name.</param>
    public ImportLayoutType(int layoutTypeId, int notificationId, string engineProgramNotificationCode,
        string itemNumber, string layoutText, int damageCodeId, string damageCodeName, int causeCodeId, string causeCodeName)
    {
        LayoutTypeId = layoutTypeId;
        NotificationId = notificationId;
        EngineProgramNotificationCode = engineProgramNotificationCode;
        ItemNumber = itemNumber;
        LayoutText = layoutText;
        DamageCodeId = damageCodeId;
        DamageCodeName = damageCodeName;
        CauseCodeId = causeCodeId;
        CauseCodeName = causeCodeName;
    }
}