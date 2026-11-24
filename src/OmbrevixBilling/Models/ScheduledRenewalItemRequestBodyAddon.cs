using System.Text.Json.Serialization;

namespace OmbrevixBilling.Models;

public record ScheduledRenewalItemRequestBodyAddon
{
    /// <summary>
    /// Item type to add. Either Product or Addon.
    /// </summary>
    [JsonPropertyName("item_type")]
    public string ItemType { get; } = "Addon";

    /// <summary>
    /// Product or addon identifier.
    /// </summary>
    [JsonPropertyName("item_id")]
    public required int ItemId { get; init; }

    /// <summary>
    /// Price option identifier.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("price_option_id")]
    public int? PriceOptionId { get; init; }

    /// <summary>
    /// (Optional) Quantity for the item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("quantity")]
    public int? Quantity { get; init; }

    /// <summary>
    /// Custom pricing for a addon within a scheduled renewal.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("custom_price")]
    public ScheduledRenewalAddonCustomPrice? CustomPrice { get; init; }
}
