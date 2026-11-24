using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record SubscriptionBundleSignupEventData
{
    [JsonPropertyName("subscription_bundle")]
    public required SubscriptionBundleSignupFailureData SubscriptionBundle { get; init; }

    [JsonPropertyName("customer")]
    public required Customer? Customer { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
