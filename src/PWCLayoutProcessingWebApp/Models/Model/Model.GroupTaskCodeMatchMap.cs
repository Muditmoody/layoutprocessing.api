using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.ETL;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Model
{
    public class GroupTaskCodeMatchMap : IModelObjects
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "Id")]
        [ModelViewColumn(DisplayName = "Id", ToDisplay = true)]
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

        public GroupTaskCodeMatchMap() { }

        public GroupTaskCodeMatchMap(int id, string codeGroup, string taskCode, string generalCode)
        {
            Id = id;
            CodeGroup = codeGroup;
            TaskCode = taskCode;
            GeneralCode = generalCode;
        }

        public static GroupTaskCodeMatchMap Map(SqlDataReader reader) => new GroupTaskCodeMatchMap
        {
            //CodeGroupId = reader.GetFieldValue<int>(reader.GetOrdinal("Id")),
            //CodeGroupName = reader.GetFieldValue<string>(reader.GetOrdinal("GroupCode")),
            //CodeGroupText = reader.GetFieldValue<string>(reader.GetOrdinal("GroupText"))
        };
    }
}
