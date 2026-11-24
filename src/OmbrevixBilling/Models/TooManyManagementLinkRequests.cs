using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record TooManyManagementLinkRequests
{
    [JsonPropertyName("error")]
    public required string Error { get; init; }

    [JsonPropertyName("new_link_available_at")]
    public required DateTimeOffset NewLinkAvailableAt { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
