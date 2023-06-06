using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Model
{
    /// <summary>
    /// Task Duration data class model
    /// </summary>
    public class TaskDurationPrediction : IModelObjects
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
        /// Gets or sets the model data input.
        /// </summary>
        [JsonProperty(PropertyName = "ModelDataInput")]
        [ModelViewColumn(DisplayName = "ModelDataInput", ToDisplay = true)]
        public virtual CleanModelInput? ModelDataInput { get; set; }

        /// <summary>
        /// Gets or sets the prediction result.
        /// </summary>
        [JsonProperty(PropertyName = "PredictionResult")]
        [ModelViewColumn(DisplayName = "PredictionResult", ToDisplay = true)]
        public double PredictionResult { get; set; }

        /// <summary>
        /// Gets or sets the run date.
        /// </summary>
        public DateTime RunDate { get; set; }

        /// <summary>
        /// Maps the Entity.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>A TaskDurationPrediction.</returns>
        public static TaskDurationPrediction Map(SqlDataReader reader) => new TaskDurationPrediction
        {
            //CodeGroupId = reader.GetFieldValue<int>(reader.GetOrdinal("Id")),
            //CodeGroupName = reader.GetFieldValue<string>(reader.GetOrdinal("GroupCode")),
            //CodeGroupText = reader.GetFieldValue<string>(reader.GetOrdinal("GroupText"))
        };
    }
}