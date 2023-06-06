using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Import
{
    public class ImportSequenceSimilarity : IImportObjects
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "Id")]
        [ModelViewColumn(DisplayName = "Id", ToDisplay = true)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the layout id ref.
        /// </summary>
        [JsonProperty(PropertyName = "LayoutIdRef")]
        [ModelViewColumn(DisplayName = "LayoutIdRef", ToDisplay = true)]
        public int LayoutIdRef { get; set; }

        /// <summary>
        /// Gets or sets the layout id test.
        /// </summary>
        [JsonProperty(PropertyName = "LayoutIdTest")]
        [ModelViewColumn(DisplayName = "LayoutIdTest", ToDisplay = true)]
        public int LayoutIdTest { get; set; }

        //[JsonProperty(PropertyName = "Seq1", NullValueHandling = NullValueHandling.Ignore)]
        /// <summary>
        /// Gets or sets the task sequence ref.
        /// </summary>
        [ModelViewColumn(DisplayName = "Seq1", ToDisplay = true)]
        public IEnumerable<string> TaskSequenceRef { get; set; }

        //[JsonProperty(PropertyName = "Seq2", NullValueHandling = NullValueHandling.Ignore)]
        /// <summary>
        /// Gets or sets the task sequence test.
        /// </summary>
        [ModelViewColumn(DisplayName = "Seq2", ToDisplay = true)]
        public IEnumerable<string> TaskSequenceTest { get; set; }

        //[JsonProperty(PropertyName = "Align_Seq1", NullValueHandling = NullValueHandling.Ignore)]
        /// <summary>
        /// Gets or sets the align task sequence ref.
        /// </summary>
        [ModelViewColumn(DisplayName = "Align_Seq1", ToDisplay = true)]
        public IEnumerable<string> AlignTaskSequenceRef { get; set; }

        //[JsonProperty(PropertyName = "Align_Seq2", NullValueHandling = NullValueHandling.Ignore)]
        /// <summary>
        /// Gets or sets the align task sequence test.
        /// </summary>
        [ModelViewColumn(DisplayName = "Align_Seq1", ToDisplay = true)]
        public IEnumerable<string> AlignTaskSequenceTest { get; set; }

        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        [JsonProperty(PropertyName = "Score")]
        [ModelViewColumn(DisplayName = "Score", ToDisplay = true)]
        public double Score { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImportSequenceSimilarity"/> class.
        /// </summary>
        public ImportSequenceSimilarity()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImportSequenceSimilarity"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="layoutIdRef">The layout id ref.</param>
        /// <param name="layoutIdTest">The layout id test.</param>
        /// <param name="taskSequenceRef">The task sequence ref.</param>
        /// <param name="taskSequenceTest">The task sequence test.</param>
        /// <param name="alignTaskSequenceRef">The align task sequence ref.</param>
        /// <param name="alignTaskSequenceTest">The align task sequence test.</param>
        /// <param name="score">The score.</param>
        public ImportSequenceSimilarity(int id, int layoutIdRef, int layoutIdTest, IEnumerable<string> taskSequenceRef, IEnumerable<string> taskSequenceTest,
            IEnumerable<string> alignTaskSequenceRef, IEnumerable<string> alignTaskSequenceTest, double score)
        {
            Id = id;
            LayoutIdRef = layoutIdRef;
            LayoutIdTest = layoutIdTest;
            TaskSequenceRef = taskSequenceRef;
            TaskSequenceTest = taskSequenceTest;
            AlignTaskSequenceRef = alignTaskSequenceRef;
            AlignTaskSequenceTest = alignTaskSequenceTest;
            Score = score;
        }
    }
}