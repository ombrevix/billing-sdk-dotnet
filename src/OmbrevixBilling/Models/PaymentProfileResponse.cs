using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models.OneOf;

namespace OmbrevixBilling.Models;

public record PaymentProfileResponse
{
    [JsonPropertyName("payment_profile")]
    public required PaymentProfile PaymentProfile { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
