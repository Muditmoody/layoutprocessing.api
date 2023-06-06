using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Import;
public class ImportCategory : IImportObjects
{
    /// <summary>
    /// Gets or sets the category id.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "CategoryId")]
    [ModelViewColumn(DisplayName = "Id", ToDisplay = true)]
    public int CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the category name.
    /// </summary>
    [JsonProperty(PropertyName = "CategoryName")]
    [ModelViewColumn(DisplayName = "CategoryName", ToDisplay = true)]
    public string CategoryName { get; set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="ImportCategory"/> class.
    /// </summary>
    public ImportCategory()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ImportCategory"/> class.
    /// </summary>
    /// <param name="categoryId">The category id.</param>
    /// <param name="categoryName">The category name.</param>
    public ImportCategory(int categoryId, string categoryName)
    {
        CategoryId = categoryId;
        CategoryName = categoryName;
    }
}