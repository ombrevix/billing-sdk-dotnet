using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

/// <summary>
/// Used to Create or Update Endpoint.
/// </summary>
public record CreateOrUpdateEndpointRequest
{
    /// <summary>
    /// Used to Create or Update Endpoint.
    /// </summary>
    [JsonPropertyName("endpoint")]
    public required CreateOrUpdateEndpoint Endpoint { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
