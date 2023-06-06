using Newtonsoft.Json;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Import;
public class ImportMaterial : IImportObjects
{
    /// <summary>
    /// Gets or sets the material id.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "MaterialId")]
    [ModelViewColumn(DisplayName = "MaterialId", ToDisplay = true)]
    public int MaterialId { get; set; }

    /// <summary>
    /// Gets or sets the material code.
    /// </summary>
    [ModelViewColumn(DisplayName = "MaterialCode", ToDisplay = true)]
    public string MaterialCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    [ModelViewColumn(DisplayName = "Description", ToDisplay = true)]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="ImportMaterial"/> class.
    /// </summary>
    public ImportMaterial()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ImportMaterial"/> class.
    /// </summary>
    /// <param name="codeId">The code id.</param>
    /// <param name="codeName">The code name.</param>
    /// <param name="codeText">The code text.</param>
    public ImportMaterial(int codeId, string codeName, string codeText)
    {
        MaterialId = codeId;
        MaterialCode = codeName;
        Description = codeText;
    }
}