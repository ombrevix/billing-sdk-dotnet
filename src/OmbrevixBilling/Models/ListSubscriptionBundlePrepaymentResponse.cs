using System.Collections.Generic;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record ListSubscriptionBundlePrepaymentResponse
{
    [JsonPropertyName("prepayments")]
    public required IReadOnlyList<ListSubscriptionBundlePrepayment> Prepayments { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
