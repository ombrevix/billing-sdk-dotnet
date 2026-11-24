using System.Collections.Generic;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record BulkCreateProductPriceOptionsRequest
{
    [JsonPropertyName("price_options")]
    public required IReadOnlyList<CreateProductPriceOption> PriceOptions { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
