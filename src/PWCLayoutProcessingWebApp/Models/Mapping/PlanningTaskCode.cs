namespace PWCLayoutProcessingWebApp.Models.Mapping
{
    public class PlanningTaskCode
    {
        public int Id { get; set; }
        public int TaskCodeId { get; set; }
        public ETL.TaskCode? TaskCode { get; set; }

    }
}
