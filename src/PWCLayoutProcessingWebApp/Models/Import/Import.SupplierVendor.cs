using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Import;
public class ImportSupplierVendor : IImportObjects
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
    /// Initializes a new instance of the <see cref="ImportSupplierVendor"/> class.
    /// </summary>
    public ImportSupplierVendor()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ImportSupplierVendor"/> class.
    /// </summary>
    /// <param name="codeId">The code id.</param>
    /// <param name="codeName">The code name.</param>
    public ImportSupplierVendor(int codeId, string codeName)
    {
        SupplierVendorId = codeId;
        SupplierVendorCode = codeName;
    }
}