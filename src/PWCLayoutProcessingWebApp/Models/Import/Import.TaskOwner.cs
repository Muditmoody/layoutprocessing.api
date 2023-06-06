using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Import;
public class ImportTaskOwner : IImportObjects
{
    /// <summary>
    /// Gets or sets the task owner code.
    /// </summary>
    [ModelViewColumn(DisplayName = "TaskOwnerCode", ToDisplay = true)]
    public string TaskOwnerCode { get; set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="ImportTaskOwner"/> class.
    /// </summary>
    public ImportTaskOwner()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ImportTaskOwner"/> class.
    /// </summary>
    /// <param name="codeName">The code name.</param>
    public ImportTaskOwner(string codeName)
    {
        TaskOwnerCode = codeName;
    }
}