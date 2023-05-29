using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.ETL;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract
{
    public class ExtractGroupTaskCodeMatchMap : IExtractObjects
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "GeneralCodeId")]
        [ModelViewColumn(DisplayName = "GeneralCodeId", ToDisplay = true)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "CodeGroup")]
        [ModelViewColumn(DisplayName = "CodeGroup", ToDisplay = true)]
        public string CodeGroup { get; set; }

        [JsonProperty(PropertyName = "TaskCode")]
        [ModelViewColumn(DisplayName = "TaskCode", ToDisplay = true)]
        public string TaskCode { get; set; }

        [JsonProperty(PropertyName = "GeneralCode")]
        [ModelViewColumn(DisplayName = "GeneralCode", ToDisplay = true)]
        public string GeneralCode { get; set; }

        public ExtractGroupTaskCodeMatchMap() { }

        public ExtractGroupTaskCodeMatchMap(int id, string codeGroup, string taskCode, string generalCode)
        {
            Id = id;
            CodeGroup = codeGroup;
            TaskCode = taskCode;
            GeneralCode = generalCode;
        }

        public static ExtractGroupTaskCodeMatchMap Map(Model.GroupTaskCodeMatchMap item) => new ExtractGroupTaskCodeMatchMap
        {
            Id = item.Id,
            CodeGroup = item.CodeGroup,
            TaskCode = item.TaskCode,
            GeneralCode = item.GeneralCode,

        };
    }
}
