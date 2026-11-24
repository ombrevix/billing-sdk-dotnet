using System.Collections.Generic;
using System.Text.Json.Serialization;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Models;

/// <summary>
/// Custom pricing for a addon within a scheduled renewal.
/// </summary>
public record ScheduledRenewalAddonCustomPrice
{
    /// <summary>
    /// Whether or not the price option includes tax
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("tax_included")]
    public bool? TaxIncluded { get; init; }

    /// <summary>
    /// Omit for Toggle addons.
    /// </summary>
    [JsonPropertyName("pricing_scheme")]
    public required PricingScheme PricingScheme { get; init; }

    /// <summary>
    /// Toggle addons only need one price bracket starting at 1.
    /// </summary>
    [JsonPropertyName("prices")]
    public required IReadOnlyList<Price> Prices { get; init; }
}
