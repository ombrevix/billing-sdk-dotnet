using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record DeductServiceCreditRequest
{
    [JsonPropertyName("deduction")]
    public required DeductServiceCredit Deduction { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
