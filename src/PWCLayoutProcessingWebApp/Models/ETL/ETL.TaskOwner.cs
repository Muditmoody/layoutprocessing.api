using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.ETL;
public class TaskOwner : LayoutProcessingObjects
{
    /// <summary>
    /// Gets or sets the task owner id.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "TaskOwnerId")]
    [ModelViewColumn(DisplayName = "TaskOwnerId", ToDisplay = true)]
    public int TaskOwnerId { get; set; }

    /// <summary>
    /// Gets or sets the task owner code.
    /// </summary>
    [ModelViewColumn(DisplayName = "TaskOwnerCode", ToDisplay = true)]
    public string TaskOwnerCode { get; set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="TaskOwner"/> class.
    /// </summary>
    public TaskOwner()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="TaskOwner"/> class.
    /// </summary>
    /// <param name="codeId">The code id.</param>
    /// <param name="codeName">The code name.</param>
    public TaskOwner(int codeId, string codeName)
    {
        TaskOwnerId = codeId;
        TaskOwnerCode = codeName;
    }

    /// <summary>
    /// Maps the Entity.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <returns>A TaskOwner.</returns>
    public static TaskOwner Map(SqlDataReader reader) => new TaskOwner
    {
        TaskOwnerId = reader.GetFieldValue<int>(reader.GetOrdinal("Id")),
        TaskOwnerCode = reader.GetFieldValue<string>(reader.GetOrdinal("TaskOwner_Id")),
    };
}