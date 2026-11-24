using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record SubscriptionTransitionPreviewOptions
{
    /// <summary>
    /// The ID of the target Product. Either a product_id or product_slug must be present. A Subscription can be transitioned to another product for both the current Product lineup and another Product lineup. Note: Going to another Product lineup, addons will not be transitioned as well.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("product_id")]
    public int? ProductId { get; init; }

    /// <summary>
    /// The ID of the specified product's price option. This can be passed to transition to a non-default price option.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("product_price_option_id")]
    public int? ProductPriceOptionId { get; init; }

    /// <summary>
    /// Whether to include the trial period configured for the product price option when starting a new billing period. Note that if preserve_period is set, then include_trial will be ignored.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("include_trial")]
    public bool? IncludeTrial { get; init; } = false;

    /// <summary>
    /// If <c>true</c> is sent initial charges will be assessed.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("include_initial_charge")]
    public bool? IncludeInitialCharge { get; init; } = false;

    /// <summary>
    /// If <c>true</c> is sent, any coupons associated with the subscription will be applied to the transition. If <c>false</c> is sent, coupons will not be applied. Note: When transitioning to a new product lineup, the coupon cannot transition.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("include_coupons")]
    public bool? IncludeCoupons { get; init; } = true;

    /// <summary>
    /// If <c>false</c> is sent, the subscription's billing period will be reset to today and the full price of the new product will be charged. If <c>true</c> is sent, the billing period will not change and a prorated charge will be issued for the new product.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("preserve_period")]
    public bool? PreservePeriod { get; init; } = false;

    /// <summary>
    /// The slug of the target Product. Either a product_id or product_slug must be present. A Subscription can be transitioned to another product for both the current Product lineup and another Product lineup. Note: Going to another Product lineup, addons will not be transitioned as well.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("product_slug")]
    public string? ProductSlug { get; init; }

    /// <summary>
    /// The ID or slug of the specified product's price option. This can be passed to transition to a non-default price option.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("product_price_option_slug")]
    public string? ProductPriceOptionSlug { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("proration")]
    public Proration? Proration { get; init; }

    /// <summary>
    /// The date that the proration is calculated from for the preview
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("proration_date")]
    public DateTimeOffset? ProrationDate { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
