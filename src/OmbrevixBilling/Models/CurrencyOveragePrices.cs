using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Models;

/// <summary>
/// Extends a addon price option with currency overage prices.
/// </summary>
public record CurrencyOveragePrices
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    /// <summary>
    /// Price option type. We expose the following types:
    /// 1. <b>default</b>: a price option that is marked as a default price for a certain product.
    /// 2. <b>custom</b>: a custom price option.
    /// 3. <b>catalog</b>: a price option that is <b>not</b> marked as a default price for a certain product and is <b>not</b> a custom one.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("type")]
    public PriceOptionType? Type { get; init; }

    /// <summary>
    /// Note: Refer to type attribute instead.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("default")]
    public bool? Default { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// The identifier for the pricing scheme. See Product Addons for an overview of pricing schemes.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("pricing_scheme")]
    public PricingScheme? PricingScheme { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("addon_id")]
    public int? AddonId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("slug")]
    public string? Slug { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("archived_at")]
    public DateTimeOffset? ArchivedAt { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("created_at")]
    public DateTimeOffset? CreatedAt { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("updated_at")]
    public DateTimeOffset? UpdatedAt { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("prices")]
    public IReadOnlyList<AddonPrice>? Prices { get; init; }

    /// <summary>
    /// Whether to use the workspace level exchange rate or define your own prices for each currency if you have multiple currencies defined on the workspace. Defaults to true during creation.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("use_workspace_exchange_rate")]
    public bool? UseWorkspaceExchangeRate { get; init; }

    /// <summary>
    /// (only used for Custom Pricing - ie. when the price option's type is <c>custom</c>) The id of the subscription that the custom price option is for.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("subscription_id")]
    public int? SubscriptionId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("tax_included")]
    public bool? TaxIncluded { get; init; }

    /// <summary>
    /// The numerical interval. e.g., an interval of ‘30’ coupled with an interval_unit of day would mean this addon price option would renew every 30 days. This property is only available for workspaces with Multifrequency enabled.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("interval")]
    public int? Interval { get; init; }

    /// <summary>
    /// A string representing the interval unit for this addon price option, either month or day. This property is only available for workspaces with Multifrequency enabled.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("interval_unit")]
    public IntervalUnit? IntervalUnit { get; init; }

    /// <summary>
    /// An array of currency pricing data is available when multiple currencies are defined for the workspace. It varies based on the use_workspace_exchange_rate setting for the price option. This parameter is present only in the response of read endpoints, after including the appropriate query parameter. The clone endpoint always returns currency prices if they are present.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("currency_prices")]
    public IReadOnlyList<AddonCurrencyPrice>? CurrencyPrices { get; init; }

    /// <summary>
    /// Applicable only to prepaid usage addons. An array of overage price brackets.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("overage_prices")]
    public IReadOnlyList<AddonPrice>? OveragePrices { get; init; }

    /// <summary>
    /// Applicable only to prepaid usage addons. Pricing scheme for overage pricing.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("overage_pricing_scheme")]
    public PricingScheme? OveragePricingScheme { get; init; }

    /// <summary>
    /// Applicable only to prepaid usage addons. Boolean which controls whether or not the provisioned quantity should be renewed at the beginning of each period.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("renew_prepaid_provision")]
    public bool? RenewPrepaidProvision { get; init; }

    /// <summary>
    /// Applicable only to prepaid usage addons. Boolean which controls whether or not remaining units should be rolled over to the next period.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("rollover_prepaid_remainder")]
    public bool? RolloverPrepaidRemainder { get; init; }

    /// <summary>
    /// Applicable only to prepaid usage addons where rollover_prepaid_remainder is true. The number of <c>expiration_interval_unit</c>s after which rollover amounts should expire.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("expiration_interval")]
    public int? ExpirationInterval { get; init; }

    /// <summary>
    /// Applicable only to prepaid usage addons where rollover_prepaid_remainder is true. A string representing the expiration interval unit for this addon, either month or day.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("expiration_interval_unit")]
    public ExpirationIntervalUnit? ExpirationIntervalUnit { get; init; }

    /// <summary>
    /// Applicable only to prepaid usage addons. An array of currency pricing data for overage prices.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("currency_overage_prices")]
    public IReadOnlyList<AddonCurrencyPrice>? CurrencyOveragePricesValue { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
