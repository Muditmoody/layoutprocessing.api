using Newtonsoft.Json;
using System.Data.SqlClient;
using PWCLayoutProcessingWebApp.Models.Attributes;

namespace PWCLayoutProcessingWebApp.Models.ETL;

/// <summary>
/// Damage Code Class model
/// </summary>
public class DamageCode : LayoutProcessingObjects
{
    /// <summary>
    /// Gets or sets the damage code id.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "DamageCodeId")]
    [ModelViewColumn(DisplayName = "DamageCodeId", ToDisplay = true)]
    public int DamageCodeId { get; set; }

    /// <summary>
    /// Gets or sets the damage code name.
    /// </summary>
    [ModelViewColumn(DisplayName = "DamageCode", ToDisplay = true)]
    public string DamageCodeName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the damage code text.
    /// </summary>
    [ModelViewColumn(DisplayName = "DamageText", ToDisplay = true)]
    public string DamageCodeText { get; set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="DamageCode"/> class.
    /// </summary>
    public DamageCode()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="DamageCode"/> class.
    /// </summary>
    /// <param name="codeId">The code id.</param>
    /// <param name="codeName">The code name.</param>
    /// <param name="codeText">The code text.</param>
    public DamageCode(int codeId, string codeName, string codeText)
    {
        DamageCodeId = codeId;
        DamageCodeName = codeName;
        DamageCodeText = codeText;
    }

    /// <summary>
    /// Maps the Entity.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <returns>A DamageCode.</returns>
    public static DamageCode Map(SqlDataReader reader) => new DamageCode
    {
        DamageCodeId = reader.GetFieldValue<int>(reader.GetOrdinal("Id")),
        DamageCodeName = reader.GetFieldValue<string>(reader.GetOrdinal("DamageCode")),
        DamageCodeText = reader.GetFieldValue<string>(reader.GetOrdinal("DamageText"))
    };
}