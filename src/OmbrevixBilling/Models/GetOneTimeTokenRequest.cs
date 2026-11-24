using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record GetOneTimeTokenRequest
{
    [JsonPropertyName("payment_profile")]
    public required GetOneTimeTokenPaymentProfile PaymentProfile { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
