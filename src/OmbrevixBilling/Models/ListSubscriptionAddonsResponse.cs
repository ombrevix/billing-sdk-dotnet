using System.Collections.Generic;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record ListSubscriptionAddonsResponse
{
    [JsonPropertyName("subscriptions_addons")]
    public required IReadOnlyList<SubscriptionAddon> SubscriptionsAddons { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
