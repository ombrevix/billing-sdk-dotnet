using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record EventBasedBillingSegmentError1
{
    [JsonPropertyName("errors")]
    public required EventBasedBillingSegmentError Errors { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
