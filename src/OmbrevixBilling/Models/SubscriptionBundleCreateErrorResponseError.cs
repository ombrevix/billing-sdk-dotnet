using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models.AnyOf;

namespace OmbrevixBilling.Models;

public record SubscriptionBundleCreateErrorResponseError
{
    [JsonPropertyName("errors")]
    public required Errors11 Errors { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
