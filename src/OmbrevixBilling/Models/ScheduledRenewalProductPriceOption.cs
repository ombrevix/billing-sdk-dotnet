using System.Text.Json.Serialization;
using OmbrevixBilling.Models.AnyOf;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Models;

/// <summary>
/// Custom pricing for a product within a scheduled renewal.
/// </summary>
public record ScheduledRenewalProductPriceOption
{
    /// <summary>
    /// (Optional)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// (Optional)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("slug")]
    public string? Slug { get; init; }

    /// <summary>
    /// Required if using <c>custom_price</c> attribute.
    /// </summary>
    [JsonPropertyName("price_minor")]
    public required PriceMinor PriceMinor { get; init; }

    /// <summary>
    /// Required if using <c>custom_price</c> attribute.
    /// </summary>
    [JsonPropertyName("interval")]
    public required Interval Interval { get; init; }

    /// <summary>
    /// Required if using <c>custom_price</c> attribute.
    /// </summary>
    [JsonPropertyName("interval_unit")]
    public required IntervalUnit? IntervalUnit { get; init; }

    /// <summary>
    /// (Optional)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("tax_included")]
    public bool? TaxIncluded { get; init; }

    /// <summary>
    /// The product price option initial charge, in integer cents.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("initial_charge_minor")]
    public long? InitialChargeMinor { get; init; }

    /// <summary>
    /// The numerical expiration interval. e.g., an expiration_interval of ‘30’ coupled with an expiration_interval_unit of day would mean this product price option would expire after 30 days.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("expiration_interval")]
    public int? ExpirationInterval { get; init; }

    /// <summary>
    /// A string representing the expiration interval unit for this product price option, either month, day or never
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("expiration_interval_unit")]
    public ExpirationIntervalUnit? ExpirationIntervalUnit { get; init; }
}
