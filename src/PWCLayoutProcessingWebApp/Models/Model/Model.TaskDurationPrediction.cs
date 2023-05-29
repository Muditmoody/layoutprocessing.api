using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.ETL;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Model
{
    public class TaskDurationPrediction : IModelObjects
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "Id")]
        [ModelViewColumn(DisplayName = "Id", ToDisplay = true)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "ModelDataInputId")]
        [ModelViewColumn(DisplayName = "ModelDataInputId", ToDisplay = true)]
        public int ModelDataInputId { get; set; }

        [JsonProperty(PropertyName = "ModelDataInput")]
        [ModelViewColumn(DisplayName = "ModelDataInput", ToDisplay = true)]
        public virtual CleanModelInput? ModelDataInput { get; set; }

        [JsonProperty(PropertyName = "PredictionResult")]
        [ModelViewColumn(DisplayName = "PredictionResult", ToDisplay = true)]
        public double PredictionResult { get; set; }

        public DateTime RunDate { get; set; }

        public static TaskDurationPrediction Map(SqlDataReader reader) => new TaskDurationPrediction
        {
            //CodeGroupId = reader.GetFieldValue<int>(reader.GetOrdinal("Id")),
            //CodeGroupName = reader.GetFieldValue<string>(reader.GetOrdinal("GroupCode")),
            //CodeGroupText = reader.GetFieldValue<string>(reader.GetOrdinal("GroupText"))
        };
    }
}
