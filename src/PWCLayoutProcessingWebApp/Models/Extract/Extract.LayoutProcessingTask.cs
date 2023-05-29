using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract;
public class ExtractLayoutProcessingTask : IExtractObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "LayoutTaskId")]
    [ModelViewColumn(DisplayName = "LayoutTaskId", ToDisplay = true)]
    public int LayoutTaskId { get; set; }               // PK in Processing Task table - Unique identifier for records

    [JsonProperty(PropertyName = "TaskId")]
    [ModelViewColumn(DisplayName = "TaskId", ToDisplay = true)]
    public string TaskId { get; set; }                    // Task Id we received from clients

    [JsonProperty(PropertyName = "LayoutId")]
    [ModelViewColumn(DisplayName = "LayoutId", ToDisplay = true)]
    public int LayoutId { get; set; }                   // PK in LayoutType Task table - Unique identifier for records

    [JsonProperty(PropertyName = "ItemNumber")]
    [ModelViewColumn(DisplayName = "ItemNumber", ToDisplay = true)]
    public string ItemNumber { get; set; }                // Item Number we received from clients

    [JsonProperty(PropertyName = "NotificationId")]
    [ModelViewColumn(DisplayName = "NotificationId", ToDisplay = true)]
    public int NotificationId { get; set; }                 // PK in Engine program table

    [JsonProperty(PropertyName = "NotificationCode")]
    [ModelViewColumn(DisplayName = "NotificationCode", ToDisplay = true)]
    public string NotificationCode { get; set; }            // Notification Id we received from clients

    [JsonProperty(PropertyName = "CategoryId")]
    [ModelViewColumn(DisplayName = "CategoryId", ToDisplay = true)]
    public int CategoryId { get; set; }                 // PK in Engine program table

    [JsonProperty(PropertyName = "DamageCodeId")]
    [ModelViewColumn(DisplayName = "DamageCodeId", ToDisplay = true)]
    public int DamageCodeId { get; set; }

    [JsonProperty(PropertyName = "CauseCodeId")]
    [ModelViewColumn(DisplayName = "CauseCodeId", ToDisplay = true)]
    public int CauseCodeId { get; set; }

    [JsonProperty(PropertyName = "CodingCodeId")]
    [ModelViewColumn(DisplayName = "CodingCodeId", ToDisplay = true)]
    public int CodingCodeId { get; set; }

    [JsonProperty(PropertyName = "MaterialId")]
    [ModelViewColumn(DisplayName = "MaterialId", ToDisplay = true)]
    public int MaterialId { get; set; }

    [JsonProperty(PropertyName = "MaterialCode")]
    public string MaterialCode { get; set; }

    [JsonProperty(PropertyName = "CreatedOn")]
    [ModelViewColumn(DisplayName = "CreatedOn", ToDisplay = true)]
    public DateTime? CreatedOn { get; set; }

    [JsonProperty(PropertyName = "CompletedOn")]
    [ModelViewColumn(DisplayName = "CompletedOn", ToDisplay = true)]
    public DateTime? CompletedOn { get; set; }

    [JsonProperty(PropertyName = "TaskText")]
    [ModelViewColumn(DisplayName = "TaskText", ToDisplay = true)]
    public string TaskText { get; set; } = string.Empty;

    [JsonProperty(PropertyName = "TaskCodeId")]
    [ModelViewColumn(DisplayName = "TaskCodeId", ToDisplay = true)]
    public int TaskCodeId { get; set; }

    [JsonProperty(PropertyName = "CodeGroupId")]
    [ModelViewColumn(DisplayName = "CodeGroupId", ToDisplay = true)]
    public int CodeGroupId { get; set; }

    [JsonProperty(PropertyName = "PlannedStart")]
    [ModelViewColumn(DisplayName = "PlannedStart", ToDisplay = true)]
    public DateTime? PlannedStart { get; set; }

    [JsonProperty(PropertyName = "PlannedFinish")]
    [ModelViewColumn(DisplayName = "PlannedFinish", ToDisplay = true)]
    public DateTime? PlannedFinish { get; set; }

    [JsonProperty(PropertyName = "SupplierVendorId")]
    [ModelViewColumn(DisplayName = "SupplierVendorId", ToDisplay = true)]
    public int SupplierVendorId { get; set; }

    [JsonProperty(PropertyName = "TaskOwnerId")]
    [ModelViewColumn(DisplayName = "TaskOwnerId", ToDisplay = true)]
    public int TaskOwnerId { get; set; }

    [JsonProperty(PropertyName = "TaskStatusId")]
    [ModelViewColumn(DisplayName = "TaskStatusId", ToDisplay = true)]
    public int TaskStatusId { get; set; }

    public ExtractLayoutProcessingTask()
    { }

    public ExtractLayoutProcessingTask(int layoutTaskId, string taskId, int layoutId, string itemNumber, int notificationId, string notificationCode,
        int materialId, string materialCode, DateTime? createdOn, DateTime? completedOn, string taskText, int taskCodeId, int codeGroupId,
        DateTime? plannedStart, DateTime? plannedFinish, int supplierVendorId, string supplierVendorCode, int taskOwnerId, string taskOwnerCode, int taskStatusId,
        string taskStatusCode)
    {
        LayoutTaskId = layoutTaskId;
        TaskId = taskId;
        LayoutId = layoutId;
        ItemNumber = itemNumber;
        NotificationId = notificationId;
        NotificationCode = notificationCode;
        MaterialId = materialId;
        MaterialCode = materialCode;
        CreatedOn = createdOn;
        CompletedOn = completedOn;
        TaskText = taskText;
        TaskCodeId = taskCodeId;
        CodeGroupId = codeGroupId;
        PlannedStart = plannedStart;
        PlannedFinish = plannedFinish;
        SupplierVendorId = supplierVendorId;
        TaskOwnerId = taskOwnerId;
        TaskStatusId = taskStatusId;
    }

    public static ExtractLayoutProcessingTask Map(ETL.LayoutProcessingTask item) => new ExtractLayoutProcessingTask
    {
        LayoutTaskId = item.LayoutTaskId,
        LayoutId = item.LayoutId,
        TaskId = item.TaskId,
        MaterialId = item.MaterialId,
        MaterialCode = item?.Material?.MaterialCode,
        CreatedOn = item?.CreatedOn,
        CompletedOn = item?.CompletedOn,
        TaskText = item?.TaskText,
        TaskCodeId = item.TaskCodeId,
        PlannedStart = item.PlannedStart,
        PlannedFinish = item.PlannedFinish,
        SupplierVendorId = item.SupplierVendorId,
        TaskOwnerId = item.TaskOwnerId,
        TaskStatusId = item.TaskStatusId,
        ItemNumber = item?.Layout?.ItemNumber,
        NotificationId = item.Layout.NotificationId,
        NotificationCode = item?.Layout?.EngineProgram.NotificationCode,
        CauseCodeId = item.Layout.CauseCodeId,
        DamageCodeId = item.Layout.DamageCodeId,
        CodingCodeId = item.Layout.EngineProgram.CodingCodeId,
        CodeGroupId = item.TaskCode.GroupCodeId,
        CategoryId = item.Material.CategoryId
    };

    /*
    public static LayoutProcessingTask Map(SqlDataReader reader)
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
    */
}