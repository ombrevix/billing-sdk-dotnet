using System.Collections.Generic;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Models;

/// <summary>
/// Used to Create or Update Endpoint.
/// </summary>
public record CreateOrUpdateEndpoint
{
    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("webhook_subscriptions")]
    public required IReadOnlyList<WebhookSubscription> WebhookSubscriptions { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
