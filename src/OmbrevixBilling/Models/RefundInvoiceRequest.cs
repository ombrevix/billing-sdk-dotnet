using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models.AnyOf;

namespace OmbrevixBilling.Models;

public record RefundInvoiceRequest
{
    [JsonPropertyName("refund")]
    public required Refund Refund { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
