using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record CreateSubscriptionBundleRequest
{
    [JsonPropertyName("subscription_bundle")]
    public required CreateSubscriptionBundle SubscriptionBundle { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
