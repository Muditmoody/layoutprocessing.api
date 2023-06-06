using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.ETL;
public class EngineProgram : LayoutProcessingObjects
{
    /// <summary>
    /// Gets or sets the engine program id.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "EngineProgramId")]
    [ModelViewColumn(DisplayName = "EngineProgramId", ToDisplay = true)]
    public int EngineProgramId { get; set; }

    /// <summary>
    /// Gets or sets the notification code.
    /// </summary>
    [ModelViewColumn(DisplayName = "NotificationId", ToDisplay = true)]
    public string NotificationCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    [ModelViewColumn(DisplayName = "Description", ToDisplay = true)]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the coding code id.
    /// </summary>
    [ModelViewColumn(DisplayName = "CodingCodeId", ToDisplay = true)]
    public int CodingCodeId { get; set; }

    /// <summary>
    /// Gets or sets the coding code.
    /// </summary>
    public CodingCode? CodingCode { get; set; }

    /// <summary>
    /// Gets or sets the layouts.
    /// </summary>
    [JsonIgnore]
    public ICollection<LayoutType> layouts { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="EngineProgram"/> class.
    /// </summary>
    public EngineProgram()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="EngineProgram"/> class.
    /// </summary>
    /// <param name="engineProgramId">The engine program id.</param>
    /// <param name="notificationId">The notification id.</param>
    /// <param name="description">The description.</param>
    /// <param name="codingCodeId">The coding code id.</param>
    /// <param name="codingCode">The coding code.</param>
    public EngineProgram(int engineProgramId, string notificationId, string description, int codingCodeId, CodingCode? codingCode)
    {
        EngineProgramId = engineProgramId;
        NotificationCode = notificationId;
        Description = description;
        CodingCodeId = codingCodeId;
        CodingCode = codingCode;
    }

    /// <summary>
    /// Maps the Entity.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <returns>An EngineProgram.</returns>
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