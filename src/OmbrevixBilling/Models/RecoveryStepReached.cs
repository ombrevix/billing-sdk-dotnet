using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record RecoveryStepReached
{
    [JsonPropertyName("dunner")]
    public required DunnerData Dunner { get; init; }

    [JsonPropertyName("current_step")]
    public required RecoveryStepData CurrentStep { get; init; }

    [JsonPropertyName("next_step")]
    public required RecoveryStepData NextStep { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
