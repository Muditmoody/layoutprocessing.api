using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.ETL;
public class TaskCode : LayoutProcessingObjects
{
    /// <summary>
    /// Gets or sets the task code id.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "TaskCodeId")]
    [ModelViewColumn(DisplayName = "TaskCodeId", ToDisplay = true)]
    public int TaskCodeId { get; set; }

    /// <summary>
    /// Gets or sets the task code name.
    /// </summary>
    [ModelViewColumn(DisplayName = "TaskCodeName", ToDisplay = true)]
    public string TaskCodeName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the task code text.
    /// </summary>
    [ModelViewColumn(DisplayName = "TaskCodeText", ToDisplay = true)]
    public string TaskCodeText { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the group code id.
    /// </summary>
    [ModelViewColumn(DisplayName = "GroupCodeId", ToDisplay = true)]
    public int GroupCodeId { get; set; }

    /// <summary>
    /// Gets or sets the group code.
    /// </summary>
    public CodeGroup? GroupCode { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="TaskCode"/> class.
    /// </summary>
    public TaskCode()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="TaskCode"/> class.
    /// </summary>
    /// <param name="codeId">The code id.</param>
    /// <param name="codeName">The code name.</param>
    /// <param name="codeText">The code text.</param>
    /// <param name="groupCodeId">The group code id.</param>
    /// <param name="groupCode">The group code.</param>
    public TaskCode(int codeId, string codeName, string codeText, int groupCodeId, CodeGroup? groupCode)
    {
        TaskCodeId = codeId;
        TaskCodeName = codeName;
        TaskCodeText = codeText;
        GroupCodeId = groupCodeId;
        GroupCode = groupCode;
    }

    /// <summary>
    /// Maps the Entity.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <returns>A TaskCode.</returns>
    public static TaskCode Map(SqlDataReader reader)
    {
        var cols = new string[] { "GroupCodeId", "GroupCode", "GroupText" };
        var groupCode = default(CodeGroup);

        if (reader.GetColumnSchema().All(col => cols.Contains(col.ColumnName)))
        {
            groupCode = new CodeGroup
            {
                CodeGroupId = reader.GetFieldValue<int>(reader.GetOrdinal("GroupCodeId")),
                CodeGroupName = reader.GetFieldValue<string>(reader.GetOrdinal("GroupCode")),
                CodeGroupText = reader.GetFieldValue<string>(reader.GetOrdinal("GroupText"))
            };
        }

        return new TaskCode
        {
            TaskCodeId = reader.GetFieldValue<int>(reader.GetOrdinal("Id")),
            TaskCodeName = reader.GetFieldValue<string>(reader.GetOrdinal("TaskCode")),
            TaskCodeText = reader.GetFieldValue<string>(reader.GetOrdinal("TaskCodeText")),
            GroupCodeId = reader.GetFieldValue<int>(reader.GetOrdinal("GroupCode")),
            GroupCode = groupCode,
        };
    }
}