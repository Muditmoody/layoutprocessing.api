using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Import;
public class ImportSupplierVendor : IImportObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "SupplierVendorId")]
    [ModelViewColumn(DisplayName = "SupplierVendorId", ToDisplay = true)]
    public int SupplierVendorId { get; set; }

    [ModelViewColumn(DisplayName = "SupplierVendorCode", ToDisplay = true)]
    public string SupplierVendorCode { get; set; } = string.Empty;

    public ImportSupplierVendor() { }

    public ImportSupplierVendor(int codeId, string codeName)
    {
        SupplierVendorId = codeId;
        SupplierVendorCode = codeName;
    }
}