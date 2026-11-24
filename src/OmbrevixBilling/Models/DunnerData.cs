using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record DunnerData
{
    [JsonPropertyName("state")]
    public required string State { get; init; }

    [JsonPropertyName("subscription_id")]
    public required int SubscriptionId { get; init; }

    [JsonPropertyName("revenue_at_risk_minor")]
    public required long RevenueAtRiskMinor { get; init; }

    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("attempts")]
    public required int Attempts { get; init; }

    [JsonPropertyName("last_attempted_at")]
    public required DateTimeOffset LastAttemptedAt { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
