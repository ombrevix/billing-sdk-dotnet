using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record AddonPriceOptionResponse
{
    [JsonPropertyName("price_option")]
    public required AddonPriceOption PriceOption { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
