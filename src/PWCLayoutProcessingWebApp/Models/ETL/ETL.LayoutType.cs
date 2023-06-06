using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.ETL;
public class LayoutType : LayoutProcessingObjects
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
    /// Gets or sets the engine program.
    /// </summary>
    public EngineProgram? EngineProgram { get; set; }

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
    /// Gets or sets the damage code.
    /// </summary>
    public DamageCode? DamageCode { get; set; }

    /// <summary>
    /// Gets or sets the cause code id.
    /// </summary>
    [ModelViewColumn(DisplayName = "CauseCodeId", ToDisplay = true)]
    public int CauseCodeId { get; set; }

    /// <summary>
    /// Gets or sets the cause code.
    /// </summary>
    public CauseCode? CauseCode { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LayoutType"/> class.
    /// </summary>
    public LayoutType()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="LayoutType"/> class.
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

    /// <summary>
    /// Maps the Entity.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <returns>A LayoutType.</returns>
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