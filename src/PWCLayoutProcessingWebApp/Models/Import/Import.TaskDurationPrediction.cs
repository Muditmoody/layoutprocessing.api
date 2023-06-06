using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Import
{
    public class ImportTaskDurationPrediction : IImportObjects
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
        /// Initializes a new instance of the <see cref="ImportTaskDurationPrediction"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="modelDataInputId">The model data input id.</param>
        /// <param name="predictionResult">The prediction result.</param>
        public ImportTaskDurationPrediction(int id, int modelDataInputId, double predictionResult)
        {
            Id = id;
            ModelDataInputId = modelDataInputId;
            PredictionResult = predictionResult;
        }
    }
}