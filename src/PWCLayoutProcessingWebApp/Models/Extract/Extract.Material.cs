using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract;
public class ExtractMaterial : IExtractObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "MaterialId")]
    [ModelViewColumn(DisplayName = "MaterialId", ToDisplay = true)]
    public int MaterialId { get; set; }

    [JsonProperty(PropertyName = "MaterialCode")]
    [ModelViewColumn(DisplayName = "MaterialCode", ToDisplay = true)]
    public string MaterialCode { get; set; } = string.Empty;

    [JsonProperty(PropertyName = "Description")]
    [ModelViewColumn(DisplayName = "Description", ToDisplay = true)]
    public string Description { get; set; } = string.Empty;

    [JsonProperty(PropertyName = "CategoryId")]
    [ModelViewColumn(DisplayName = "CategoryId", ToDisplay = true)]
    public int CategoryId { get; set; }

    [JsonProperty(PropertyName = "CategoryName")]
    public string CategoryName { get; set; }

    public ExtractMaterial() { }

    public ExtractMaterial(int codeId, string codeName, string codeText, int categoryId, string categoryName)
    {
        MaterialId = codeId;
        MaterialCode = codeName;
        Description = codeText;
        CategoryId = categoryId;
        CategoryName = categoryName;
    }

    public static ExtractMaterial Map(ETL.Material item) => new ExtractMaterial
    {
        MaterialId = item.MaterialId,
        MaterialCode = item.MaterialCode,
        Description = item.Description,
        CategoryId = item.CategoryId,
        CategoryName = item.Category.CategoryName
    };
}