using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record CreateProductLineupRequest
{
    [JsonPropertyName("product_lineup")]
    public required CreateProductLineup ProductLineup { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
