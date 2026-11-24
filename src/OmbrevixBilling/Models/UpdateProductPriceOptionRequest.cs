using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record UpdateProductPriceOptionRequest
{
    [JsonPropertyName("price_option")]
    public required UpdateProductPriceOption PriceOption { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
