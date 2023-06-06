using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract;

/// <summary>
/// Supplier Vendor class model
/// </summary>
public class ExtractSupplierVendor : IExtractObjects
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
    [JsonProperty(PropertyName = "SupplierVendorCode")]
    [ModelViewColumn(DisplayName = "SupplierVendorCode", ToDisplay = true)]
    public string SupplierVendorCode { get; set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtractSupplierVendor"/> class.
    /// </summary>
    public ExtractSupplierVendor()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtractSupplierVendor"/> class.
    /// </summary>
    /// <param name="codeId">The code id.</param>
    /// <param name="codeName">The code name.</param>
    public ExtractSupplierVendor(int codeId, string codeName)
    {
        SupplierVendorId = codeId;
        SupplierVendorCode = codeName;
    }

    /// <summary>
    /// Maps the Entity.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>An ExtractSupplierVendor.</returns>
    public static ExtractSupplierVendor Map(ETL.SupplierVendor item) => new ExtractSupplierVendor
    {
        SupplierVendorId = item.SupplierVendorId,
        SupplierVendorCode = item.SupplierVendorCode
    };
}