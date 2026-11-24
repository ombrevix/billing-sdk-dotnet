using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record ProductPriceOptionErrorResponseError
{
    [JsonPropertyName("errors")]
    public required ProductPriceOptionErrors Errors { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
