using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract;
public class ExtractLayoutType : IExtractObjects
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
    [JsonProperty(PropertyName = "NotificationId")]
    [ModelViewColumn(DisplayName = "NotificationId", ToDisplay = true)]
    public int NotificationId { get; set; }

    /// <summary>
    /// Gets or sets the engine program description.
    /// </summary>
    [JsonProperty(PropertyName = "EngineProgramDescription")]
    public string EngineProgramDescription { get; set; }

    /// <summary>
    /// Gets or sets the item number.
    /// </summary>
    [JsonProperty(PropertyName = "ItemNumber")]
    [ModelViewColumn(DisplayName = "ItemNumber", ToDisplay = true)]
    public string ItemNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the layout text.
    /// </summary>
    [JsonProperty(PropertyName = "LayoutText")]
    [ModelViewColumn(DisplayName = "LayoutText", ToDisplay = true)]
    public string LayoutText { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the damage code id.
    /// </summary>
    [JsonProperty(PropertyName = "DamageCodeId")]
    [ModelViewColumn(DisplayName = "DamageCodeId", ToDisplay = true)]
    public int DamageCodeId { get; set; }

    /// <summary>
    /// Gets or sets the damage code name.
    /// </summary>
    [JsonProperty(PropertyName = "DamageCodeName")]
    public string DamageCodeName { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets the cause code id.
    /// </summary>
    [JsonProperty(PropertyName = "CauseCodeId")]
    [ModelViewColumn(DisplayName = "CauseCodeId", ToDisplay = true)]
    public int CauseCodeId { get; set; }

    /// <summary>
    /// Gets or sets the cause code name.
    /// </summary>
    [JsonProperty(PropertyName = "CauseCodeName")]
    public string CauseCodeName { get; set; } = String.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtractLayoutType"/> class.
    /// </summary>
    public ExtractLayoutType()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtractLayoutType"/> class.
    /// </summary>
    /// <param name="layoutTypeId">The layout type id.</param>
    /// <param name="notificationId">The notification id.</param>
    /// <param name="engineProgram">The engine program.</param>
    /// <param name="itemNumber">The item number.</param>
    /// <param name="layoutText">The layout text.</param>
    /// <param name="damageCodeId">The damage code id.</param>
    /// <param name="damageCode">The damage code.</param>
    /// <param name="causeCodeId">The cause code id.</param>
    /// <param name="causeCode">The cause code.</param>
    public ExtractLayoutType(int layoutTypeId, int notificationId, ExtractEngineProgram? engineProgram,
        string itemNumber, string layoutText, int damageCodeId, ExtractDamageCode? damageCode, int causeCodeId, ExtractCauseCode? causeCode)
    {
        LayoutTypeId = layoutTypeId;
        NotificationId = notificationId;
        EngineProgramDescription = engineProgram?.Description;
        ItemNumber = itemNumber;
        LayoutText = layoutText;
        DamageCodeId = damageCodeId;
        DamageCodeName = damageCode?.DamageCodeName;
        CauseCodeId = causeCodeId;
        CauseCodeName = causeCode?.CauseCodeName;
    }

    /// <summary>
    /// Maps the Entity.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>An ExtractLayoutType.</returns>
    public static ExtractLayoutType Map(ETL.LayoutType item) => new ExtractLayoutType
    {
        LayoutTypeId = item.LayoutTypeId,
        NotificationId = item.NotificationId,
        EngineProgramDescription = item?.EngineProgram?.Description,
        ItemNumber = item.ItemNumber,
        LayoutText = item.LayoutText,
        DamageCodeId = item.DamageCodeId,
        DamageCodeName = item.DamageCode.DamageCodeName,
        CauseCodeId = item.CauseCodeId,
        CauseCodeName = item.CauseCode.CauseCodeName
    };
}