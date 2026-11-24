using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record SubscriptionMrr
{
    [JsonPropertyName("subscription_id")]
    public required int SubscriptionId { get; init; }

    [JsonPropertyName("mrr_amount_minor")]
    public required long MrrAmountMinor { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("breakouts")]
    public SubscriptionMrrBreakout? Breakouts { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
