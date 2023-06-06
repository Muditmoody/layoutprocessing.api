using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.ETL;
public class Category : LayoutProcessingObjects
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
    [ModelViewColumn(DisplayName = "CategoryName", ToDisplay = true)]
    public string CategoryName { get; set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="Category"/> class.
    /// </summary>
    public Category()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Category"/> class.
    /// </summary>
    /// <param name="categoryId">The category id.</param>
    /// <param name="categoryName">The category name.</param>
    public Category(int categoryId, string categoryName)
    {
        CategoryId = categoryId;
        CategoryName = categoryName;
    }

    /// <summary>
    /// Maps the Entity Entity
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <returns>A Category.</returns>
    public static Category Map(SqlDataReader reader) => new Category
    {
        CategoryId = reader.GetFieldValue<int>(reader.GetOrdinal("Id")),
        CategoryName = reader.GetFieldValue<string>(reader.GetOrdinal("CategoryName"))
    };
}