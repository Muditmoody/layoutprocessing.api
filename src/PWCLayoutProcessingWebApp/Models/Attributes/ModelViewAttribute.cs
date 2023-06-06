namespace PWCLayoutProcessingWebApp.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, Inherited = true)]
    public class ModelViewColumnAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to display.
        /// </summary>
        public bool ToDisplay { get; set; } = false;

        //public ModelViewColumnAttribute(string diplayName, bool toDisplay = true)
        //{
        //    DiplayName = diplayName;
        //    ToDisplay = toDisplay;
        //}
    }
}