using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract
{
    public class ExtractSequenceSimilarity : IExtractObjects
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
        /// Gets or sets the notification code.
        /// </summary>
        [JsonProperty(PropertyName = "NotificationCode")]
        [ModelViewColumn(DisplayName = "NotificationCode", ToDisplay = true)]
        public string NotificationCode { get; set; }

        /// <summary>
        /// Gets or sets the layout id ref.
        /// </summary>
        [JsonProperty(PropertyName = "LayoutIdRef")]
        [ModelViewColumn(DisplayName = "LayoutIdRef", ToDisplay = true)]
        public int LayoutIdRef { get; set; }

        /// <summary>
        /// Gets or sets the item number ref.
        /// </summary>
        [JsonProperty(PropertyName = "ItemNumberRef")]
        [ModelViewColumn(DisplayName = "ItemNumberRef", ToDisplay = true)]
        public string ItemNumberRef { get; set; }

        /// <summary>
        /// Gets or sets the layout id test.
        /// </summary>
        [JsonProperty(PropertyName = "LayoutIdTest")]
        [ModelViewColumn(DisplayName = "LayoutIdTest", ToDisplay = true)]
        public int LayoutIdTest { get; set; }

        /// <summary>
        /// Gets or sets the item number test.
        /// </summary>
        [JsonProperty(PropertyName = "ItemNumberTest")]
        [ModelViewColumn(DisplayName = "ItemNumberTest", ToDisplay = true)]
        public string ItemNumberTest { get; set; }

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
        /// Gets or sets the ref past duration.
        /// </summary>
        [JsonProperty(PropertyName = "RefPastDuration")]
        [ModelViewColumn(DisplayName = "RefPastDuration", ToDisplay = true)]
        public int RefPastDuration { get; set; }

        /// <summary>
        /// Gets or sets the ref past duration none planning.
        /// </summary>
        [JsonProperty(PropertyName = "RefPastDurationNonePlanning")]
        [ModelViewColumn(DisplayName = "RefPastDurationNonePlanning", ToDisplay = true)]
        public int RefPastDurationNonePlanning { get; set; }

        /// <summary>
        /// Gets or sets the test time elapsed.
        /// </summary>
        [JsonProperty(PropertyName = "TestTimeElapsed")]
        [ModelViewColumn(DisplayName = "TestTimeElapsed", ToDisplay = true)]
        public int TestTimeElapsed { get; set; }

        /// <summary>
        /// Gets or sets the test time elapsed none planning.
        /// </summary>
        [JsonProperty(PropertyName = "TestTimeElapsedNonePlanning")]
        [ModelViewColumn(DisplayName = "TestTimeElapsedNonePlanning", ToDisplay = true)]
        public int TestTimeElapsedNonePlanning { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractSequenceSimilarity"/> class.
        /// </summary>
        public ExtractSequenceSimilarity()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractSequenceSimilarity"/> class.
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
        /// <param name="notificationCode">The notification code.</param>
        /// <param name="itemNumberRef">The item number ref.</param>
        /// <param name="itemNumberTest">The item number test.</param>
        public ExtractSequenceSimilarity(int id, int layoutIdRef, int layoutIdTest, string taskSequenceRef, string taskSequenceTest,
            string alignTaskSequenceRef, string alignTaskSequenceTest, double score, DateTime runDate, string notificationCode, string itemNumberRef, string itemNumberTest)
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
            NotificationCode = notificationCode;
            ItemNumberRef = itemNumberRef;
            ItemNumberTest = itemNumberTest;
        }

        /// <summary>
        /// Maps the Entity.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>An ExtractSequenceSimilarity.</returns>
        public static ExtractSequenceSimilarity Map(Model.SequenceSimilarity item) => new ExtractSequenceSimilarity
        {
            Id = item.Id,
            LayoutIdRef = item.LayoutIdRef,
            LayoutIdTest = item.LayoutIdTest,
            AlignTaskSequenceRef = item.AlignTaskSequenceRef,
            AlignTaskSequenceTest = item.AlignTaskSequenceTest,
            TaskSequenceRef = item.TaskSequenceRef,
            TaskSequenceTest = item.TaskSequenceTest,
            Score = item.Score,
            RefPastDuration = 0,
            TestTimeElapsed = 0,
            RunDate = item.RunDate
        };
    }
}