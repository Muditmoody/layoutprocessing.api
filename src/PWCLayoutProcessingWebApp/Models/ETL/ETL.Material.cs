using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.ETL;
public class Material : LayoutProcessingObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "MaterialId")]
    [ModelViewColumn(DisplayName = "MaterialId", ToDisplay = true)]
    public int MaterialId { get; set; }

    [ModelViewColumn(DisplayName = "MaterialCode", ToDisplay = true)]
    public string MaterialCode { get; set; } = string.Empty;

    [ModelViewColumn(DisplayName = "Description", ToDisplay = true)]
    public string Description { get; set; } = string.Empty;

    [ModelViewColumn(DisplayName = "CategoryId", ToDisplay = true)]
    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public Material() { }

    public Material(int codeId, string codeName, string codeText, int categoryId, Category? category)
    {
        MaterialId = codeId;
        MaterialCode = codeName;
        Description = codeText;
        CategoryId = categoryId;
        Category = category;
    }

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