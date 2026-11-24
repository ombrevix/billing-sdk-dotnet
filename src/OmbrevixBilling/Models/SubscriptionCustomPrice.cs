using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models.AnyOf;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Models;

/// <summary>
/// (Optional) Used in place of <c>product_price_option_id</c> to define a custom price option unique to the subscription. A subscription can have up to 30 custom price options. Exceeding this limit will result in an API error.
/// </summary>
public record SubscriptionCustomPrice
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
    [JsonPropertyName("trial_price_minor")]
    public TrialPriceMinor? TrialPriceMinor { get; init; }

    /// <summary>
    /// (Optional)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("trial_interval")]
    public TrialInterval? TrialInterval { get; init; }

    /// <summary>
    /// (Optional)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("trial_interval_unit")]
    public IntervalUnit? TrialIntervalUnit { get; init; }

    /// <summary>
    /// Indicates how a trial is handled when the trial period ends and there is no credit card on file. For <c>no_obligation</c>, the subscription transitions to a Trial Ended state. Ombrevix will not send any emails or statements. For <c>payment_expected</c>, the subscription transitions to a Past Due state. Ombrevix will send normal recovery emails and statements according to your other settings.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("trial_type")]
    public TrialType? TrialType { get; init; }

    /// <summary>
    /// (Optional)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("initial_charge_minor")]
    public InitialChargeMinor? InitialChargeMinor { get; init; }

    /// <summary>
    /// (Optional)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("initial_charge_after_trial")]
    public bool? InitialChargeAfterTrial { get; init; }

    /// <summary>
    /// (Optional)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("expiration_interval")]
    public ExpirationInterval? ExpirationInterval { get; init; }

    /// <summary>
    /// (Optional)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("expiration_interval_unit")]
    public ExpirationIntervalUnit? ExpirationIntervalUnit { get; init; }

    /// <summary>
    /// (Optional)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("tax_included")]
    public bool? TaxIncluded { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
