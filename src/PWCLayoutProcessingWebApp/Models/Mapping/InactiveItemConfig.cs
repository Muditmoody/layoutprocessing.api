namespace PWCLayoutProcessingWebApp.Models.Mapping
{
    public class InactiveItemConfig
    {
        public int ID { get; set; }

        public string NotificationCode { get; set; }

        public string ItemNumber { get; set; }

        public bool IgnoreInactiveTask { get; set; }

        public bool IgnoreInactiveItem { get; set; }
    }
}
