using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models.AnyOf;

namespace OmbrevixBilling.Models;

public record SubscriptionBundleSignupAddon
{
    /// <summary>
    /// Required if passing any addon to <c>addons</c> attribute.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("addon_id")]
    public AddonId? AddonId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("provisioned_quantity")]
    public ProvisionedQuantity1? ProvisionedQuantity { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("unit_balance")]
    public UnitBalance? UnitBalance { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("price_option_id")]
    public PriceOptionId? PriceOptionId { get; init; }

    /// <summary>
    /// Used in place of <c>price_option_id</c> to define a custom price option unique to the subscription. You still need to provide <c>addon_id</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("custom_price")]
    public SubscriptionBundleAddonCustomPrice? CustomPrice { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
