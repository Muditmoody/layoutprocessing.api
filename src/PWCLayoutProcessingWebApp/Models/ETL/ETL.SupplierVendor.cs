using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.ETL;
public class SupplierVendor : LayoutProcessingObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "SupplierVendorId")]
    [ModelViewColumn(DisplayName = "SupplierVendorId", ToDisplay = true)]
    public int SupplierVendorId { get; set; }

    [ModelViewColumn(DisplayName = "SupplierVendorCode", ToDisplay = true)]
    public string SupplierVendorCode { get; set; } = string.Empty;

    public SupplierVendor() { }

    public SupplierVendor(int codeId, string codeName)
    {
        SupplierVendorId = codeId;
        SupplierVendorCode = codeName;
    }

    public static SupplierVendor Map(SqlDataReader reader) => new SupplierVendor
    {
        SupplierVendorId = reader.GetFieldValue<int>(reader.GetOrdinal("Id")),
        SupplierVendorCode = reader.GetFieldValue<string>(reader.GetOrdinal("SupplierVendor_Id")),
    };
}