using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Model
{
    public class GroupTaskCodeMatchMap : IModelObjects
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "Id")]
        [ModelViewColumn(DisplayName = "Id", ToDisplay = true)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the code group.
        /// </summary>
        [JsonProperty(PropertyName = "CodeGroup")]
        [ModelViewColumn(DisplayName = "CodeGroup", ToDisplay = true)]
        public string CodeGroup { get; set; }

        /// <summary>
        /// Gets or sets the task code.
        /// </summary>
        [JsonProperty(PropertyName = "TaskCode")]
        [ModelViewColumn(DisplayName = "TaskCode", ToDisplay = true)]
        public string TaskCode { get; set; }

        /// <summary>
        /// Gets or sets the general code.
        /// </summary>
        [JsonProperty(PropertyName = "GeneralCode")]
        [ModelViewColumn(DisplayName = "GeneralCode", ToDisplay = true)]
        public string GeneralCode { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupTaskCodeMatchMap"/> class.
        /// </summary>
        public GroupTaskCodeMatchMap()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupTaskCodeMatchMap"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="codeGroup">The code group.</param>
        /// <param name="taskCode">The task code.</param>
        /// <param name="generalCode">The general code.</param>
        public GroupTaskCodeMatchMap(int id, string codeGroup, string taskCode, string generalCode)
        {
            Id = id;
            CodeGroup = codeGroup;
            TaskCode = taskCode;
            GeneralCode = generalCode;
        }

        /// <summary>
        /// Maps the Entity.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>A GroupTaskCodeMatchMap.</returns>
        public static GroupTaskCodeMatchMap Map(SqlDataReader reader) => new GroupTaskCodeMatchMap
        {
            //CodeGroupId = reader.GetFieldValue<int>(reader.GetOrdinal("Id")),
            //CodeGroupName = reader.GetFieldValue<string>(reader.GetOrdinal("GroupCode")),
            //CodeGroupText = reader.GetFieldValue<string>(reader.GetOrdinal("GroupText"))
        };
    }
}