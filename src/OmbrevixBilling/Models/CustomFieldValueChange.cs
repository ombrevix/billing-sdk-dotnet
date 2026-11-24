using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record CustomFieldValueChange
{
    [JsonPropertyName("event_type")]
    public required string EventType { get; init; }

    [JsonPropertyName("datafield_name")]
    public required string DatafieldName { get; init; }

    [JsonPropertyName("datafield_id")]
    public required int DatafieldId { get; init; }

    [JsonPropertyName("old_value")]
    public required string? OldValue { get; init; }

    [JsonPropertyName("new_value")]
    public required string? NewValue { get; init; }

    [JsonPropertyName("resource_type")]
    public required string ResourceType { get; init; }

    [JsonPropertyName("resource_id")]
    public required int ResourceId { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
