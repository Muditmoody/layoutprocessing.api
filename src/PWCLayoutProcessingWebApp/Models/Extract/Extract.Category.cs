using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Text.Json.Serialization;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract;
public class ExtractCategory : IExtractObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "CategoryId")]
    [ModelViewColumn(DisplayName = "Id", ToDisplay = true)]
    public int CategoryId { get; set; }

    [JsonProperty(PropertyName = "CategoryName")]
    [ModelViewColumn(DisplayName = "CategoryName", ToDisplay = true)]
    public string CategoryName { get; set; } = string.Empty;


    public ExtractCategory() { }

    public ExtractCategory(int categoryId, string categoryName)
    {
        CategoryId = categoryId;
        CategoryName = categoryName;
    }

    public static ExtractCategory Map(ETL.Category item) => new ExtractCategory
    {
        CategoryId = item.CategoryId,
        CategoryName = item.CategoryName
    };
}