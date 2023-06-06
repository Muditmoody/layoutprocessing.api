using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.ETL;
public class Material : LayoutProcessingObjects
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
    [ModelViewColumn(DisplayName = "MaterialCode", ToDisplay = true)]
    public string MaterialCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    [ModelViewColumn(DisplayName = "Description", ToDisplay = true)]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the category id.
    /// </summary>
    [ModelViewColumn(DisplayName = "CategoryId", ToDisplay = true)]
    public int CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the category.
    /// </summary>
    public Category? Category { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Material"/> class.
    /// </summary>
    public Material()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Material"/> class.
    /// </summary>
    /// <param name="codeId">The code id.</param>
    /// <param name="codeName">The code name.</param>
    /// <param name="codeText">The code text.</param>
    /// <param name="categoryId">The category id.</param>
    /// <param name="category">The category.</param>
    public Material(int codeId, string codeName, string codeText, int categoryId, Category? category)
    {
        MaterialId = codeId;
        MaterialCode = codeName;
        Description = codeText;
        CategoryId = categoryId;
        Category = category;
    }

    /// <summary>
    /// Maps the Entity.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <returns>A Material.</returns>
    public static Material Map(SqlDataReader reader)
    {
        var cols = new string[] { "Category_Id", "CategoryName" };
        var category = default(Category);

        if (reader.GetColumnSchema().All(col => cols.Contains(col.ColumnName)))
        {
            category = new Category
            {
                CategoryId = reader.GetFieldValue<int>(reader.GetOrdinal("Category_Id")),
                CategoryName = reader.GetFieldValue<string>(reader.GetOrdinal("CategoryName")),
            };
        }

        return new Material
        {
            MaterialId = reader.GetFieldValue<int>(reader.GetOrdinal("Id")),
            MaterialCode = reader.GetFieldValue<string>(reader.GetOrdinal("Material_Id")),
            Description = reader.GetFieldValue<string>(reader.GetOrdinal("Description")),
            CategoryId = reader.GetFieldValue<int>(reader.GetOrdinal("Category_Id")),
            Category = category
        };
    }
}