using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record SubscriptionTransitionPreviewRequest
{
    [JsonPropertyName("transition")]
    public required SubscriptionTransitionPreviewOptions Transition { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
