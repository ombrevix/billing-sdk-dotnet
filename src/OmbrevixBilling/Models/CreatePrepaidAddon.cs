using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record CreatePrepaidAddon
{
    [JsonPropertyName("prepaid_usage_addon")]
    public required PrepaidUsageAddon PrepaidUsageAddon { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
