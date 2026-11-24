using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record SubscriptionPreviewResponse
{
    [JsonPropertyName("subscription_preview")]
    public required SubscriptionPreview SubscriptionPreview { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
