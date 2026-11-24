using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record AddonPriceOptionCurrencyOverageResponse
{
    /// <summary>
    /// Extends a addon price option with currency overage prices.
    /// </summary>
    [JsonPropertyName("price_option")]
    public required CurrencyOveragePrices PriceOption { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
