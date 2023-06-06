using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.ETL;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract
{
#nullable enable

    public class ExtractTaskDurationPrediction : IExtractObjects
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "Id")]
        [ModelViewColumn(DisplayName = "Id", ToDisplay = true)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the model data input id.
        /// </summary>
        [JsonProperty(PropertyName = "ModelDataInputId")]
        [ModelViewColumn(DisplayName = "ModelDataInputId", ToDisplay = true)]
        public int ModelDataInputId { get; set; }

        /// <summary>
        /// Gets or sets the prediction result.
        /// </summary>
        [JsonProperty(PropertyName = "PredictionResult")]
        [ModelViewColumn(DisplayName = "PredictionResult", ToDisplay = true)]
        public double PredictionResult { get; set; }

        /// <summary>
        /// Gets or sets the run date.
        /// </summary>
        [JsonProperty(PropertyName = "RunDate")]
        [ModelViewColumn(DisplayName = "RunDate", ToDisplay = true)]
        public DateTime RunDate { get; set; }

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
        /// Initializes a new instance of the <see cref="ExtractTaskDurationPrediction"/> class.
        /// </summary>
        public ExtractTaskDurationPrediction()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractTaskDurationPrediction"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="modelDataInputId">The model data input id.</param>
        /// <param name="predictionResult">The prediction result.</param>
        /// <param name="runDate">The run date.</param>
        /// <param name="item">The item.</param>
        public ExtractTaskDurationPrediction(int id, int modelDataInputId, double predictionResult, DateTime runDate, ExtractCleanModelInput item)
        {
            Id = id;
            ModelDataInputId = modelDataInputId;
            RunDate = runDate;
            PredictionResult = predictionResult;
            NotificationCode = item.NotificationCode;
        }

        /// <summary>
        /// Maps the Entity.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>An ExtractTaskDurationPrediction.</returns>
        public static ExtractTaskDurationPrediction Map(Model.TaskDurationPrediction item) => new ExtractTaskDurationPrediction
        {
            Id = item.Id,
            ModelDataInputId = item.ModelDataInputId,
            RunDate = item.RunDate,
            PredictionResult = item.PredictionResult,
            NotificationCode = item.ModelDataInput.NotificationCode,
            Available = item.ModelDataInput.Available,
            Category = item.ModelDataInput.Category,
            CategoryId = item.ModelDataInput.CategoryId,
            CauseCode = item.ModelDataInput.CauseCode,
            CauseCodeId = item.ModelDataInput.CauseCodeId,
            CodingCode = item.ModelDataInput.CodingCode,
            CodingCodeId = item.ModelDataInput.CodingCodeId,
            CompletedDate = item.ModelDataInput.CompletedDate,
            CreatedDate = item.ModelDataInput.CreatedDate,
            DamageCode = item.ModelDataInput.DamageCode,
            DamageCodeId = item.ModelDataInput.DamageCodeId,
            EngineProgram = item.ModelDataInput.EngineProgram,
            GeneralCode = item.ModelDataInput.GeneralCode,
            GroupCode = item.ModelDataInput.GroupCode,
            GroupCodeId = item.ModelDataInput.GroupCodeId,
            IsItemCompleted = item.ModelDataInput.IsItemCompleted,
            IsLife = item.ModelDataInput.IsLife,
            IsPlanning = item.ModelDataInput.IsPlanning,
            IsTaskCompleted = item.ModelDataInput.IsTaskCompleted,
            IsTurnback = item.ModelDataInput.IsTurnback,
            ItemNumber = item.ModelDataInput.ItemNumber,
            LayoutTaskId = item.ModelDataInput.LayoutTaskId,
            MaterialCode = item.ModelDataInput.MaterialCode,
            PlannedFinish = item.ModelDataInput.PlannedFinish,
            PlannedStart = item.ModelDataInput.PlannedStart,
            SupplierVendorCode = item.ModelDataInput.SupplierVendorCode,
            SupplierVendorId = item.ModelDataInput.SupplierVendorId,
            TaskCode = item.ModelDataInput.TaskCode,
            TaskCodeId = item.ModelDataInput.TaskCodeId,
            TaskCodeText = item.ModelDataInput.TaskCodeText,
            TaskNumber = item.ModelDataInput.TaskNumber,
            TaskOwnerCode = item.ModelDataInput.TaskOwnerCode,
            TaskOwnerId = item.ModelDataInput.TaskOwnerId,
            TaskStatusCode = item.ModelDataInput.TaskStatusCode,
            TaskStatusId = item.ModelDataInput.TaskStatusId,
            TaskText = item.ModelDataInput.TaskText
        };
    }
}