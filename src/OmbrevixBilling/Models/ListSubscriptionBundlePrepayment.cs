using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record ListSubscriptionBundlePrepayment
{
    [JsonPropertyName("prepayment")]
    public required ListSubscriptionBundlePrepaymentItem Prepayment { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
