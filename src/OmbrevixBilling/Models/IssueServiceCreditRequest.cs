using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record IssueServiceCreditRequest
{
    [JsonPropertyName("service_credit")]
    public required IssueServiceCredit ServiceCredit { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
