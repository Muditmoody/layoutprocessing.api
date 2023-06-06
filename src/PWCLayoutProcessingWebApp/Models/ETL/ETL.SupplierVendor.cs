using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.ETL;
public class SupplierVendor : LayoutProcessingObjects
{
    /// <summary>
    /// Gets or sets the supplier vendor id.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "SupplierVendorId")]
    [ModelViewColumn(DisplayName = "SupplierVendorId", ToDisplay = true)]
    public int SupplierVendorId { get; set; }

    /// <summary>
    /// Gets or sets the supplier vendor code.
    /// </summary>
    [ModelViewColumn(DisplayName = "SupplierVendorCode", ToDisplay = true)]
    public string SupplierVendorCode { get; set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="SupplierVendor"/> class.
    /// </summary>
    public SupplierVendor()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SupplierVendor"/> class.
    /// </summary>
    /// <param name="codeId">The code id.</param>
    /// <param name="codeName">The code name.</param>
    public SupplierVendor(int codeId, string codeName)
    {
        SupplierVendorId = codeId;
        SupplierVendorCode = codeName;
    }

    /// <summary>
    /// Maps the Entity.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <returns>A SupplierVendor.</returns>
    public static SupplierVendor Map(SqlDataReader reader) => new SupplierVendor
    {
        SupplierVendorId = reader.GetFieldValue<int>(reader.GetOrdinal("Id")),
        SupplierVendorCode = reader.GetFieldValue<string>(reader.GetOrdinal("SupplierVendor_Id")),
    };
}