using System.Collections.Generic;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record ListAddonsPriceOptionsResponse
{
    [JsonPropertyName("price_options")]
    public required IReadOnlyList<AddonPriceOption> PriceOptions { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
