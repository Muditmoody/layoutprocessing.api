using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.ETL;
public class TaskCode : LayoutProcessingObjects
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "TaskCodeId")]
    [ModelViewColumn(DisplayName = "TaskCodeId", ToDisplay = true)]
    public int TaskCodeId { get; set; }

    [ModelViewColumn(DisplayName = "TaskCodeName", ToDisplay = true)]
    public string TaskCodeName { get; set; } = string.Empty;

    [ModelViewColumn(DisplayName = "TaskCodeText", ToDisplay = true)]
    public string TaskCodeText { get; set; } = string.Empty;

    [ModelViewColumn(DisplayName = "GroupCodeId", ToDisplay = true)]
    public int GroupCodeId { get; set; }

    public CodeGroup? GroupCode { get; set; }

    public TaskCode() { }

    public TaskCode(int codeId, string codeName, string codeText, int groupCodeId, CodeGroup? groupCode)
    {
        TaskCodeId = codeId;
        TaskCodeName = codeName;
        TaskCodeText = codeText;
        GroupCodeId = groupCodeId;
        GroupCode = groupCode;
    }

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