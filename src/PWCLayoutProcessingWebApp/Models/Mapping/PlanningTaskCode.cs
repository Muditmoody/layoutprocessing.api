namespace PWCLayoutProcessingWebApp.Models.Mapping
{
    /// <summary>
    /// Planning task code class model
    /// </summary>
    public class PlanningTaskCode
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the task code id.
        /// </summary>
        public int TaskCodeId { get; set; }

        /// <summary>
        /// Gets or sets the task code.
        /// </summary>
        public ETL.TaskCode? TaskCode { get; set; }
    }
}