using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Import;
public class ImportLayoutType : IImportObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "LayoutTypeId")]
    [ModelViewColumn(DisplayName = "LayoutTypeId", ToDisplay = true)]
    public int LayoutTypeId { get; set; }

    [ModelViewColumn(DisplayName = "NotificationId", ToDisplay = true)]
    public int NotificationId { get; set; }

    public string EngineProgramNotificationCode { get; set; }

    [ModelViewColumn(DisplayName = "ItemNumber", ToDisplay = true)]
    public string ItemNumber { get; set; } = string.Empty;

    [ModelViewColumn(DisplayName = "LayoutText", ToDisplay = true)]
    public string LayoutText { get; set; } = string.Empty;

    [ModelViewColumn(DisplayName = "DamageCodeId", ToDisplay = true)]
    public int DamageCodeId { get; set; }

    public string DamageCodeName { get; set; }

    [ModelViewColumn(DisplayName = "CauseCodeId", ToDisplay = true)]
    public int CauseCodeId { get; set; }

    public string CauseCodeName { get; set; }

    public ImportLayoutType()
    { }

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