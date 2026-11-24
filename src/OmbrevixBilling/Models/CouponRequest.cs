using System.Collections.Generic;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record CouponRequest
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("coupon")]
    public CouponPayload? Coupon { get; init; }

    /// <summary>
    /// An object where the keys are product IDs or slugs (prefixed with 'slug:'), and the values are booleans indicating if the coupon should be applicable to the product.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("restricted_products")]
    public IReadOnlyDictionary<string, bool>? RestrictedProducts { get; init; }

    /// <summary>
    /// An object where the keys are addon IDs or slugs (prefixed with 'slug:'), and the values are booleans indicating if the coupon should be applicable to the addon.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("restricted_addons")]
    public IReadOnlyDictionary<string, bool>? RestrictedAddons { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
