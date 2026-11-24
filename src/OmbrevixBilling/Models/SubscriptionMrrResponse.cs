using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Core.Validation.Attributes;

namespace OmbrevixBilling.Models;

public record SubscriptionMrrResponse
{
    [JsonPropertyName("subscriptions_mrr")]
    [MinLength(1)]
    [UniqueItems]
    public required IReadOnlyList<SubscriptionMrr> SubscriptionsMrr { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
