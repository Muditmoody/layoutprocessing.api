namespace PWCLayoutProcessingWebApp.Models.Mapping
{
    public class InactiveItemConfig
    {
        /// <summary>
        /// Gets or sets the i d.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the notification code.
        /// </summary>
        public string NotificationCode { get; set; }

        /// <summary>
        /// Gets or sets the item number.
        /// </summary>
        public string ItemNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether ignore inactive task.
        /// </summary>
        public bool IgnoreInactiveTask { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether ignore inactive item.
        /// </summary>
        public bool IgnoreInactiveItem { get; set; }
    }
}