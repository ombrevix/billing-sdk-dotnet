using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record CreatePrepaymentRequest
{
    [JsonPropertyName("prepayment")]
    public required CreatePrepayment Prepayment { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
