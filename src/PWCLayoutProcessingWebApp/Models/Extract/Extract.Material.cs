using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract;
public class ExtractMaterial : IExtractObjects
{
    /// <summary>
    /// Gets or sets the material id.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "MaterialId")]
    [ModelViewColumn(DisplayName = "MaterialId", ToDisplay = true)]
    public int MaterialId { get; set; }

    /// <summary>
    /// Gets or sets the material code.
    /// </summary>
    [JsonProperty(PropertyName = "MaterialCode")]
    [ModelViewColumn(DisplayName = "MaterialCode", ToDisplay = true)]
    public string MaterialCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    [JsonProperty(PropertyName = "Description")]
    [ModelViewColumn(DisplayName = "Description", ToDisplay = true)]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the category id.
    /// </summary>
    [JsonProperty(PropertyName = "CategoryId")]
    [ModelViewColumn(DisplayName = "CategoryId", ToDisplay = true)]
    public int CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the category name.
    /// </summary>
    [JsonProperty(PropertyName = "CategoryName")]
    public string CategoryName { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtractMaterial"/> class.
    /// </summary>
    public ExtractMaterial()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtractMaterial"/> class.
    /// </summary>
    /// <param name="codeId">The code id.</param>
    /// <param name="codeName">The code name.</param>
    /// <param name="codeText">The code text.</param>
    /// <param name="categoryId">The category id.</param>
    /// <param name="categoryName">The category name.</param>
    public ExtractMaterial(int codeId, string codeName, string codeText, int categoryId, string categoryName)
    {
        MaterialId = codeId;
        MaterialCode = codeName;
        Description = codeText;
        CategoryId = categoryId;
        CategoryName = categoryName;
    }

    /// <summary>
    /// Maps the Entity.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>An ExtractMaterial.</returns>
    public static ExtractMaterial Map(ETL.Material item) => new ExtractMaterial
    {
        MaterialId = item.MaterialId,
        MaterialCode = item.MaterialCode,
        Description = item.Description,
        CategoryId = item.CategoryId,
        CategoryName = item.Category.CategoryName
    };
}