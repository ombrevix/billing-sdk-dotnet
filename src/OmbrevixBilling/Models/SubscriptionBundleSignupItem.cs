using System.Collections.Generic;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record SubscriptionBundleSignupItem
{
    /// <summary>
    /// The API Slug of the product for which you are creating a subscription. Required, unless a <c>product_id</c> is given instead.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("product_slug")]
    public string? ProductSlug { get; init; }

    /// <summary>
    /// The Product ID of the product for which you are creating a subscription. You can pass either <c>product_id</c> or <c>product_slug</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("product_id")]
    public int? ProductId { get; init; }

    /// <summary>
    /// The ID of the particular price option on the product.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("product_price_option_id")]
    public int? ProductPriceOptionId { get; init; }

    /// <summary>
    /// The user-friendly API slug of a product's particular price option.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("product_price_option_slug")]
    public string? ProductPriceOptionSlug { get; init; }

    /// <summary>
    /// Use in place of passing product and addon information to set up the subscription with an existing offer. May be either the Ombrevix ID of the offer or its slug prefixed with <c>slug:</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("offer_id")]
    public int? OfferId { get; init; }

    /// <summary>
    /// The reference value (provided by your app) for the subscription itself.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("reference")]
    public string? Reference { get; init; }

    /// <summary>
    /// One of the subscriptions must be marked as primary in the group.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("primary")]
    public bool? Primary { get; init; }

    /// <summary>
    /// (Optional) If Multi-Currency is enabled and the currency is configured in Ombrevix, pass it at signup to create a subscription on a non-default currency. Note that you cannot update the currency of an existing subscription.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("currency")]
    public string? Currency { get; init; }

    /// <summary>
    /// An array for all the coupons attached to the subscription.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("coupon_codes")]
    public IReadOnlyList<string>? CouponCodes { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("addons")]
    public IReadOnlyList<SubscriptionBundleSignupAddon>? Addons { get; init; }

    /// <summary>
    /// (Optional) Used in place of <c>product_price_option_id</c> to define a custom price option unique to the subscription. A subscription can have up to 30 custom price options. Exceeding this limit will result in an API error.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("custom_price")]
    public SubscriptionCustomPrice? CustomPrice { get; init; }

    /// <summary>
    /// (Optional). Cannot be used when also specifying next_billing_at.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("calendar_billing")]
    public CalendarBilling? CalendarBilling { get; init; }

    /// <summary>
    /// (Optional) A set of key/value pairs representing custom fields and their values. Datafields will be created “on-the-fly” in your workspace for a given key, if they have not been created yet.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("datafields")]
    public IReadOnlyDictionary<string, string>? Datafields { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
