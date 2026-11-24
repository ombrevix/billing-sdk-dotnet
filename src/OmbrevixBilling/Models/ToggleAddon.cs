using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models.AnyOf;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Models;

public record ToggleAddon
{
    /// <summary>
    /// A name for this addon that is suitable for showing customers and displaying on billing statements, e.g., "Minutes".
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

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
    /// The type of credit to be created when upgrading/downgrading. Defaults to the addon and then workspace setting if one is not provided.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("upgrade_charge")]
    public CreditType? UpgradeCharge { get; init; }

    /// <summary>
    /// The type of credit to be created when upgrading/downgrading. Defaults to the addon and then workspace setting if one is not provided.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("downgrade_credit")]
    public CreditType? DowngradeCredit { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("price_options")]
    public IReadOnlyList<AddonPriceOptionItem>? PriceOptions { get; init; }

    /// <summary>
    /// This is the amount that the customer will be charged when they turn the addon on for the subscription. The price can contain up to 8 decimal places. e.g., 1.00 or 0.0012 or 0.00000065
    /// </summary>
    [JsonPropertyName("unit_price")]
    public required UnitPrice3 UnitPrice { get; init; }

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

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("display_on_hosted_page")]
    public bool? DisplayOnHostedPage { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("allow_fractional_quantities")]
    public bool? AllowFractionalQuantities { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("hosted_signup_form_ids")]
    public IReadOnlyList<int>? HostedSignupFormIds { get; init; }

    /// <summary>
    /// The numerical interval. e.g., an interval of ‘30’ coupled with an interval_unit of day would mean this addon's default price option would renew every 30 days. This property is only available for workspaces with Multifrequency enabled.
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
