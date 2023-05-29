using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Import;
public class ImportLayoutProcessingTask : IImportObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "LayoutTaskId")]
    [ModelViewColumn(DisplayName = "LayoutTaskId", ToDisplay = true)]
    public int LayoutTaskId { get; set; }

    [ModelViewColumn(DisplayName = "LayoutId", ToDisplay = true)]
    public int LayoutId { get; set; }

    public string EngineProgramNotificationCode { get; set; }

    public string ItemNumber { get; set; } = string.Empty;

    [ModelViewColumn(DisplayName = "TaskId", ToDisplay = true)]
    public string TaskId { get; set; } = string.Empty;

    [ModelViewColumn(DisplayName = "MaterialId", ToDisplay = true)]
    public int MaterialId { get; set; }

    public string MaterialCode { get; set; }

    [ModelViewColumn(DisplayName = "CreatedOn", ToDisplay = true)]
    public DateTime? CreatedOn { get; set; }

    [ModelViewColumn(DisplayName = "CompletedOn", ToDisplay = true)]
    public DateTime? CompletedOn { get; set; }

    [ModelViewColumn(DisplayName = "TaskText", ToDisplay = true)]
    public string TaskText { get; set; } = string.Empty;

    [ModelViewColumn(DisplayName = "TaskCodeId", ToDisplay = true)]
    public int TaskCodeId { get; set; }

    public string TaskCodeName { get; set; }

    [ModelViewColumn(DisplayName = "PlannedStart", ToDisplay = true)]
    public DateTime? PlannedStart { get; set; }

    [ModelViewColumn(DisplayName = "PlannedFinish", ToDisplay = true)]
    public DateTime? PlannedFinish { get; set; }

    [ModelViewColumn(DisplayName = "SupplierVendorId", ToDisplay = true)]
    public int SupplierVendorId { get; set; }

    public string SupplierVendorCode { get; set; }

    [ModelViewColumn(DisplayName = "TaskOwnerId", ToDisplay = true)]
    public int TaskOwnerId { get; set; }

    public string TaskOwnerCode { get; set; }

    [ModelViewColumn(DisplayName = "TaskStatusId", ToDisplay = true)]
    public int TaskStatusId { get; set; }

    public string TaskStatusCode { get; set; }

    public ImportLayoutProcessingTask()
    { }

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