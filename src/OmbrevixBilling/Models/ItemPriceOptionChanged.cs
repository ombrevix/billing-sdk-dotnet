using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record ItemPriceOptionChanged
{
    [JsonPropertyName("item_id")]
    public required int ItemId { get; init; }

    [JsonPropertyName("item_type")]
    public required string ItemType { get; init; }

    [JsonPropertyName("item_slug")]
    public required string ItemSlug { get; init; }

    [JsonPropertyName("item_name")]
    public required string ItemName { get; init; }

    [JsonPropertyName("previous_price_option")]
    public required ItemPriceOptionData PreviousPriceOption { get; init; }

    [JsonPropertyName("current_price_option")]
    public required ItemPriceOptionData CurrentPriceOption { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
