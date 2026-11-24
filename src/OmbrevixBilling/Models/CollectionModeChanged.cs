using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record CollectionModeChanged
{
    [JsonPropertyName("previous_value")]
    public required string PreviousValue { get; init; }

    [JsonPropertyName("current_value")]
    public required string CurrentValue { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
