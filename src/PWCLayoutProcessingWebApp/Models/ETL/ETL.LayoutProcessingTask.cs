using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.ETL;
public class LayoutProcessingTask : LayoutProcessingObjects
{
    /// <summary>
    /// Gets or sets the layout task id.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "LayoutTaskId")]
    [ModelViewColumn(DisplayName = "LayoutTaskId", ToDisplay = true)]
    public int LayoutTaskId { get; set; }

    /// <summary>
    /// Gets or sets the layout id.
    /// </summary>
    [ModelViewColumn(DisplayName = "LayoutId", ToDisplay = true)]
    public int LayoutId { get; set; }

    /// <summary>
    /// Gets or sets the layout.
    /// </summary>
    public LayoutType? Layout { get; set; }

    /// <summary>
    /// Gets or sets the task id.
    /// </summary>
    [ModelViewColumn(DisplayName = "TaskId", ToDisplay = true)]
    public string TaskId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the material id.
    /// </summary>
    [ModelViewColumn(DisplayName = "MaterialId", ToDisplay = true)]
    public int MaterialId { get; set; }

    /// <summary>
    /// Gets or sets the material.
    /// </summary>
    public Material? Material { get; set; }

    /// <summary>
    /// Gets or sets the created on.
    /// </summary>
    [ModelViewColumn(DisplayName = "CreatedOn", ToDisplay = true)]
    public DateTime? CreatedOn { get; set; }

    /// <summary>
    /// Gets or sets the completed on.
    /// </summary>
    [ModelViewColumn(DisplayName = "CompletedOn", ToDisplay = true)]
    public DateTime? CompletedOn { get; set; }

    /// <summary>
    /// Gets or sets the task text.
    /// </summary>
    [ModelViewColumn(DisplayName = "TaskText", ToDisplay = true)]
    public string TaskText { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the task code id.
    /// </summary>
    [ModelViewColumn(DisplayName = "TaskCodeId", ToDisplay = true)]
    public int TaskCodeId { get; set; }

    /// <summary>
    /// Gets or sets the task code.
    /// </summary>
    public TaskCode? TaskCode { get; set; }

    /// <summary>
    /// Gets or sets the planned start.
    /// </summary>
    [ModelViewColumn(DisplayName = "PlannedStart", ToDisplay = true)]
    public DateTime? PlannedStart { get; set; }

    /// <summary>
    /// Gets or sets the planned finish.
    /// </summary>
    [ModelViewColumn(DisplayName = "PlannedFinish", ToDisplay = true)]
    public DateTime? PlannedFinish { get; set; }

    /// <summary>
    /// Gets or sets the supplier vendor id.
    /// </summary>
    [ModelViewColumn(DisplayName = "SupplierVendorId", ToDisplay = true)]
    public int SupplierVendorId { get; set; }

    /// <summary>
    /// Gets or sets the supplier vendor.
    /// </summary>
    public SupplierVendor? SupplierVendor { get; set; }

    /// <summary>
    /// Gets or sets the task owner id.
    /// </summary>
    [ModelViewColumn(DisplayName = "TaskOwnerId", ToDisplay = true)]
    public int TaskOwnerId { get; set; }

    /// <summary>
    /// Gets or sets the task owner.
    /// </summary>
    public TaskOwner? TaskOwner { get; set; }

    /// <summary>
    /// Gets or sets the task status id.
    /// </summary>
    [ModelViewColumn(DisplayName = "TaskStatusId", ToDisplay = true)]
    public int TaskStatusId { get; set; }

    /// <summary>
    /// Gets or sets the task status.
    /// </summary>
    public TaskStatus? TaskStatus { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LayoutProcessingTask"/> class.
    /// </summary>
    public LayoutProcessingTask()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="LayoutProcessingTask"/> class.
    /// </summary>
    /// <param name="layoutTaskId">The layout task id.</param>
    /// <param name="layoutId">The layout id.</param>
    /// <param name="layout">The layout.</param>
    /// <param name="taskId">The task id.</param>
    /// <param name="materialId">The material id.</param>
    /// <param name="material">The material.</param>
    /// <param name="createdOn">The created on.</param>
    /// <param name="completedOn">The completed on.</param>
    /// <param name="taskText">The task text.</param>
    /// <param name="taskCodeId">The task code id.</param>
    /// <param name="taskCode">The task code.</param>
    /// <param name="plannedStart">The planned start.</param>
    /// <param name="plannedFinish">The planned finish.</param>
    /// <param name="supplierVendorId">The supplier vendor id.</param>
    /// <param name="supplierVendor">The supplier vendor.</param>
    /// <param name="taskOwnerId">The task owner id.</param>
    /// <param name="taskOwner">The task owner.</param>
    /// <param name="taskStatusId">The task status id.</param>
    /// <param name="taskStatus">The task status.</param>
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