using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record SubscriptionTransitionPreviewResponse
{
    [JsonPropertyName("transition")]
    public required SubscriptionTransitionPreview Transition { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
