using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.ETL;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Model
{
    public class SequenceSimilarity : IModelObjects
    {
        public DateTime RunDate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "Id")]
        [ModelViewColumn(DisplayName = "Id", ToDisplay = true)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "db_layout_id_ref")]
        [ModelViewColumn(DisplayName = "db_layout_id_ref", ToDisplay = true)]
        public int LayoutIdRef { get; set; }

        [JsonProperty(PropertyName = "db_layout_id_test")]
        [ModelViewColumn(DisplayName = "db_layout_id_test", ToDisplay = true)]
        public int LayoutIdTest { get; set; }

        [JsonProperty(PropertyName = "Seq1")]
        [ModelViewColumn(DisplayName = "Seq1", ToDisplay = true)]
        public string TaskSequenceRef { get; set; }

        [JsonProperty(PropertyName = "Seq2")]
        [ModelViewColumn(DisplayName = "Seq2", ToDisplay = true)]
        public string TaskSequenceTest { get; set; }


        [JsonProperty(PropertyName = "Align_Seq1")]
        [ModelViewColumn(DisplayName = "Align_Seq1", ToDisplay = true)]
        public string AlignTaskSequenceRef { get; set; }

        [JsonProperty(PropertyName = "Align_Seq2")]
        [ModelViewColumn(DisplayName = "Align_Seq1", ToDisplay = true)]
        public string AlignTaskSequenceTest { get; set; }

        [JsonProperty(PropertyName = "Score")]
        [ModelViewColumn(DisplayName = "Score", ToDisplay = true)]
        public double Score { get; set; }

        public SequenceSimilarity() { }

        public SequenceSimilarity(int id, int layoutIdRef, int layoutIdTest, string taskSequenceRef, string taskSequenceTest,
            string alignTaskSequenceRef, string alignTaskSequenceTest, double score, DateTime runDate)
        {
            Id = id;
            LayoutIdRef = layoutIdRef;
            LayoutIdTest = layoutIdTest;
            TaskSequenceRef = taskSequenceRef;
            TaskSequenceTest = taskSequenceTest;
            AlignTaskSequenceRef = alignTaskSequenceRef;
            AlignTaskSequenceTest = alignTaskSequenceTest;
            Score = score;
            RunDate = runDate;
        }

        public static SequenceSimilarity Map(SqlDataReader reader) => new SequenceSimilarity
        {
            //CodeGroupId = reader.GetFieldValue<int>(reader.GetOrdinal("Id")),
            //CodeGroupName = reader.GetFieldValue<string>(reader.GetOrdinal("GroupCode")),
            //CodeGroupText = reader.GetFieldValue<string>(reader.GetOrdinal("GroupText"))
        };
    }
}
