using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract;
public class ExtractSupplierVendor : IExtractObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "SupplierVendorId")]
    [ModelViewColumn(DisplayName = "SupplierVendorId", ToDisplay = true)]
    public int SupplierVendorId { get; set; }

    [JsonProperty(PropertyName = "SupplierVendorCode")]
    [ModelViewColumn(DisplayName = "SupplierVendorCode", ToDisplay = true)]
    public string SupplierVendorCode { get; set; } = string.Empty;

    public ExtractSupplierVendor() { }

    public ExtractSupplierVendor(int codeId, string codeName)
    {
        SupplierVendorId = codeId;
        SupplierVendorCode = codeName;
    }

    public static ExtractSupplierVendor Map(ETL.SupplierVendor item) => new ExtractSupplierVendor
    {
        SupplierVendorId = item.SupplierVendorId,
        SupplierVendorCode = item.SupplierVendorCode
    };
}