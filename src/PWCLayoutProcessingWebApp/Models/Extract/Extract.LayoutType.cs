using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract;
public class ExtractLayoutType : IExtractObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "LayoutTypeId")]
    [ModelViewColumn(DisplayName = "LayoutTypeId", ToDisplay = true)]
    public int LayoutTypeId { get; set; }

    [JsonProperty(PropertyName = "NotificationId")]
    [ModelViewColumn(DisplayName = "NotificationId", ToDisplay = true)]
    public int NotificationId { get; set; }

    [JsonProperty(PropertyName = "EngineProgramDescription")]
    public string EngineProgramDescription { get; set; }

    [JsonProperty(PropertyName = "ItemNumber")]
    [ModelViewColumn(DisplayName = "ItemNumber", ToDisplay = true)]
    public string ItemNumber { get; set; } = string.Empty;

    [JsonProperty(PropertyName = "LayoutText")]
    [ModelViewColumn(DisplayName = "LayoutText", ToDisplay = true)]
    public string LayoutText { get; set; } = string.Empty;

    [JsonProperty(PropertyName = "DamageCodeId")]
    [ModelViewColumn(DisplayName = "DamageCodeId", ToDisplay = true)]
    public int DamageCodeId { get; set; }

    [JsonProperty(PropertyName = "DamageCodeName")]
    public string DamageCodeName { get; set; } = String.Empty;

    [JsonProperty(PropertyName = "CauseCodeId")]
    [ModelViewColumn(DisplayName = "CauseCodeId", ToDisplay = true)]
    public int CauseCodeId { get; set; }

    [JsonProperty(PropertyName = "CauseCodeName")]
    public string CauseCodeName { get; set; } = String.Empty;

    public ExtractLayoutType()
    { }

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