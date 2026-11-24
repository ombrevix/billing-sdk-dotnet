using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

/// <summary>
/// Billing schedule settings for addon provisions or usages on multi-frequency subscriptions. Use this to start a addon's billing period on a custom date instead of aligning with the product charge schedule.
/// </summary>
public record BillingSchedule
{
    /// <summary>
    /// Custom start date (ISO 8601 date, YYYY-MM-DD) for the addon's first billing period. If omitted or null, billing aligns with the product schedule. If provided, date must be on or after the minimum allowed date for the subscription or addon.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("initial_billing_at")]
    public DateTimeOffset? InitialBillingAt { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
