using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models.AnyOf;

namespace OmbrevixBilling.Models;

public record RenewalPreviewAddon
{
    /// <summary>
    /// Either the addon's Ombrevix id or its slug prefixed with <c>slug:</c>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("addon_id")]
    public AddonId2? AddonId { get; init; }

    /// <summary>
    /// The quantity for which you wish to preview billing. This is useful if you want to preview a predicted, higher usage value than is currently present on the subscription.
    /// <para>
    /// This quantity represents:
    /// </para>
    /// <list type="bullet">
    ///   <item><description>Whether or not an Toggle addon is enabled - use 0 for disabled or 1 for enabled</description></item>
    ///   <item><description>The desired provisioned_quantity for a seat-based addon</description></item>
    ///   <item><description>The desired unit_balance for a metered addon</description></item>
    ///   <item><description>The desired metric quantity for an events-based addon</description></item>
    /// </list>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("quantity")]
    public int? Quantity { get; init; }

    /// <summary>
    /// Either the addon price option's Ombrevix id or its slug prefixed with <c>slug:</c>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("price_option_id")]
    public PriceOptionId3? PriceOptionId { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
