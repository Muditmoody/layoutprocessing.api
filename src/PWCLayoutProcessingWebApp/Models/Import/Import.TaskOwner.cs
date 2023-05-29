using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Import;
public class ImportTaskOwner : IImportObjects
{
    [ModelViewColumn(DisplayName = "TaskOwnerCode", ToDisplay = true)]
    public string TaskOwnerCode { get; set; } = string.Empty;

    public ImportTaskOwner() { }

    public ImportTaskOwner(string codeName)
    {
        TaskOwnerCode = codeName;
    }
}