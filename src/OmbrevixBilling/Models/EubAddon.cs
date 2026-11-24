using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models.AnyOf;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Models;

public record EubAddon
{
    /// <summary>
    /// A name for this addon that is suitable for showing customers and displaying on billing statements, i.e., "Minutes".
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// “The name of the unit of measurement for the addon. It should be singular since it will be automatically pluralized when necessary. i.e., “message”, which may then be shown as “5 messages” on a subscription’s addon line-item”
    /// </summary>
    [JsonPropertyName("unit_name")]
    public required string UnitName { get; init; }

    /// <summary>
    /// A description for the addon that will be displayed to the user on the hosted signup page.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// A unique identifier for your use that can be used to retrieve this addon in subsequent requests. Must start with a letter or number and may only contain lowercase letters, numbers, or the characters '.', ':', '-', or '_'.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("slug")]
    [RegularExpression("^[a-z0-9][a-z0-9\\-_:.]*$")]
    public string? Slug { get; init; }

    /// <summary>
    /// Boolean flag describing whether a addon is taxable or not.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("taxable")]
    public bool? Taxable { get; init; }

    /// <summary>
    /// The identifier for the pricing scheme. See Product Addons for an overview of pricing schemes.
    /// </summary>
    [JsonPropertyName("pricing_scheme")]
    public required PricingScheme PricingScheme { get; init; }

    /// <summary>
    /// (Not required for ‘per_unit’ pricing schemes) One or more price brackets. See Price Bracket Rules for an overview of how price brackets work for different pricing schemes.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("prices")]
    public IReadOnlyList<Price>? Prices { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("price_options")]
    public IReadOnlyList<AddonPriceOptionItem>? PriceOptions { get; init; }

    /// <summary>
    /// The amount the customer will be charged per unit when the pricing scheme is “per_unit”. The price can contain up to 8 decimal places. i.e., 1.00 or 0.0012 or 0.00000065
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("unit_price")]
    public UnitPrice5? UnitPrice { get; init; }

    /// <summary>
    /// A string representing the tax code related to the addon type. This is especially important when using AvaTax to tax based on locale. This attribute has a max length of 25 characters.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("tax_code")]
    public string? TaxCode { get; init; }

    /// <summary>
    /// (Only available on Account Invoicing workspaces) Boolean flag describing if the service date range should show for the addon on generated invoices.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("hide_date_range_on_invoice")]
    public bool? HideDateRangeOnInvoice { get; init; }

    /// <summary>
    /// The ID of an event based billing metric that will be attached to this addon.
    /// </summary>
    [JsonPropertyName("event_based_billing_metric_id")]
    public required int EventBasedBillingMetricId { get; init; }

    /// <summary>
    /// The numerical interval. i.e., an interval of ‘30’ coupled with an interval_unit of day would mean this addon's default price option would renew every 30 days. This property is only available for workspaces with Multifrequency enabled.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("interval")]
    public int? Interval { get; init; }

    /// <summary>
    /// A string representing the interval unit for this addon's default price option, either month or day. This property is only available for workspaces with Multifrequency enabled.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("interval_unit")]
    public IntervalUnit? IntervalUnit { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
