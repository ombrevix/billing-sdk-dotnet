using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record CreateMultiInvoicePaymentRequest
{
    [JsonPropertyName("payment")]
    public required CreateMultiInvoicePayment Payment { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
