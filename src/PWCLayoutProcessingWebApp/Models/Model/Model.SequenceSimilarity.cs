using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Model
{
    public class SequenceSimilarity : IModelObjects
    {
        /// <summary>
        /// Gets or sets the run date.
        /// </summary>
        public DateTime RunDate { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "Id")]
        [ModelViewColumn(DisplayName = "Id", ToDisplay = true)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the layout id ref.
        /// </summary>
        [JsonProperty(PropertyName = "db_layout_id_ref")]
        [ModelViewColumn(DisplayName = "db_layout_id_ref", ToDisplay = true)]
        public int LayoutIdRef { get; set; }

        /// <summary>
        /// Gets or sets the layout id test.
        /// </summary>
        [JsonProperty(PropertyName = "db_layout_id_test")]
        [ModelViewColumn(DisplayName = "db_layout_id_test", ToDisplay = true)]
        public int LayoutIdTest { get; set; }

        /// <summary>
        /// Gets or sets the task sequence ref.
        /// </summary>
        [JsonProperty(PropertyName = "Seq1")]
        [ModelViewColumn(DisplayName = "Seq1", ToDisplay = true)]
        public string TaskSequenceRef { get; set; }

        /// <summary>
        /// Gets or sets the task sequence test.
        /// </summary>
        [JsonProperty(PropertyName = "Seq2")]
        [ModelViewColumn(DisplayName = "Seq2", ToDisplay = true)]
        public string TaskSequenceTest { get; set; }

        /// <summary>
        /// Gets or sets the align task sequence ref.
        /// </summary>
        [JsonProperty(PropertyName = "Align_Seq1")]
        [ModelViewColumn(DisplayName = "Align_Seq1", ToDisplay = true)]
        public string AlignTaskSequenceRef { get; set; }

        /// <summary>
        /// Gets or sets the align task sequence test.
        /// </summary>
        [JsonProperty(PropertyName = "Align_Seq2")]
        [ModelViewColumn(DisplayName = "Align_Seq1", ToDisplay = true)]
        public string AlignTaskSequenceTest { get; set; }

        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        [JsonProperty(PropertyName = "Score")]
        [ModelViewColumn(DisplayName = "Score", ToDisplay = true)]
        public double Score { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SequenceSimilarity"/> class.
        /// </summary>
        public SequenceSimilarity()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SequenceSimilarity"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="layoutIdRef">The layout id ref.</param>
        /// <param name="layoutIdTest">The layout id test.</param>
        /// <param name="taskSequenceRef">The task sequence ref.</param>
        /// <param name="taskSequenceTest">The task sequence test.</param>
        /// <param name="alignTaskSequenceRef">The align task sequence ref.</param>
        /// <param name="alignTaskSequenceTest">The align task sequence test.</param>
        /// <param name="score">The score.</param>
        /// <param name="runDate">The run date.</param>
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

        /// <summary>
        /// Maps the Entity.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>A SequenceSimilarity.</returns>
        public static SequenceSimilarity Map(SqlDataReader reader) => new SequenceSimilarity
        {
            //CodeGroupId = reader.GetFieldValue<int>(reader.GetOrdinal("Id")),
            //CodeGroupName = reader.GetFieldValue<string>(reader.GetOrdinal("GroupCode")),
            //CodeGroupText = reader.GetFieldValue<string>(reader.GetOrdinal("GroupText"))
        };
    }
}