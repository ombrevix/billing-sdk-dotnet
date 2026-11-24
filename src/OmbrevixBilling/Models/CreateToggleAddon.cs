using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record CreateToggleAddon
{
    [JsonPropertyName("toggle_addon")]
    public required ToggleAddon ToggleAddon { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
