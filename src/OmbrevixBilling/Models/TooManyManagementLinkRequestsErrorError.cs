using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record TooManyManagementLinkRequestsErrorError
{
    [JsonPropertyName("errors")]
    public required TooManyManagementLinkRequests Errors { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
