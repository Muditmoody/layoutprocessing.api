using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Import;
public class ImportEngineProgram : IImportObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "EngineProgramId")]
    [ModelViewColumn(DisplayName = "EngineProgramId", ToDisplay = true)]
    public int EngineProgramId { get; set; }

    [ModelViewColumn(DisplayName = "NotificationId", ToDisplay = true)]
    public string NotificationCode { get; set; } = string.Empty;

    [ModelViewColumn(DisplayName = "Description", ToDisplay = true)]
    public string Description { get; set; } = string.Empty;

    [ModelViewColumn(DisplayName = "CodingCodeId", ToDisplay = true)]
    public int CodingCodeId { get; set; }

    public string CodingCodeName { get; set; }

    [JsonIgnore]
    public ICollection<ImportLayoutType> layouts { get; set; }

    public ImportEngineProgram() { }

    public ImportEngineProgram(int engineProgramId, string notificationId, string description, int codingCodeId, string codingCodeName)
    {
        EngineProgramId = engineProgramId;
        NotificationCode = notificationId;
        Description = description;
        CodingCodeId = codingCodeId;
        CodingCodeName = codingCodeName;
    }
}