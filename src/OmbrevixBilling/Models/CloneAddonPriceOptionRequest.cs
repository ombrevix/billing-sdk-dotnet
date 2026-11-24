using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record CloneAddonPriceOptionRequest
{
    [JsonPropertyName("price_option")]
    public required CloneAddonPriceOption PriceOption { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
