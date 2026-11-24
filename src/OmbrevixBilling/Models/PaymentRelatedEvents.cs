using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record PaymentRelatedEvents
{
    [JsonPropertyName("product_id")]
    public required int ProductId { get; init; }

    [JsonPropertyName("account_transaction_id")]
    public required int AccountTransactionId { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
