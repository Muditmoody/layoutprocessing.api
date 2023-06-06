using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.ETL;
public class CauseCode : LayoutProcessingObjects
{
    /// <summary>
    /// Gets or sets the cause code id.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "CauseCodeId")]
    [ModelViewColumn(DisplayName = "Id", ToDisplay = true)]
    public int CauseCodeId { get; set; }

    /// <summary>
    /// Gets or sets the cause code name.
    /// </summary>
    [ModelViewColumn(DisplayName = "CauseCode", ToDisplay = true)]
    public string CauseCodeName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the cause text.
    /// </summary>
    [ModelViewColumn(DisplayName = "CauseText", ToDisplay = true)]
    public string CauseText { get; set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="CauseCode"/> class.
    /// </summary>
    public CauseCode()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="CauseCode"/> class.
    /// </summary>
    /// <param name="codeId">The code id.</param>
    /// <param name="codeName">The code name.</param>
    /// <param name="codeText">The code text.</param>
    public CauseCode(int codeId, string codeName, string codeText)
    {
        CauseCodeId = codeId;
        CauseCodeName = codeName;
        CauseText = codeText;
    }

    /// <summary>
    /// Maps the Entity.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <returns>A CauseCode.</returns>
    public static CauseCode Map(SqlDataReader reader) => new CauseCode
    {
        CauseCodeId = reader.GetFieldValue<int>(reader.GetOrdinal("Id")),
        CauseCodeName = reader.GetFieldValue<string>(reader.GetOrdinal("CauseCode")),
        CauseText = reader.GetFieldValue<string>(reader.GetOrdinal("CauseText"))
    };
}