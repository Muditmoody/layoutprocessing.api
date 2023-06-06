using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.ETL;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Model
{
    /// <summary>
    /// Clean model input class model
    /// </summary>
    public class CleanModelInput : IModelObjects
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "Id")]
        [ModelViewColumn(DisplayName = "Id", ToDisplay = true)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the notification code.
        /// </summary>
        [JsonProperty(PropertyName = "Notification")]
        [ModelViewColumn(DisplayName = "Notification", ToDisplay = true)]
        public string NotificationCode { get; set; }

        /// <summary>
        /// Gets or sets the item number.
        /// </summary>
        [JsonProperty(PropertyName = "Item")]
        [ModelViewColumn(DisplayName = "Item", ToDisplay = true)]
        public int ItemNumber { get; set; }

        /// <summary>
        /// Gets or sets the layout task id.
        /// </summary>
        [JsonProperty(PropertyName = "LayoutTaskId")]
        [ModelViewColumn(DisplayName = "LayoutTaskId", ToDisplay = true)]
        public int LayoutTaskId { get; set; }

        /// <summary>
        /// Gets or sets the task number.
        /// </summary>
        [JsonProperty(PropertyName = "Task")]
        [ModelViewColumn(DisplayName = "Task", ToDisplay = true)]
        public int TaskNumber { get; set; }

        /// <summary>
        /// Gets or sets the material code.
        /// </summary>
        [JsonProperty(PropertyName = "Material")]
        [ModelViewColumn(DisplayName = "Material", ToDisplay = true)]
        public string MaterialCode { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        [JsonProperty(PropertyName = "Created_On")]
        [ModelViewColumn(DisplayName = "Created_On", ToDisplay = true)]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the completed date.
        /// </summary>
        [JsonProperty(PropertyName = "Completed_On")]
        [ModelViewColumn(DisplayName = "Completed_On", ToDisplay = true)]
        public DateTime? CompletedDate { get; set; }

        /// <summary>
        /// Gets or sets the task text.
        /// </summary>
        [JsonProperty(PropertyName = "TaskText")]
        [ModelViewColumn(DisplayName = "TaskText", ToDisplay = true)]
        public string TaskText { get; set; }

        /// <summary>
        /// Gets or sets the task code id.
        /// </summary>
        [JsonProperty(PropertyName = "TaskCodeId")]
        [ModelViewColumn(DisplayName = "TaskCodeId", ToDisplay = true)]
        public int TaskCodeId { get; set; }

        /// <summary>
        /// Gets or sets the task code.
        /// </summary>
        [JsonProperty(PropertyName = "TaskCode")]
        [ModelViewColumn(DisplayName = "TaskCode", ToDisplay = true)]
        public string TaskCode { get; set; }

        /// <summary>
        /// Gets or sets the task code text.
        /// </summary>
        [JsonProperty(PropertyName = "TaskCodeText")]
        [ModelViewColumn(DisplayName = "TaskCodeText", ToDisplay = true)]
        public string TaskCodeText { get; set; }

        /// <summary>
        /// Gets or sets the planned start.
        /// </summary>
        [JsonProperty(PropertyName = "Planned_Start")]
        [ModelViewColumn(DisplayName = "Planned_Start", ToDisplay = true)]
        public DateTime? PlannedStart { get; set; }

        /// <summary>
        /// Gets or sets the planned finish.
        /// </summary>
        [JsonProperty(PropertyName = "Planned_Finish")]
        [ModelViewColumn(DisplayName = "Planned_Finish", ToDisplay = true)]
        public DateTime? PlannedFinish { get; set; }

        /// <summary>
        /// Gets or sets the supplier vendor id.
        /// </summary>
        [JsonProperty(PropertyName = "SupplierVendorId")]
        [ModelViewColumn(DisplayName = "SupplierVendorId", ToDisplay = true)]
        public int SupplierVendorId { get; set; }

        /// <summary>
        /// Gets or sets the supplier vendor code.
        /// </summary>
        [JsonProperty(PropertyName = "SupplierVendor")]
        [ModelViewColumn(DisplayName = "SupplierVendor", ToDisplay = true)]
        public string SupplierVendorCode { get; set; }

        /// <summary>
        /// Gets or sets the task owner id.
        /// </summary>
        [JsonProperty(PropertyName = "TaskOwnerId")]
        [ModelViewColumn(DisplayName = "TaskOwnerId", ToDisplay = true)]
        public int TaskOwnerId { get; set; }

        /// <summary>
        /// Gets or sets the task owner code.
        /// </summary>
        [JsonProperty(PropertyName = "TaskOwner")]
        [ModelViewColumn(DisplayName = "TaskOwner", ToDisplay = true)]
        public string TaskOwnerCode { get; set; }

        /// <summary>
        /// Gets or sets the task status id.
        /// </summary>
        [JsonProperty(PropertyName = "TaskStatusId")]
        [ModelViewColumn(DisplayName = "TaskStatusId", ToDisplay = true)]
        public int TaskStatusId { get; set; }

        /// <summary>
        /// Gets or sets the task status code.
        /// </summary>
        [JsonProperty(PropertyName = "TaskStatus")]
        [ModelViewColumn(DisplayName = "TaskStatus", ToDisplay = true)]
        public string TaskStatusCode { get; set; }

        /// <summary>
        /// Gets or sets the damage code id.
        /// </summary>
        [JsonProperty(PropertyName = "DamageCodeId")]
        [ModelViewColumn(DisplayName = "DamageCodeId", ToDisplay = true)]
        public int DamageCodeId { get; set; }

        /// <summary>
        /// Gets or sets the damage code.
        /// </summary>
        [JsonProperty(PropertyName = "DamageCode")]
        [ModelViewColumn(DisplayName = "DamageCode", ToDisplay = true)]
        public string DamageCode { get; set; }

        /// <summary>
        /// Gets or sets the cause code id.
        /// </summary>
        [JsonProperty(PropertyName = "CauseCodeId")]
        [ModelViewColumn(DisplayName = "CauseCodeId", ToDisplay = true)]
        public int CauseCodeId { get; set; }

        /// <summary>
        /// Gets or sets the cause code.
        /// </summary>
        [JsonProperty(PropertyName = "CauseCode")]
        [ModelViewColumn(DisplayName = "CauseCode", ToDisplay = true)]
        public string CauseCode { get; set; }

        /// <summary>
        /// Gets or sets the group code id.
        /// </summary>
        [JsonProperty(PropertyName = "GroupCodeId")]
        [ModelViewColumn(DisplayName = "GroupCodeId", ToDisplay = true)]
        public int GroupCodeId { get; set; }

        /// <summary>
        /// Gets or sets the group code.
        /// </summary>
        [JsonProperty(PropertyName = "GroupCode")]
        [ModelViewColumn(DisplayName = "GroupCode", ToDisplay = true)]
        public string GroupCode { get; set; }

        /// <summary>
        /// Gets or sets the category id.
        /// </summary>
        [JsonProperty(PropertyName = "CategoryId")]
        [ModelViewColumn(DisplayName = "CategoryId", ToDisplay = true)]
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        [JsonProperty(PropertyName = "Category")]
        [ModelViewColumn(DisplayName = "Category", ToDisplay = true)]
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the coding code id.
        /// </summary>
        [JsonProperty(PropertyName = "Coding")]
        [ModelViewColumn(DisplayName = "Coding", ToDisplay = true)]
        public int CodingCodeId { get; set; }

        /// <summary>
        /// Gets or sets the coding code.
        /// </summary>
        [JsonProperty(PropertyName = "CodingCode")]
        [ModelViewColumn(DisplayName = "Coding", ToDisplay = true)]
        public CodingCode? CodingCode { get; set; }

        /// <summary>
        /// Gets or sets the engine program.
        /// </summary>
        [JsonProperty(PropertyName = "Engine")]
        [ModelViewColumn(DisplayName = "Engine", ToDisplay = true)]
        public string EngineProgram { get; set; }

        /// <summary>
        /// Gets or sets the general code.
        /// </summary>
        [JsonProperty(PropertyName = "GeneralCode")]
        [ModelViewColumn(DisplayName = "GeneralCode", ToDisplay = true)]
        public string GeneralCode { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether task is completed.
        /// </summary>
        [JsonProperty(PropertyName = "IsTaskCompleted")]
        [ModelViewColumn(DisplayName = "IsTaskCompleted", ToDisplay = true)]
        public bool IsTaskCompleted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether item is completed.
        /// </summary>
        [JsonProperty(PropertyName = "IsItemCompleted")]
        [ModelViewColumn(DisplayName = "IsItemCompleted", ToDisplay = true)]
        public bool IsItemCompleted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is turnback.
        /// </summary>
        [JsonProperty(PropertyName = "IsTurnback")]
        [ModelViewColumn(DisplayName = "IsTurnback", ToDisplay = true)]
        public bool IsTurnback { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is life.
        /// </summary>
        [JsonProperty(PropertyName = "IsLife")]
        [ModelViewColumn(DisplayName = "IsLife", ToDisplay = true)]
        public bool IsLife { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is planning.
        /// </summary>
        [JsonProperty(PropertyName = "IsPlanning")]
        [ModelViewColumn(DisplayName = "IsPlanning", ToDisplay = true)]
        public bool IsPlanning { get; set; }

        /// <summary>
        /// Gets or sets the available.
        /// </summary>
        [JsonProperty(PropertyName = "Available")]
        [ModelViewColumn(DisplayName = "Available", ToDisplay = true)]
        public int Available { get; set; }

        /// <summary>
        /// Gets or sets the run date.
        /// </summary>
        public DateTime RunDate { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CleanModelInput"/> class.
        /// </summary>
        public CleanModelInput()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CleanModelInput"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="notificationCode">The notification code.</param>
        /// <param name="itemNumber">The item number.</param>
        /// <param name="layoutTaskId">The layout task id.</param>
        /// <param name="taskNumber">The task number.</param>
        /// <param name="materialCode">The material code.</param>
        /// <param name="createdDate">The created date.</param>
        /// <param name="completedDate">The completed date.</param>
        /// <param name="taskText">The task text.</param>
        /// <param name="taskCodeId">The task code id.</param>
        /// <param name="taskCode">The task code.</param>
        /// <param name="plannedStart">The planned start.</param>
        /// <param name="plannedFinish">The planned finish.</param>
        /// <param name="supplierVendorId">The supplier vendor id.</param>
        /// <param name="supplierVendorCode">The supplier vendor code.</param>
        /// <param name="taskOwnerId">The task owner id.</param>
        /// <param name="taskOwnerCode">The task owner code.</param>
        /// <param name="taskStatusId">The task status id.</param>
        /// <param name="taskStatusCode">The task status code.</param>
        /// <param name="damageCodeId">The damage code id.</param>
        /// <param name="damageCode">The damage code.</param>
        /// <param name="causeCodeId">The cause code id.</param>
        /// <param name="causeCode">The cause code.</param>
        /// <param name="groupCodeId">The group code id.</param>
        /// <param name="groupCode">The group code.</param>
        /// <param name="categoryId">The category id.</param>
        /// <param name="category">The category.</param>
        /// <param name="codingCodeId">The coding code id.</param>
        /// <param name="engineProgram">The engine program.</param>
        /// <param name="generalCode">The general code.</param>
        /// <param name="isTaskCompleted">If true, is task completed.</param>
        /// <param name="isItemCompleted">If true, is item completed.</param>
        /// <param name="isTurnback">If true, is turnback.</param>
        /// <param name="isLife">If true, is life.</param>
        /// <param name="isPlanning">If true, is planning.</param>
        /// <param name="available">The available.</param>
        /// <param name="runDate">The run date.</param>
        /// <param name="taskCodeText">The task code text.</param>
        public CleanModelInput(int id, string notificationCode, int itemNumber, int layoutTaskId, int taskNumber, string materialCode,
            DateTime createdDate, DateTime completedDate, string taskText, int taskCodeId, string taskCode, DateTime plannedStart, DateTime plannedFinish,
            int supplierVendorId, string supplierVendorCode, int taskOwnerId, string taskOwnerCode, int taskStatusId, string taskStatusCode, int damageCodeId,
            string damageCode, int causeCodeId, string causeCode, int groupCodeId, string groupCode, int categoryId, string category, int codingCodeId,
            string engineProgram, string generalCode, bool isTaskCompleted, bool isItemCompleted, bool isTurnback, bool isLife, bool isPlanning, int available,
            DateTime runDate, string taskCodeText)
        {
            Id = id;
            NotificationCode = notificationCode;
            ItemNumber = itemNumber;
            LayoutTaskId = layoutTaskId;
            TaskNumber = taskNumber;
            MaterialCode = materialCode;
            CreatedDate = createdDate;
            CompletedDate = completedDate;
            TaskText = taskText;
            TaskCodeId = taskCodeId;
            TaskCode = taskCode;
            PlannedStart = plannedStart;
            PlannedFinish = plannedFinish;
            SupplierVendorId = supplierVendorId;
            SupplierVendorCode = supplierVendorCode;
            TaskOwnerId = taskOwnerId;
            TaskOwnerCode = taskOwnerCode;
            TaskStatusId = taskStatusId;
            TaskStatusCode = taskStatusCode;
            DamageCodeId = damageCodeId;
            DamageCode = damageCode;
            CauseCodeId = causeCodeId;
            CauseCode = causeCode;
            GroupCodeId = groupCodeId;
            GroupCode = groupCode;
            CategoryId = categoryId;
            Category = category;
            CodingCodeId = codingCodeId;
            EngineProgram = engineProgram;
            GeneralCode = generalCode;
            IsTaskCompleted = isTaskCompleted;
            IsItemCompleted = isItemCompleted;
            IsTurnback = isTurnback;
            IsLife = isLife;
            IsPlanning = isPlanning;
            Available = available;
            RunDate = runDate;
            TaskCodeText = taskCodeText;
        }

        /// <summary>
        /// Maps the Entity.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>A CleanModelInput.</returns>
        public static CleanModelInput Map(SqlDataReader reader) => new CleanModelInput
        {
            //CodeGroupId = reader.GetFieldValue<int>(reader.GetOrdinal("Id")),
            //CodeGroupName = reader.GetFieldValue<string>(reader.GetOrdinal("GroupCode")),
            //CodeGroupText = reader.GetFieldValue<string>(reader.GetOrdinal("GroupText"))
        };
    }
}