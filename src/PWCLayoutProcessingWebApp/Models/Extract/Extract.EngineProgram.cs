using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.Extract;
public class ExtractEngineProgram : IExtractObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "EngineProgramId")]
    [ModelViewColumn(DisplayName = "EngineProgramId", ToDisplay = true)]
    public int EngineProgramId { get; set; }

    [JsonProperty(PropertyName = "NotificationCode")]

    [ModelViewColumn(DisplayName = "NotificationId", ToDisplay = true)]
    public string NotificationCode { get; set; } = string.Empty;

    [JsonProperty(PropertyName = "Description")]
    [ModelViewColumn(DisplayName = "Description", ToDisplay = true)]
    public string Description { get; set; } = string.Empty;

    [JsonProperty(PropertyName = "CodingCodeId")]
    [ModelViewColumn(DisplayName = "CodingCodeId", ToDisplay = true)]
    public int CodingCodeId { get; set; }

    [JsonProperty(PropertyName = "CodingCodeName")]
    [ModelViewColumn(DisplayName = "CodingCodeName", ToDisplay = true)]
    public string CodingCodeName { get; set; }

    [JsonIgnore]
    public ICollection<ExtractLayoutType> layouts { get; set; }

    public ExtractEngineProgram() { }

    public ExtractEngineProgram(int engineProgramId, string notificationId, string description, int codingCodeId, ExtractCodingCode? codingCode)
    {
        EngineProgramId = engineProgramId;
        NotificationCode = notificationId;
        Description = description;
        CodingCodeId = codingCodeId;
        CodingCodeName = codingCode?.CodingCodeName;
    }

    public static ExtractEngineProgram Map(ETL.EngineProgram item) => new ExtractEngineProgram
    {
        EngineProgramId = item.EngineProgramId,
        NotificationCode = item.NotificationCode,
        Description = item.Description?.Trim(),
        CodingCodeId = item.CodingCodeId,
        CodingCodeName = item.CodingCode.CodingCodeName,
    };
}