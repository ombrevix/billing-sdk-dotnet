using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record SubscriptionMrrBreakout
{
    [JsonPropertyName("plan_amount_minor")]
    public required long PlanAmountMinor { get; init; }

    [JsonPropertyName("usage_amount_minor")]
    public required long UsageAmountMinor { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
