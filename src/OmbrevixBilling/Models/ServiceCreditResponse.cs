using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record ServiceCreditResponse
{
    [JsonPropertyName("service_credit")]
    public required ServiceCredit ServiceCredit { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
