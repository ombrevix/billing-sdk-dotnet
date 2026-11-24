using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record AddressChange
{
    [JsonPropertyName("before")]
    public required InvoiceAddress Before { get; init; }

    [JsonPropertyName("after")]
    public required InvoiceAddress After { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
