using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models.AnyOf;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Models;

public record CreateProvision
{
    /// <summary>
    /// The provisioned quantity to which to set the line-items provisioned quantity. By default, this is an integer. If decimal provisions are enabled for the addon, it will be a decimal number. For Toggle addons, use 1 for on and 0 for off.
    /// </summary>
    [JsonPropertyName("quantity")]
    public required double Quantity { get; init; }

    /// <summary>
    /// Decimal representation of the provisioned quantity. Only valid when decimal
    /// provisions are enabled for the addon.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("decimal_quantity")]
    public string? DecimalQuantity { get; init; }

    /// <summary>
    /// The quantity that was in effect before this provision. Responses always
    /// include this value; it may be supplied on preview requests to ensure the
    /// expected change is evaluated.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("previous_quantity")]
    public double? PreviousQuantity { get; init; }

    /// <summary>
    /// Decimal representation of <c>previous_quantity</c>. Only valid when decimal
    /// provisions are enabled for the addon.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("decimal_previous_quantity")]
    public string? DecimalPreviousQuantity { get; init; }

    /// <summary>
    /// (required for the multiple provisions endpoint) The id associated with the addon for which the provision is being made.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("addon_id")]
    public int? AddonId { get; init; }

    /// <summary>
    /// A memo to record along with the provision.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("memo")]
    public string? Memo { get; init; }

    /// <summary>
    /// The scheme used if the proration is a downgrade. Defaults to the workspace setting if one is not provided.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("proration_downgrade_scheme")]
    public string? ProrationDowngradeScheme { get; init; }

    /// <summary>
    /// The scheme used if the proration is an upgrade. Defaults to the workspace setting if one is not provided.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("proration_upgrade_scheme")]
    public string? ProrationUpgradeScheme { get; init; }

    /// <summary>
    /// The type of credit to be created when upgrading/downgrading. Defaults to the addon and then workspace setting if one is not provided. Values are:
    /// <para>
    /// <c>full</c> -  A full price credit is added for the amount owed.
    /// </para>
    /// <para>
    /// <c>prorated</c> - A prorated credit is added for the amount owed.
    /// </para>
    /// <para>
    /// <c>none</c> - No charge is added.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("downgrade_credit")]
    public DowngradeCreditCreditType? DowngradeCredit { get; init; }

    /// <summary>
    /// The type of credit to be created when upgrading/downgrading. Defaults to the addon and then workspace setting if one is not provided. Values are:
    /// <para>
    /// <c>full</c> - A charge is added for the full price of the addon.
    /// </para>
    /// <para>
    /// <c>prorated</c> - A charge is added for the prorated price of the addon change.
    /// </para>
    /// <para>
    /// <c>none</c> - No charge is added.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("upgrade_charge")]
    public UpgradeChargeCreditType? UpgradeCharge { get; init; }

    /// <summary>
    /// "If the change in cost is an upgrade, this determines if the charge should accrue to the next renewal or if capture should be attempted immediately.
    /// <para>
    /// <c>true</c> - Attempt to charge the customer at the next renewal.
    /// </para>
    /// <para>
    /// <c>false</c> - Attempt to charge the customer right away. If it fails, the charge will be accrued until the next renewal.
    /// </para>
    /// <para>
    /// Defaults to the workspace setting if unspecified in the request.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("accrue_charge")]
    public bool? AccrueCharge { get; init; }

    /// <summary>
    /// If set to true, if the immediate addon payment fails, initiate recovery for the subscription.
    /// Otherwise, leave the charges on the subscription to pay for at renewal. Defaults to false.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("initiate_recovery")]
    public bool? InitiateRecovery { get; init; }

    /// <summary>
    /// Price option that the provision should be charged at. Accepts either the price option's id (integer) or slug (string). When not specified, the default price option will be used.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("price_option_id")]
    public PriceOptionId1? PriceOptionId { get; init; }

    /// <summary>
    /// Billing schedule settings for addon provisions or usages on multi-frequency subscriptions. Use this to start a addon's billing period on a custom date instead of aligning with the product charge schedule.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("billing_schedule")]
    public BillingSchedule? BillingSchedule { get; init; }

    /// <summary>
    /// Create or update custom pricing unique to the subscription. Used in place of <c>price_option_id</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("custom_price")]
    public AddonCustomPrice? CustomPrice { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
