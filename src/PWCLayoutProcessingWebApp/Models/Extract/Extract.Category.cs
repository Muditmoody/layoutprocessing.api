using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract;

/// <summary>
/// Category Class model
/// </summary>
public class ExtractCategory : IExtractObjects
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
    /// Initializes a new instance of the <see cref="ExtractCategory"/> class.
    /// </summary>
    public ExtractCategory()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtractCategory"/> class.
    /// </summary>
    /// <param name="categoryId">The category id.</param>
    /// <param name="categoryName">The category name.</param>
    public ExtractCategory(int categoryId, string categoryName)
    {
        CategoryId = categoryId;
        CategoryName = categoryName;
    }

    /// <summary>
    /// Maps the Entity.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>An ExtractCategory.</returns>
    public static ExtractCategory Map(ETL.Category item) => new ExtractCategory
    {
        CategoryId = item.CategoryId,
        CategoryName = item.CategoryName
    };
}