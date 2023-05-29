using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.ETL;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Model
{
    public class CleanModelInput : IModelObjects
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "Id")]
        [ModelViewColumn(DisplayName = "Id", ToDisplay = true)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Notification")]
        [ModelViewColumn(DisplayName = "Notification", ToDisplay = true)]
        public string NotificationCode { get; set; }

        [JsonProperty(PropertyName = "Item")]
        [ModelViewColumn(DisplayName = "Item", ToDisplay = true)]
        public int ItemNumber { get; set; }

        [JsonProperty(PropertyName = "LayoutTaskId")]
        [ModelViewColumn(DisplayName = "LayoutTaskId", ToDisplay = true)]
        public int LayoutTaskId { get; set; }

        [JsonProperty(PropertyName = "Task")]
        [ModelViewColumn(DisplayName = "Task", ToDisplay = true)]
        public int TaskNumber { get; set; }

        [JsonProperty(PropertyName = "Material")]
        [ModelViewColumn(DisplayName = "Material", ToDisplay = true)]
        public string MaterialCode { get; set; }

        [JsonProperty(PropertyName = "Created_On")]
        [ModelViewColumn(DisplayName = "Created_On", ToDisplay = true)]
        public DateTime CreatedDate { get; set; }

        [JsonProperty(PropertyName = "Completed_On")]
        [ModelViewColumn(DisplayName = "Completed_On", ToDisplay = true)]
        public DateTime? CompletedDate { get; set; }

        [JsonProperty(PropertyName = "TaskText")]
        [ModelViewColumn(DisplayName = "TaskText", ToDisplay = true)]
        public string TaskText { get; set; }



        [JsonProperty(PropertyName = "TaskCodeId")]
        [ModelViewColumn(DisplayName = "TaskCodeId", ToDisplay = true)]
        public int TaskCodeId { get; set; }


        [JsonProperty(PropertyName = "TaskCode")]
        [ModelViewColumn(DisplayName = "TaskCode", ToDisplay = true)]
        public string TaskCode { get; set; }


        [JsonProperty(PropertyName = "TaskCodeText")]
        [ModelViewColumn(DisplayName = "TaskCodeText", ToDisplay = true)]
        public string TaskCodeText { get; set; }




        [JsonProperty(PropertyName = "Planned_Start")]
        [ModelViewColumn(DisplayName = "Planned_Start", ToDisplay = true)]
        public DateTime? PlannedStart { get; set; }

        [JsonProperty(PropertyName = "Planned_Finish")]
        [ModelViewColumn(DisplayName = "Planned_Finish", ToDisplay = true)]
        public DateTime? PlannedFinish { get; set; }


        [JsonProperty(PropertyName = "SupplierVendorId")]
        [ModelViewColumn(DisplayName = "SupplierVendorId", ToDisplay = true)]
        public int SupplierVendorId { get; set; }

        [JsonProperty(PropertyName = "SupplierVendor")]
        [ModelViewColumn(DisplayName = "SupplierVendor", ToDisplay = true)]
        public string SupplierVendorCode { get; set; }



        [JsonProperty(PropertyName = "TaskOwnerId")]
        [ModelViewColumn(DisplayName = "TaskOwnerId", ToDisplay = true)]
        public int TaskOwnerId { get; set; }

        [JsonProperty(PropertyName = "TaskOwner")]
        [ModelViewColumn(DisplayName = "TaskOwner", ToDisplay = true)]
        public string TaskOwnerCode { get; set; }




        [JsonProperty(PropertyName = "TaskStatusId")]
        [ModelViewColumn(DisplayName = "TaskStatusId", ToDisplay = true)]
        public int TaskStatusId { get; set; }


        [JsonProperty(PropertyName = "TaskStatus")]
        [ModelViewColumn(DisplayName = "TaskStatus", ToDisplay = true)]
        public string TaskStatusCode { get; set; }




        [JsonProperty(PropertyName = "DamageCodeId")]
        [ModelViewColumn(DisplayName = "DamageCodeId", ToDisplay = true)]
        public int DamageCodeId { get; set; }


        [JsonProperty(PropertyName = "DamageCode")]
        [ModelViewColumn(DisplayName = "DamageCode", ToDisplay = true)]
        public string DamageCode { get; set; }




        [JsonProperty(PropertyName = "CauseCodeId")]
        [ModelViewColumn(DisplayName = "CauseCodeId", ToDisplay = true)]
        public int CauseCodeId { get; set; }

        [JsonProperty(PropertyName = "CauseCode")]
        [ModelViewColumn(DisplayName = "CauseCode", ToDisplay = true)]
        public string CauseCode { get; set; }




        [JsonProperty(PropertyName = "GroupCodeId")]
        [ModelViewColumn(DisplayName = "GroupCodeId", ToDisplay = true)]
        public int GroupCodeId { get; set; }


        [JsonProperty(PropertyName = "GroupCode")]
        [ModelViewColumn(DisplayName = "GroupCode", ToDisplay = true)]
        public string GroupCode { get; set; }



        [JsonProperty(PropertyName = "CategoryId")]
        [ModelViewColumn(DisplayName = "CategoryId", ToDisplay = true)]
        public int CategoryId { get; set; }

        [JsonProperty(PropertyName = "Category")]
        [ModelViewColumn(DisplayName = "Category", ToDisplay = true)]
        public string Category { get; set; }



        [JsonProperty(PropertyName = "Coding")]
        [ModelViewColumn(DisplayName = "Coding", ToDisplay = true)]
        public int CodingCodeId { get; set; }


        [JsonProperty(PropertyName = "CodingCode")]
        [ModelViewColumn(DisplayName = "Coding", ToDisplay = true)]
        public CodingCode? CodingCode { get; set; }

        [JsonProperty(PropertyName = "Engine")]
        [ModelViewColumn(DisplayName = "Engine", ToDisplay = true)]
        public string EngineProgram { get; set; }




        [JsonProperty(PropertyName = "GeneralCode")]
        [ModelViewColumn(DisplayName = "GeneralCode", ToDisplay = true)]
        public string GeneralCode { get; set; } = string.Empty;

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

        [JsonProperty(PropertyName = "IsPlanning")]
        [ModelViewColumn(DisplayName = "IsPlanning", ToDisplay = true)]
        public bool IsPlanning { get; set; }

        [JsonProperty(PropertyName = "Available")]
        [ModelViewColumn(DisplayName = "Available", ToDisplay = true)]
        public int Available { get; set; }

        public DateTime RunDate { get; set; }


        public CleanModelInput()
        {

        }

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

        public static CleanModelInput Map(SqlDataReader reader) => new CleanModelInput
        {
            //CodeGroupId = reader.GetFieldValue<int>(reader.GetOrdinal("Id")),
            //CodeGroupName = reader.GetFieldValue<string>(reader.GetOrdinal("GroupCode")),
            //CodeGroupText = reader.GetFieldValue<string>(reader.GetOrdinal("GroupText"))
        };
    }
}
