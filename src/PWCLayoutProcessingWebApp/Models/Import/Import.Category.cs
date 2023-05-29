using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Text.Json.Serialization;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Import;
public class ImportCategory : IImportObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "CategoryId")]
    [ModelViewColumn(DisplayName = "Id", ToDisplay = true)]
    public int CategoryId { get; set; }

    [JsonProperty(PropertyName = "CategoryName")]
    [ModelViewColumn(DisplayName = "CategoryName", ToDisplay = true)]
    public string CategoryName { get; set; } = string.Empty;

    public ImportCategory() { }

    public ImportCategory(int categoryId, string categoryName)
    {
        CategoryId = categoryId;
        CategoryName = categoryName;
    }

}