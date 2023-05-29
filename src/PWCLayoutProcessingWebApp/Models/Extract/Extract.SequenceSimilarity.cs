using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract
{
    public class ExtractSequenceSimilarity : IExtractObjects
    {
        public DateTime RunDate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "Id")]
        [ModelViewColumn(DisplayName = "Id", ToDisplay = true)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "NotificationCode")]
        [ModelViewColumn(DisplayName = "NotificationCode", ToDisplay = true)]
        public string NotificationCode { get; set; }

        [JsonProperty(PropertyName = "LayoutIdRef")]
        [ModelViewColumn(DisplayName = "LayoutIdRef", ToDisplay = true)]
        public int LayoutIdRef { get; set; }

        [JsonProperty(PropertyName = "ItemNumberRef")]
        [ModelViewColumn(DisplayName = "ItemNumberRef", ToDisplay = true)]
        public string ItemNumberRef { get; set; }

        [JsonProperty(PropertyName = "LayoutIdTest")]
        [ModelViewColumn(DisplayName = "LayoutIdTest", ToDisplay = true)]
        public int LayoutIdTest { get; set; }

        [JsonProperty(PropertyName = "ItemNumberTest")]
        [ModelViewColumn(DisplayName = "ItemNumberTest", ToDisplay = true)]
        public string ItemNumberTest { get; set; }

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

        [JsonProperty(PropertyName = "RefPastDuration")]
        [ModelViewColumn(DisplayName = "RefPastDuration", ToDisplay = true)]
        public int RefPastDuration { get; set; }

        [JsonProperty(PropertyName = "RefPastDurationNonePlanning")]
        [ModelViewColumn(DisplayName = "RefPastDurationNonePlanning", ToDisplay = true)]
        public int RefPastDurationNonePlanning { get; set; }

        [JsonProperty(PropertyName = "TestTimeElapsed")]
        [ModelViewColumn(DisplayName = "TestTimeElapsed", ToDisplay = true)]
        public int TestTimeElapsed { get; set; }

        [JsonProperty(PropertyName = "TestTimeElapsedNonePlanning")]
        [ModelViewColumn(DisplayName = "TestTimeElapsedNonePlanning", ToDisplay = true)]
        public int TestTimeElapsedNonePlanning { get; set; }


        public ExtractSequenceSimilarity() { }

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
