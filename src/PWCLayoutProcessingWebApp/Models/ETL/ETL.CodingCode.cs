using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.ETL;
public class CodingCode : LayoutProcessingObjects
{
    /// <summary>
    /// Gets or sets the coding code id.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "CodingCodeId")]
    [ModelViewColumn(DisplayName = "CodingCodeId", ToDisplay = true)]
    public int CodingCodeId { get; set; }

    /// <summary>
    /// Gets or sets the coding code name.
    /// </summary>
    [ModelViewColumn(DisplayName = "CodingCodeName", ToDisplay = true)]
    public string CodingCodeName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the coding code text.
    /// </summary>
    [ModelViewColumn(DisplayName = "CodingText", ToDisplay = true)]
    public string CodingCodeText { get; set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="CodingCode"/> class.
    /// </summary>
    public CodingCode()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="CodingCode"/> class.
    /// </summary>
    /// <param name="codeId">The code id.</param>
    /// <param name="codeName">The code name.</param>
    /// <param name="codeText">The code text.</param>
    public CodingCode(int codeId, string codeName, string codeText)
    {
        CodingCodeId = codeId;
        CodingCodeName = codeName;
        CodingCodeText = codeText;
    }

    /// <summary>
    /// Maps the Entity Entity
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <returns>A CodingCode.</returns>
    public static CodingCode Map(SqlDataReader reader) => new CodingCode
    {
        CodingCodeId = reader.GetFieldValue<int>(reader.GetOrdinal("Id")),
        CodingCodeName = reader.GetFieldValue<string>(reader.GetOrdinal("Coding")),
        CodingCodeText = reader.GetFieldValue<string>(reader.GetOrdinal("CodingText"))
    };
}