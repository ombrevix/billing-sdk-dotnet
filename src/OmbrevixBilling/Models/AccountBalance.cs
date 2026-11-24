using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record AccountBalance
{
    /// <summary>
    /// The balance minor.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("balance_minor")]
    public long? BalanceMinor { get; init; }

    /// <summary>
    /// The automatic balance minor.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("automatic_balance_minor")]
    public long? AutomaticBalanceMinor { get; init; }

    /// <summary>
    /// The manual balance minor.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("manual_balance_minor")]
    public long? ManualBalanceMinor { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
