using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.ETL;
public class LayoutType : LayoutProcessingObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "LayoutTypeId")]
    [ModelViewColumn(DisplayName = "LayoutTypeId", ToDisplay = true)]
    public int LayoutTypeId { get; set; }

    [ModelViewColumn(DisplayName = "NotificationId", ToDisplay = true)]
    public int NotificationId { get; set; }

    public EngineProgram? EngineProgram { get; set; }

    [ModelViewColumn(DisplayName = "ItemNumber", ToDisplay = true)]
    public string ItemNumber { get; set; } = string.Empty;

    [ModelViewColumn(DisplayName = "LayoutText", ToDisplay = true)]
    public string LayoutText { get; set; } = string.Empty;

    [ModelViewColumn(DisplayName = "DamageCodeId", ToDisplay = true)]
    public int DamageCodeId { get; set; }

    public DamageCode? DamageCode { get; set; }

    [ModelViewColumn(DisplayName = "CauseCodeId", ToDisplay = true)]
    public int CauseCodeId { get; set; }

    public CauseCode? CauseCode { get; set; }

    public LayoutType()
    { }

    public LayoutType(int layoutTypeId, int notificationId, EngineProgram? engineProgram,
        string itemNumber, string layoutText, int damageCodeId, DamageCode? damageCode, int causeCodeId, CauseCode? causeCode)
    {
        LayoutTypeId = layoutTypeId;
        NotificationId = notificationId;
        EngineProgram = engineProgram;
        ItemNumber = itemNumber;
        LayoutText = layoutText;
        DamageCodeId = damageCodeId;
        DamageCode = damageCode;
        CauseCodeId = causeCodeId;
        CauseCode = causeCode;
    }

    public static LayoutType Map(SqlDataReader reader)
    {
        var causeCodeCols = new string[] { "CauseCodeId", "CauseCode", "CauseText" };
        var causeCode = default(CauseCode);

        if (reader.GetColumnSchema().All(col => causeCodeCols.Contains(col.ColumnName)))
        {
            causeCode = new CauseCode
            {
                CauseCodeId = reader.GetFieldValue<int>(reader.GetOrdinal("CauseCodeId")),
                CauseCodeName = reader.GetFieldValue<string>(reader.GetOrdinal("CauseCode")),
                CauseText = reader.GetFieldValue<string>(reader.GetOrdinal("CauseText"))
            };
        }

        var damageCodeCols = new string[] { "DamageCodeId", "DamageCode", "DamageText" };
        var damageCode = default(DamageCode);

        if (reader.GetColumnSchema().All(col => damageCodeCols.Contains(col.ColumnName)))
        {
            damageCode = new DamageCode
            {
                DamageCodeId = reader.GetFieldValue<int>(reader.GetOrdinal("DamageCodeId")),
                DamageCodeName = reader.GetFieldValue<string>(reader.GetOrdinal("DamageCode")),
                DamageCodeText = reader.GetFieldValue<string>(reader.GetOrdinal("DamageText"))
            };
        }

        var engineProgramCols = new string[] { "EngineProgramId", "Notification_Id", "Description", "CodingCode" };
        var engineProgram = default(EngineProgram);

        if (reader.GetColumnSchema().All(col => engineProgramCols.Contains(col.ColumnName)))
        {
            engineProgram = new EngineProgram
            {
                EngineProgramId = reader.GetFieldValue<int>(reader.GetOrdinal("EngineProgramId")),
                NotificationCode = reader.GetFieldValue<string>(reader.GetOrdinal("Notification_Id")),
                Description = reader.GetFieldValue<string>(reader.GetOrdinal("Description")),
                CodingCodeId = reader.GetFieldValue<int>(reader.GetOrdinal("CodingCode")),
            };
        }

        return new LayoutType
        {
            LayoutTypeId = reader.GetFieldValue<int>(reader.GetOrdinal("Id")),
            NotificationId = reader.GetFieldValue<int>(reader.GetOrdinal("Notification_Id")),
            EngineProgram = engineProgram,
            ItemNumber = reader.GetFieldValue<string>(reader.GetOrdinal("Item_Number")),
            LayoutText = reader.GetFieldValue<string>(reader.GetOrdinal("Layout_Text")),
            DamageCodeId = reader.GetFieldValue<int>(reader.GetOrdinal("DamageCode")),
            DamageCode = damageCode,
            CauseCodeId = reader.GetFieldValue<int>(reader.GetOrdinal("CauseCode")),
            CauseCode = causeCode
        };
    }
}