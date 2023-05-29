using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Reporting
{
    public class DescriptiveDashboardData : IReportObjects
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "Id")]
        [ModelViewColumn(DisplayName = "Id", ToDisplay = true)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Notification")]
        [ModelViewColumn(DisplayName = "Notification", ToDisplay = true)]
        public string Notification { get; set; }

        [JsonProperty(PropertyName = "Item")]
        [ModelViewColumn(DisplayName = "Item", ToDisplay = true)]
        public int Item { get; set; }


        [JsonProperty(PropertyName = "Task")]
        [ModelViewColumn(DisplayName = "Task", ToDisplay = true)]
        public int Task { get; set; }

        [JsonProperty(PropertyName = "Material")]
        [ModelViewColumn(DisplayName = "Material", ToDisplay = true)]
        public string Material { get; set; }


        [JsonProperty(PropertyName = "Created_On")]
        [ModelViewColumn(DisplayName = "Created_On", ToDisplay = true)]
        public DateTime CreatedDate { get; set; }

        [JsonProperty(PropertyName = "Description")]
        [ModelViewColumn(DisplayName = "Description", ToDisplay = true)]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "Category")]
        [ModelViewColumn(DisplayName = "Category", ToDisplay = true)]
        public string Category { get; set; }

        [JsonProperty(PropertyName = "Completed_On")]
        [ModelViewColumn(DisplayName = "Completed_On", ToDisplay = true)]
        public DateTime? CompletedDate { get; set; }

        [JsonProperty(PropertyName = "Task_Text")]
        [ModelViewColumn(DisplayName = "Task_Text", ToDisplay = true)]
        public string TaskText { get; set; }

        [JsonProperty(PropertyName = "Code_Group")]
        [ModelViewColumn(DisplayName = "Code_Group", ToDisplay = true)]
        public string CodeGroup { get; set; }

        [JsonProperty(PropertyName = "Task_Group_Text")]
        [ModelViewColumn(DisplayName = "Task_Group_Text", ToDisplay = true)]
        public string CodeGroupText { get; set; }

        [JsonProperty(PropertyName = "Task_Code")]
        [ModelViewColumn(DisplayName = "Task_Code", ToDisplay = true)]
        public string TaskCode { get; set; }

        [JsonProperty(PropertyName = "Task_Code_Text")]
        [ModelViewColumn(DisplayName = "Task_Code_Text", ToDisplay = true)]
        public string TaskCodeText { get; set; }

        [JsonProperty(PropertyName = "Task_Planned_Start")]
        [ModelViewColumn(DisplayName = "Task_Planned_Start", ToDisplay = true)]
        public DateTime? PlannedStart { get; set; }

        [JsonProperty(PropertyName = "Task_Planned_Finish")]
        [ModelViewColumn(DisplayName = "Task_Planned_Finish", ToDisplay = true)]
        public DateTime? PlannedFinish { get; set; }

        [JsonProperty(PropertyName = "Supplier_Vendor")]
        [ModelViewColumn(DisplayName = "Supplier_Vendor", ToDisplay = true)]
        public string SupplierVendorCode { get; set; }

        [JsonProperty(PropertyName = "Task_Owner")]
        [ModelViewColumn(DisplayName = "Task_Owner", ToDisplay = true)]
        public string TaskOwnerCode { get; set; }

        [JsonProperty(PropertyName = "Task_Status")]
        [ModelViewColumn(DisplayName = "Task_Status", ToDisplay = true)]
        public string TaskStatusCode { get; set; }

        [JsonProperty(PropertyName = "Coding")]
        [ModelViewColumn(DisplayName = "Coding", ToDisplay = true)]
        public int CodingCodeId { get; set; }

        [JsonProperty(PropertyName = "Coding")]
        [ModelViewColumn(DisplayName = "Coding", ToDisplay = true)]
        public ETL.CodingCode? CodingCode { get; set; }

        [JsonProperty(PropertyName = "Engine")]
        [ModelViewColumn(DisplayName = "Engine", ToDisplay = true)]
        public string EngineProgramCode { get; set; }

        [JsonProperty(PropertyName = "Damage_Code")]
        [ModelViewColumn(DisplayName = "Damage_Code", ToDisplay = true)]
        public string DamageCode { get; set; }

        [JsonProperty(PropertyName = "Cause_Code")]
        [ModelViewColumn(DisplayName = "Cause_Code", ToDisplay = true)]
        public string CauseCode { get; set; }

        [JsonProperty(PropertyName = "IsTaskCompleted")]
        [ModelViewColumn(DisplayName = "IsTaskCompleted", ToDisplay = true)]
        public bool IsTaskCompleted { get; set; }

        [JsonProperty(PropertyName = "IsItemCompleted")]
        [ModelViewColumn(DisplayName = "IsItemCompleted", ToDisplay = true)]
        public bool IsItemCompleted { get; set; }

        [JsonProperty(PropertyName = "IsTurnback")]
        [ModelViewColumn(DisplayName = "IsTurnback", ToDisplay = true)]
        public bool IsTurnback { get; set; }

        [JsonProperty(PropertyName = "IsLife")]
        [ModelViewColumn(DisplayName = "IsLife", ToDisplay = true)]
        public bool IsLife { get; set; }

        public DescriptiveDashboardData()
        {

        }

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



