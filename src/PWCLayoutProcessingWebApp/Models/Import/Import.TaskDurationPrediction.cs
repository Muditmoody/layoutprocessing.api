using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.ETL;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Import
{
    public class ImportTaskDurationPrediction : IImportObjects
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "Id")]
        [ModelViewColumn(DisplayName = "Id", ToDisplay = true)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "ModelDataInputId")]
        [ModelViewColumn(DisplayName = "ModelDataInputId", ToDisplay = true)]
        public int ModelDataInputId { get; set; }

        [JsonProperty(PropertyName = "PredictionResult")]
        [ModelViewColumn(DisplayName = "PredictionResult", ToDisplay = true)]
        public double PredictionResult { get; set; }


        public ImportTaskDurationPrediction(int id, int modelDataInputId, double predictionResult)
        {
            Id = id;
            ModelDataInputId = modelDataInputId;
            PredictionResult = predictionResult;
        }
    }
}
