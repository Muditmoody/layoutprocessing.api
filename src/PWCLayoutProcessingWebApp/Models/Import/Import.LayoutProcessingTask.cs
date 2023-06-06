using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Import;
public class ImportLayoutProcessingTask : IImportObjects
{
#nullable enable

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
    /// Gets or sets the engine program notification code.
    /// </summary>
    public string EngineProgramNotificationCode { get; set; }

    /// <summary>
    /// Gets or sets the item number.
    /// </summary>
    public string ItemNumber { get; set; } = string.Empty;

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
    /// Gets or sets the material code.
    /// </summary>
    public string MaterialCode { get; set; }

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
    /// Gets or sets the task code name.
    /// </summary>
    public string TaskCodeName { get; set; }

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
    /// Gets or sets the supplier vendor code.
    /// </summary>
    public string SupplierVendorCode { get; set; }

    /// <summary>
    /// Gets or sets the task owner id.
    /// </summary>
    [ModelViewColumn(DisplayName = "TaskOwnerId", ToDisplay = true)]
    public int TaskOwnerId { get; set; }

    /// <summary>
    /// Gets or sets the task owner code.
    /// </summary>
    public string TaskOwnerCode { get; set; }

    /// <summary>
    /// Gets or sets the task status id.
    /// </summary>
    [ModelViewColumn(DisplayName = "TaskStatusId", ToDisplay = true)]
    public int TaskStatusId { get; set; }

    /// <summary>
    /// Gets or sets the task status code.
    /// </summary>
    public string TaskStatusCode { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ImportLayoutProcessingTask"/> class.
    /// </summary>
    public ImportLayoutProcessingTask()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ImportLayoutProcessingTask"/> class.
    /// </summary>
    /// <param name="layoutTaskId">The layout task id.</param>
    /// <param name="layoutId">The layout id.</param>
    /// <param name="engineProgramNotificationCode">The engine program notification code.</param>
    /// <param name="itemNumber">The item number.</param>
    /// <param name="taskId">The task id.</param>
    /// <param name="materialId">The material id.</param>
    /// <param name="materialCode">The material code.</param>
    /// <param name="createdOn">The created on.</param>
    /// <param name="completedOn">The completed on.</param>
    /// <param name="taskText">The task text.</param>
    /// <param name="taskCodeId">The task code id.</param>
    /// <param name="taskCodeName">The task code name.</param>
    /// <param name="plannedStart">The planned start.</param>
    /// <param name="plannedFinish">The planned finish.</param>
    /// <param name="supplierVendorId">The supplier vendor id.</param>
    /// <param name="supplierVendorCode">The supplier vendor code.</param>
    /// <param name="taskOwnerId">The task owner id.</param>
    /// <param name="taskOwnerCode">The task owner code.</param>
    /// <param name="taskStatusId">The task status id.</param>
    /// <param name="taskStatusCode">The task status code.</param>
    public ImportLayoutProcessingTask(int layoutTaskId, int layoutId, string engineProgramNotificationCode, string itemNumber, string taskId, int materialId,
        string materialCode, DateTime? createdOn, DateTime? completedOn, string taskText, int taskCodeId, string taskCodeName, DateTime? plannedStart,
        DateTime? plannedFinish, int supplierVendorId, string supplierVendorCode, int taskOwnerId, string taskOwnerCode, int taskStatusId, string taskStatusCode)
    {
        LayoutTaskId = layoutTaskId;
        LayoutId = layoutId;
        EngineProgramNotificationCode = engineProgramNotificationCode;
        ItemNumber = itemNumber;
        TaskId = taskId;
        MaterialId = materialId;
        MaterialCode = materialCode;
        CreatedOn = createdOn;
        CompletedOn = completedOn;
        TaskText = taskText;
        TaskCodeId = taskCodeId;
        TaskCodeName = taskCodeName;
        PlannedStart = plannedStart;
        PlannedFinish = plannedFinish;
        SupplierVendorId = supplierVendorId;
        SupplierVendorCode = supplierVendorCode;
        TaskOwnerId = taskOwnerId;
        TaskOwnerCode = taskOwnerCode;
        TaskStatusId = taskStatusId;
        TaskStatusCode = taskStatusCode;
    }
}