using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.ETL;
public class LayoutProcessingTask : LayoutProcessingObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "LayoutTaskId")]
    [ModelViewColumn(DisplayName = "LayoutTaskId", ToDisplay = true)]
    public int LayoutTaskId { get; set; }

    [ModelViewColumn(DisplayName = "LayoutId", ToDisplay = true)]
    public int LayoutId { get; set; }

    public LayoutType? Layout { get; set; }

    [ModelViewColumn(DisplayName = "TaskId", ToDisplay = true)]
    public string TaskId { get; set; } = string.Empty;

    [ModelViewColumn(DisplayName = "MaterialId", ToDisplay = true)]
    public int MaterialId { get; set; }

    public Material? Material { get; set; }

    [ModelViewColumn(DisplayName = "CreatedOn", ToDisplay = true)]
    public DateTime? CreatedOn { get; set; }

    [ModelViewColumn(DisplayName = "CompletedOn", ToDisplay = true)]
    public DateTime? CompletedOn { get; set; }

    [ModelViewColumn(DisplayName = "TaskText", ToDisplay = true)]
    public string TaskText { get; set; } = string.Empty;

    [ModelViewColumn(DisplayName = "TaskCodeId", ToDisplay = true)]
    public int TaskCodeId { get; set; }

    public TaskCode? TaskCode { get; set; }

    [ModelViewColumn(DisplayName = "PlannedStart", ToDisplay = true)]
    public DateTime? PlannedStart { get; set; }

    [ModelViewColumn(DisplayName = "PlannedFinish", ToDisplay = true)]
    public DateTime? PlannedFinish { get; set; }

    [ModelViewColumn(DisplayName = "SupplierVendorId", ToDisplay = true)]
    public int SupplierVendorId { get; set; }

    public SupplierVendor? SupplierVendor { get; set; }

    [ModelViewColumn(DisplayName = "TaskOwnerId", ToDisplay = true)]
    public int TaskOwnerId { get; set; }

    public TaskOwner? TaskOwner { get; set; }

    [ModelViewColumn(DisplayName = "TaskStatusId", ToDisplay = true)]
    public int TaskStatusId { get; set; }

    public TaskStatus? TaskStatus { get; set; }

    public LayoutProcessingTask()
    { }

    public LayoutProcessingTask(int layoutTaskId, int layoutId, LayoutType? layout, string taskId, int materialId, Material? material,
        DateTime? createdOn, DateTime? completedOn, string taskText, int taskCodeId, TaskCode? taskCode,
        DateTime? plannedStart, DateTime? plannedFinish, int supplierVendorId, SupplierVendor? supplierVendor, int taskOwnerId, TaskOwner? taskOwner,
        int taskStatusId, TaskStatus? taskStatus)
    {
        LayoutTaskId = layoutTaskId;
        LayoutId = layoutId;
        Layout = layout;
        TaskId = taskId;
        MaterialId = materialId;
        Material = material;
        CreatedOn = createdOn;
        CompletedOn = completedOn;
        TaskText = taskText;
        TaskCodeId = taskCodeId;
        TaskCode = taskCode;
        PlannedStart = plannedStart;
        PlannedFinish = plannedFinish;
        SupplierVendorId = supplierVendorId;
        SupplierVendor = supplierVendor;
        TaskOwnerId = taskOwnerId;
        TaskOwner = taskOwner;
        TaskStatusId = taskStatusId;
        TaskStatus = taskStatus;
    }

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