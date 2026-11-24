using System.Collections.Generic;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record SubscriptionBundleMembersArrayError
{
    [JsonPropertyName("members")]
    public required IReadOnlyList<string> Members { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
