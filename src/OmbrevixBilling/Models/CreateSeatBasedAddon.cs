using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record CreateSeatBasedAddon
{
    [JsonPropertyName("seat_based_addon")]
    public required SeatBasedAddon SeatBasedAddon { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
