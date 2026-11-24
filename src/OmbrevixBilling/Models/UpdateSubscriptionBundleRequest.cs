using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record UpdateSubscriptionBundleRequest
{
    [JsonPropertyName("subscription_bundle")]
    public required UpdateSubscriptionBundle SubscriptionBundle { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
