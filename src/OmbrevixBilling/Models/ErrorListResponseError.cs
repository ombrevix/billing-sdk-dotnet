using System.Collections.Generic;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

/// <summary>
/// Error which contains list of messages.
/// </summary>
public record ErrorListResponseError
{
    [JsonPropertyName("errors")]
    public required IReadOnlyList<string> Errors { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
