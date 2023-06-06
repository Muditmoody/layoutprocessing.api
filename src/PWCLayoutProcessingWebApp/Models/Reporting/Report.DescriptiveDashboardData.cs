using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Reporting
{
    /// <summary>
    /// Dashboard data class model
    /// </summary>
    public class DescriptiveDashboardData : IReportObjects
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "Id")]
        [ModelViewColumn(DisplayName = "Id", ToDisplay = true)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the notification.
        /// </summary>
        [JsonProperty(PropertyName = "Notification")]
        [ModelViewColumn(DisplayName = "Notification", ToDisplay = true)]
        public string Notification { get; set; }

        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        [JsonProperty(PropertyName = "Item")]
        [ModelViewColumn(DisplayName = "Item", ToDisplay = true)]
        public int Item { get; set; }

        /// <summary>
        /// Gets or sets the task.
        /// </summary>
        [JsonProperty(PropertyName = "Task")]
        [ModelViewColumn(DisplayName = "Task", ToDisplay = true)]
        public int Task { get; set; }

        /// <summary>
        /// Gets or sets the material.
        /// </summary>
        [JsonProperty(PropertyName = "Material")]
        [ModelViewColumn(DisplayName = "Material", ToDisplay = true)]
        public string Material { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        [JsonProperty(PropertyName = "Created_On")]
        [ModelViewColumn(DisplayName = "Created_On", ToDisplay = true)]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [JsonProperty(PropertyName = "Description")]
        [ModelViewColumn(DisplayName = "Description", ToDisplay = true)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        [JsonProperty(PropertyName = "Category")]
        [ModelViewColumn(DisplayName = "Category", ToDisplay = true)]
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the completed date.
        /// </summary>
        [JsonProperty(PropertyName = "Completed_On")]
        [ModelViewColumn(DisplayName = "Completed_On", ToDisplay = true)]
        public DateTime? CompletedDate { get; set; }

        /// <summary>
        /// Gets or sets the task text.
        /// </summary>
        [JsonProperty(PropertyName = "Task_Text")]
        [ModelViewColumn(DisplayName = "Task_Text", ToDisplay = true)]
        public string TaskText { get; set; }

        /// <summary>
        /// Gets or sets the code group.
        /// </summary>
        [JsonProperty(PropertyName = "Code_Group")]
        [ModelViewColumn(DisplayName = "Code_Group", ToDisplay = true)]
        public string CodeGroup { get; set; }

        /// <summary>
        /// Gets or sets the code group text.
        /// </summary>
        [JsonProperty(PropertyName = "Task_Group_Text")]
        [ModelViewColumn(DisplayName = "Task_Group_Text", ToDisplay = true)]
        public string CodeGroupText { get; set; }

        /// <summary>
        /// Gets or sets the task code.
        /// </summary>
        [JsonProperty(PropertyName = "Task_Code")]
        [ModelViewColumn(DisplayName = "Task_Code", ToDisplay = true)]
        public string TaskCode { get; set; }

        /// <summary>
        /// Gets or sets the task code text.
        /// </summary>
        [JsonProperty(PropertyName = "Task_Code_Text")]
        [ModelViewColumn(DisplayName = "Task_Code_Text", ToDisplay = true)]
        public string TaskCodeText { get; set; }

        /// <summary>
        /// Gets or sets the planned start.
        /// </summary>
        [JsonProperty(PropertyName = "Task_Planned_Start")]
        [ModelViewColumn(DisplayName = "Task_Planned_Start", ToDisplay = true)]
        public DateTime? PlannedStart { get; set; }

        /// <summary>
        /// Gets or sets the planned finish.
        /// </summary>
        [JsonProperty(PropertyName = "Task_Planned_Finish")]
        [ModelViewColumn(DisplayName = "Task_Planned_Finish", ToDisplay = true)]
        public DateTime? PlannedFinish { get; set; }

        /// <summary>
        /// Gets or sets the supplier vendor code.
        /// </summary>
        [JsonProperty(PropertyName = "Supplier_Vendor")]
        [ModelViewColumn(DisplayName = "Supplier_Vendor", ToDisplay = true)]
        public string SupplierVendorCode { get; set; }

        /// <summary>
        /// Gets or sets the task owner code.
        /// </summary>
        [JsonProperty(PropertyName = "Task_Owner")]
        [ModelViewColumn(DisplayName = "Task_Owner", ToDisplay = true)]
        public string TaskOwnerCode { get; set; }

        /// <summary>
        /// Gets or sets the task status code.
        /// </summary>
        [JsonProperty(PropertyName = "Task_Status")]
        [ModelViewColumn(DisplayName = "Task_Status", ToDisplay = true)]
        public string TaskStatusCode { get; set; }

        /// <summary>
        /// Gets or sets the coding code id.
        /// </summary>
        [JsonProperty(PropertyName = "Coding")]
        [ModelViewColumn(DisplayName = "Coding", ToDisplay = true)]
        public int CodingCodeId { get; set; }

        /// <summary>
        /// Gets or sets the coding code.
        /// </summary>
        [JsonProperty(PropertyName = "Coding")]
        [ModelViewColumn(DisplayName = "Coding", ToDisplay = true)]
        public ETL.CodingCode? CodingCode { get; set; }

        /// <summary>
        /// Gets or sets the engine program code.
        /// </summary>
        [JsonProperty(PropertyName = "Engine")]
        [ModelViewColumn(DisplayName = "Engine", ToDisplay = true)]
        public string EngineProgramCode { get; set; }

        /// <summary>
        /// Gets or sets the damage code.
        /// </summary>
        [JsonProperty(PropertyName = "Damage_Code")]
        [ModelViewColumn(DisplayName = "Damage_Code", ToDisplay = true)]
        public string DamageCode { get; set; }

        /// <summary>
        /// Gets or sets the cause code.
        /// </summary>
        [JsonProperty(PropertyName = "Cause_Code")]
        [ModelViewColumn(DisplayName = "Cause_Code", ToDisplay = true)]
        public string CauseCode { get; set; }

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
        /// Initializes a new instance of the <see cref="DescriptiveDashboardData"/> class.
        /// </summary>
        public DescriptiveDashboardData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DescriptiveDashboardData"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="notification">The notification.</param>
        /// <param name="item">The item.</param>
        /// <param name="task">The task.</param>
        /// <param name="material">The material.</param>
        /// <param name="createdDate">The created date.</param>
        /// <param name="description">The description.</param>
        /// <param name="category">The category.</param>
        /// <param name="completedDate">The completed date.</param>
        /// <param name="taskText">The task text.</param>
        /// <param name="codeGroup">The code group.</param>
        /// <param name="codeGroupText">The code group text.</param>
        /// <param name="taskCode">The task code.</param>
        /// <param name="taskCodeText">The task code text.</param>
        /// <param name="plannedStart">The planned start.</param>
        /// <param name="plannedFinish">The planned finish.</param>
        /// <param name="supplierVendorCode">The supplier vendor code.</param>
        /// <param name="taskOwnerCode">The task owner code.</param>
        /// <param name="taskStatusCode">The task status code.</param>
        /// <param name="codingCode">The coding code.</param>
        /// <param name="engineProgramCode">The engine program code.</param>
        /// <param name="damageCode">The damage code.</param>
        /// <param name="causeCode">The cause code.</param>
        /// <param name="isTaskCompleted">If true, is task completed.</param>
        /// <param name="isItemCompleted">If true, is item completed.</param>
        /// <param name="isTurnback">If true, is turnback.</param>
        /// <param name="isLife">If true, is life.</param>
        public DescriptiveDashboardData(int id, string notification, int item, int task, string material, DateTime createdDate, string description,
            string category, DateTime completedDate, string taskText, string codeGroup, string codeGroupText, string taskCode, string taskCodeText,
            DateTime plannedStart, DateTime plannedFinish, string supplierVendorCode, string taskOwnerCode, string taskStatusCode, ETL.CodingCode codingCode,
            string engineProgramCode, string damageCode, string causeCode, bool isTaskCompleted, bool isItemCompleted, bool isTurnback, bool isLife)
        {
            Id = id;
            Notification = notification;
            Item = item;
            Task = task;
            Material = material;
            CreatedDate = createdDate;
            Description = description;
            Category = category;
            CompletedDate = completedDate;
            TaskText = taskText;
            CodeGroup = codeGroup;
            CodeGroupText = codeGroupText;
            TaskCode = taskCode;
            TaskCodeText = taskCodeText;
            PlannedStart = plannedStart;
            PlannedFinish = plannedFinish;
            SupplierVendorCode = supplierVendorCode;
            TaskOwnerCode = taskOwnerCode;
            TaskStatusCode = taskStatusCode;
            CodingCode = codingCode;
            EngineProgramCode = engineProgramCode;
            DamageCode = damageCode;
            CauseCode = causeCode;
            IsTaskCompleted = isTaskCompleted;
            IsItemCompleted = isItemCompleted;
            IsTurnback = isTurnback;
            IsLife = isLife;
        }

        /// <summary>
        /// Maps the Entity.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>A DescriptiveDashboardData.</returns>
        public static DescriptiveDashboardData Map(Model.CleanModelInput input) => new DescriptiveDashboardData
        {
            Id = input.Id,
            Category = input.Category,
            CauseCode = input.CauseCode,
            CodingCode = input.CodingCode,
            CodeGroup = input.GroupCode,
            CodingCodeId = input.CodingCodeId,
            CompletedDate = input.CompletedDate,
            TaskText = input.TaskText,
            CreatedDate = input.CreatedDate,
            DamageCode = input.DamageCode,
            EngineProgramCode = input.EngineProgram,
            IsItemCompleted = input.IsItemCompleted,
            IsTurnback = input.IsTurnback,
            IsLife = input.IsLife,
            IsTaskCompleted = input.IsTaskCompleted,
            Item = input.ItemNumber,
            Material = input.MaterialCode,
            CodeGroupText = "",
            Description = "",
            Notification = input.NotificationCode,
            PlannedFinish = input.PlannedFinish,
            PlannedStart = input.PlannedStart,
            SupplierVendorCode = input.SupplierVendorCode,
            Task = input.TaskNumber,
            TaskCode = input.TaskCode,
            TaskCodeText = input.TaskCodeText,
            TaskOwnerCode = input.TaskOwnerCode,
            TaskStatusCode = input.TaskStatusCode
        };
    }
}