using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract;
public class ExtractLayoutProcessingTask : IExtractObjects
{
#nullable enable

    /// <summary>
    /// Gets or sets the layout task id.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "LayoutTaskId")]
    [ModelViewColumn(DisplayName = "LayoutTaskId", ToDisplay = true)]
    public int LayoutTaskId { get; set; }               // PK in Processing Task table - Unique identifier for records

    /// <summary>
    /// Gets or sets the task id.
    /// </summary>
    [JsonProperty(PropertyName = "TaskId")]
    [ModelViewColumn(DisplayName = "TaskId", ToDisplay = true)]
    public string TaskId { get; set; }                    // Task Id we received from clients

    /// <summary>
    /// Gets or sets the layout id.
    /// </summary>
    [JsonProperty(PropertyName = "LayoutId")]
    [ModelViewColumn(DisplayName = "LayoutId", ToDisplay = true)]
    public int LayoutId { get; set; }                   // PK in LayoutType Task table - Unique identifier for records

    /// <summary>
    /// Gets or sets the item number.
    /// </summary>
    [JsonProperty(PropertyName = "ItemNumber")]
    [ModelViewColumn(DisplayName = "ItemNumber", ToDisplay = true)]
    public string ItemNumber { get; set; }                // Item Number we received from clients

    /// <summary>
    /// Gets or sets the notification id.
    /// </summary>
    [JsonProperty(PropertyName = "NotificationId")]
    [ModelViewColumn(DisplayName = "NotificationId", ToDisplay = true)]
    public int NotificationId { get; set; }                 // PK in Engine program table

    /// <summary>
    /// Gets or sets the notification code.
    /// </summary>
    [JsonProperty(PropertyName = "NotificationCode")]
    [ModelViewColumn(DisplayName = "NotificationCode", ToDisplay = true)]
    public string NotificationCode { get; set; }            // Notification Id we received from clients

    /// <summary>
    /// Gets or sets the category id.
    /// </summary>
    [JsonProperty(PropertyName = "CategoryId")]
    [ModelViewColumn(DisplayName = "CategoryId", ToDisplay = true)]
    public int CategoryId { get; set; }                 // PK in Engine program table

    /// <summary>
    /// Gets or sets the damage code id.
    /// </summary>
    [JsonProperty(PropertyName = "DamageCodeId")]
    [ModelViewColumn(DisplayName = "DamageCodeId", ToDisplay = true)]
    public int DamageCodeId { get; set; }

    /// <summary>
    /// Gets or sets the cause code id.
    /// </summary>
    [JsonProperty(PropertyName = "CauseCodeId")]
    [ModelViewColumn(DisplayName = "CauseCodeId", ToDisplay = true)]
    public int CauseCodeId { get; set; }

    /// <summary>
    /// Gets or sets the coding code id.
    /// </summary>
    [JsonProperty(PropertyName = "CodingCodeId")]
    [ModelViewColumn(DisplayName = "CodingCodeId", ToDisplay = true)]
    public int CodingCodeId { get; set; }

    /// <summary>
    /// Gets or sets the material id.
    /// </summary>
    [JsonProperty(PropertyName = "MaterialId")]
    [ModelViewColumn(DisplayName = "MaterialId", ToDisplay = true)]
    public int MaterialId { get; set; }

    /// <summary>
    /// Gets or sets the material code.
    /// </summary>
    [JsonProperty(PropertyName = "MaterialCode")]
    public string MaterialCode { get; set; }

    /// <summary>
    /// Gets or sets the created on.
    /// </summary>
    [JsonProperty(PropertyName = "CreatedOn")]
    [ModelViewColumn(DisplayName = "CreatedOn", ToDisplay = true)]
    public DateTime? CreatedOn { get; set; }

    /// <summary>
    /// Gets or sets the completed on.
    /// </summary>
    [JsonProperty(PropertyName = "CompletedOn")]
    [ModelViewColumn(DisplayName = "CompletedOn", ToDisplay = true)]
    public DateTime? CompletedOn { get; set; }

    /// <summary>
    /// Gets or sets the task text.
    /// </summary>
    [JsonProperty(PropertyName = "TaskText")]
    [ModelViewColumn(DisplayName = "TaskText", ToDisplay = true)]
    public string TaskText { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the task code id.
    /// </summary>
    [JsonProperty(PropertyName = "TaskCodeId")]
    [ModelViewColumn(DisplayName = "TaskCodeId", ToDisplay = true)]
    public int TaskCodeId { get; set; }

    /// <summary>
    /// Gets or sets the code group id.
    /// </summary>
    [JsonProperty(PropertyName = "CodeGroupId")]
    [ModelViewColumn(DisplayName = "CodeGroupId", ToDisplay = true)]
    public int CodeGroupId { get; set; }

    /// <summary>
    /// Gets or sets the planned start.
    /// </summary>
    [JsonProperty(PropertyName = "PlannedStart")]
    [ModelViewColumn(DisplayName = "PlannedStart", ToDisplay = true)]
    public DateTime? PlannedStart { get; set; }

    /// <summary>
    /// Gets or sets the planned finish.
    /// </summary>
    [JsonProperty(PropertyName = "PlannedFinish")]
    [ModelViewColumn(DisplayName = "PlannedFinish", ToDisplay = true)]
    public DateTime? PlannedFinish { get; set; }

    /// <summary>
    /// Gets or sets the supplier vendor id.
    /// </summary>
    [JsonProperty(PropertyName = "SupplierVendorId")]
    [ModelViewColumn(DisplayName = "SupplierVendorId", ToDisplay = true)]
    public int SupplierVendorId { get; set; }

    /// <summary>
    /// Gets or sets the task owner id.
    /// </summary>
    [JsonProperty(PropertyName = "TaskOwnerId")]
    [ModelViewColumn(DisplayName = "TaskOwnerId", ToDisplay = true)]
    public int TaskOwnerId { get; set; }

    /// <summary>
    /// Gets or sets the task status id.
    /// </summary>
    [JsonProperty(PropertyName = "TaskStatusId")]
    [ModelViewColumn(DisplayName = "TaskStatusId", ToDisplay = true)]
    public int TaskStatusId { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtractLayoutProcessingTask"/> class.
    /// </summary>
    public ExtractLayoutProcessingTask()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtractLayoutProcessingTask"/> class.
    /// </summary>
    /// <param name="layoutTaskId">The layout task id.</param>
    /// <param name="taskId">The task id.</param>
    /// <param name="layoutId">The layout id.</param>
    /// <param name="itemNumber">The item number.</param>
    /// <param name="notificationId">The notification id.</param>
    /// <param name="notificationCode">The notification code.</param>
    /// <param name="materialId">The material id.</param>
    /// <param name="materialCode">The material code.</param>
    /// <param name="createdOn">The created on.</param>
    /// <param name="completedOn">The completed on.</param>
    /// <param name="taskText">The task text.</param>
    /// <param name="taskCodeId">The task code id.</param>
    /// <param name="codeGroupId">The code group id.</param>
    /// <param name="plannedStart">The planned start.</param>
    /// <param name="plannedFinish">The planned finish.</param>
    /// <param name="supplierVendorId">The supplier vendor id.</param>
    /// <param name="supplierVendorCode">The supplier vendor code.</param>
    /// <param name="taskOwnerId">The task owner id.</param>
    /// <param name="taskOwnerCode">The task owner code.</param>
    /// <param name="taskStatusId">The task status id.</param>
    /// <param name="taskStatusCode">The task status code.</param>
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

    /// <summary>
    /// Maps the Entity.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>An ExtractLayoutProcessingTask.</returns>
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
}