using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.ETL;
public class CodeGroup : LayoutProcessingObjects
{
    /// <summary>
    /// Gets or sets the code group id.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "CodeGroupId")]
    [ModelViewColumn(DisplayName = "CodeGroupId", ToDisplay = true)]
    public int CodeGroupId { get; set; }

    /// <summary>
    /// Gets or sets the code group name.
    /// </summary>
    [ModelViewColumn(DisplayName = "GroupCode", ToDisplay = true)]
    public string CodeGroupName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the code group text.
    /// </summary>
    [ModelViewColumn(DisplayName = "GroupText", ToDisplay = true)]
    public string CodeGroupText { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the task codes.
    /// </summary>
    [JsonIgnore]
    public ICollection<TaskCode>? TaskCodes { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CodeGroup"/> class.
    /// </summary>
    public CodeGroup()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="CodeGroup"/> class.
    /// </summary>
    /// <param name="codeId">The code id.</param>
    /// <param name="codeName">The code name.</param>
    /// <param name="codeText">The code text.</param>
    public CodeGroup(int codeId, string codeName, string codeText)
    {
        CodeGroupId = codeId;
        CodeGroupName = codeName;
        CodeGroupText = codeText;
    }

    /// <summary>
    /// Maps the Entity.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <returns>A CodeGroup.</returns>
    public static CodeGroup Map(SqlDataReader reader) => new CodeGroup
    {
        CodeGroupId = reader.GetFieldValue<int>(reader.GetOrdinal("Id")),
        CodeGroupName = reader.GetFieldValue<string>(reader.GetOrdinal("GroupCode")),
        CodeGroupText = reader.GetFieldValue<string>(reader.GetOrdinal("GroupText"))
    };
}