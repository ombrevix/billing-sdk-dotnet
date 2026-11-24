using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Core.Validation;
using OmbrevixBilling.Core.Validation.Attributes;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Models;

public record PaymentMethodPaypal
{
    [JsonPropertyName("email")]
    [Format(FormatKind.Email)]
    public required string Email { get; init; }

    [JsonPropertyName("type")]
    public required InvoiceEventPaymentMethod Type { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
