using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Import
{
    public class ImportSequenceSimilarity : IImportObjects
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "Id")]
        [ModelViewColumn(DisplayName = "Id", ToDisplay = true)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "LayoutIdRef")]
        [ModelViewColumn(DisplayName = "LayoutIdRef", ToDisplay = true)]
        public int LayoutIdRef { get; set; }

        [JsonProperty(PropertyName = "LayoutIdTest")]
        [ModelViewColumn(DisplayName = "LayoutIdTest", ToDisplay = true)]
        public int LayoutIdTest { get; set; }

        //[JsonProperty(PropertyName = "Seq1", NullValueHandling = NullValueHandling.Ignore)]
        [ModelViewColumn(DisplayName = "Seq1", ToDisplay = true)]
        public IEnumerable<string> TaskSequenceRef { get; set; }

        //[JsonProperty(PropertyName = "Seq2", NullValueHandling = NullValueHandling.Ignore)]
        [ModelViewColumn(DisplayName = "Seq2", ToDisplay = true)]
        public IEnumerable<string> TaskSequenceTest { get; set; }


        //[JsonProperty(PropertyName = "Align_Seq1", NullValueHandling = NullValueHandling.Ignore)]
        [ModelViewColumn(DisplayName = "Align_Seq1", ToDisplay = true)]
        public IEnumerable<string> AlignTaskSequenceRef { get; set; }

        //[JsonProperty(PropertyName = "Align_Seq2", NullValueHandling = NullValueHandling.Ignore)]
        [ModelViewColumn(DisplayName = "Align_Seq1", ToDisplay = true)]
        public IEnumerable<string> AlignTaskSequenceTest { get; set; }

        [JsonProperty(PropertyName = "Score")]
        [ModelViewColumn(DisplayName = "Score", ToDisplay = true)]
        public double Score { get; set; }

        public ImportSequenceSimilarity() { }

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
