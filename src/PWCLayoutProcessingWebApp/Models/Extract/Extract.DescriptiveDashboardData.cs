using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract
{
    public class ExtractDescriptiveDashboardData : IExtractObjects
    {
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
        public string CodingCode { get; set; }

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

        public ExtractDescriptiveDashboardData()
        {

        }

        public ExtractDescriptiveDashboardData(int id, string notification, int item, int task, string material, DateTime createdDate, string description,
            string category, DateTime completedDate, string taskText, string codeGroup, string codeGroupText, string taskCode, string taskCodeText,
            DateTime plannedStart, DateTime plannedFinish, string supplierVendorCode, string taskOwnerCode, string taskStatusCode, string codingCode,
            string engineProgramCode, string damageCode, string causeCode, bool isTaskCompleted, bool isItemCompleted, bool isTurnback, bool isLife)
        {
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


        public static ExtractDescriptiveDashboardData Map(Reporting.DescriptiveDashboardData item) => new ExtractDescriptiveDashboardData
        {
            Category = item.Category,
            CauseCode = item.CauseCode,
            CodeGroup = item.CodeGroup,
            CodeGroupText = item.CodeGroupText,
            CodingCode = item.CodingCode.CodingCodeName,
            CompletedDate = item.CompletedDate,
            CreatedDate = item.CreatedDate,
            DamageCode = item.DamageCode,
            Description = item.Description,
            EngineProgramCode = item.EngineProgramCode,
            IsItemCompleted = item.IsItemCompleted,
            IsLife = item.IsLife,
            IsTaskCompleted = item.IsTaskCompleted,
            IsTurnback = item.IsTurnback,
            Item = item.Item,
            Material = item.Material,
            Notification = item.Notification,
            PlannedFinish = item.PlannedFinish,
            PlannedStart = item.PlannedStart,
            SupplierVendorCode = item.SupplierVendorCode,
            Task = item.Task,
            TaskCode = item.TaskCode,
            TaskCodeText = item.TaskCodeText,
            TaskOwnerCode = item.TaskOwnerCode,
            TaskStatusCode = item.TaskStatusCode,
            TaskText = item.TaskText
        };
    }
}

//#"Delete Columns" = Table.RemoveColumns(#"Expanded Column1",{"LayoutTaskId"}),
//#"Changed Type" = Table.TransformColumnTypes(#"Expanded Column1",{{"Id", Int64.Type}, {"Notification", Int64.Type}, {"Item", Int64.Type}, {"LayoutTaskId", Int64.Type}, {"Task", Int64.Type}, {"Material", type text}, {"Created_On", type datetime}, {"Completed_On", type datetime}, {"TaskText", type text}, {"TaskCodeId", Int64.Type}, {"TaskCode", Int64.Type}, {"TaskCodeText", type text}, {"Planned_Start", type datetime}, {"Planned_Finish", type datetime}, {"SupplierVendorId", Int64.Type}, {"SupplierVendor", Int64.Type}, {"TaskOwnerId", Int64.Type}, {"TaskOwner", Int64.Type}, {"TaskStatusId", Int64.Type}, {"TaskStatus", type text}, {"DamageCodeId", Int64.Type}, {"DamageCode", Int64.Type}, {"CauseCodeId", Int64.Type}, {"CauseCode", type text}, {"GroupCodeId", Int64.Type}, {"GroupCode", type text}, {"CategoryId", Int64.Type}, {"Category", type text}, {"Coding", type text}, {"Engine", type text}, {"GeneralCode", type any}, {"IsTaskCompleted", type logical}, {"IsItemCompleted", type logical}, {"IsTurnback", type logical}, {"IsLife", type logical}, {"IsPlanning", type logical}, {"Available", Int64.Type}, {"runDate", type datetime}}),
//#"Add Not_Item" = Table.AddColumn(#"Changed Type", "Not_Item", each [Notification]&"_"&[Item]),
//#"Changed Type Date" = Table.TransformColumnTypes(#"Add Not_Item",{{"Created_On", type date}, {"Completed_On", type date}}),
//#"Add TaskDuration" = Table.AddColumn(#"Changed Type Date", "Task_Duration", each  Duration.Days ( [Completed_On] - [Created_On] ) +1),
//#"Added Conditional Column" = Table.AddColumn(#"Add TaskDuration", "IsTaskCompleted_num", each if [IsTaskCompleted] = "TRUE" then 1 else 0),
//#"Changed Type2" = Table.TransformColumnTypes(#"Added Conditional Column",{{"IsTaskCompleted_num", type number}, {"Task_Duration", type number}}),
//#"Added Custom1" = Table.AddColumn(#"Changed Type2", "Not_Item_Task", each [Notification]&"_"&[Item]&"_"&[Task]),
//#"Changed Type3" = Table.TransformColumnTypes(#"Added Custom1",{{"IsTurnback", Percentage.Type}})