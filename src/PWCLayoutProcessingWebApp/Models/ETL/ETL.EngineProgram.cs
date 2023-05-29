using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.ETL;
public class EngineProgram : LayoutProcessingObjects
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

    public CodingCode? CodingCode { get; set; }

    [JsonIgnore]
    public ICollection<LayoutType> layouts { get; set; }

    public EngineProgram() { }

    public EngineProgram(int engineProgramId, string notificationId, string description, int codingCodeId, CodingCode? codingCode)
    {
        EngineProgramId = engineProgramId;
        NotificationCode = notificationId;
        Description = description;
        CodingCodeId = codingCodeId;
        CodingCode = codingCode;
    }

    public static EngineProgram Map(SqlDataReader reader)
    {
        var cols = new string[] { "CodingCode", "Coding", "CodingText" };
        var codingCode = default(CodingCode);

        if (reader.GetColumnSchema().All(col => cols.Contains(col.ColumnName)))
        {
            codingCode = new CodingCode
            {
                CodingCodeId = reader.GetFieldValue<int>(reader.GetOrdinal("CodingCodeId")),
                CodingCodeName = reader.GetFieldValue<string>(reader.GetOrdinal("Coding")),
                CodingCodeText = reader.GetFieldValue<string>(reader.GetOrdinal("CodingText"))
            };
        }

        return new EngineProgram
        {
            EngineProgramId = reader.GetFieldValue<int>(reader.GetOrdinal("Id")),
            NotificationCode = reader.GetFieldValue<string>(reader.GetOrdinal("Notification_Id")),
            Description = reader.GetFieldValue<string>(reader.GetOrdinal("Description"))?.Trim(),
            CodingCodeId = reader.GetFieldValue<int>(reader.GetOrdinal("CodingCode")),
            CodingCode = codingCode,
        };
    }
}