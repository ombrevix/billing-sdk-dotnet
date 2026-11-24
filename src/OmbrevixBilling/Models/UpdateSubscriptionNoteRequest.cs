using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

/// <summary>
/// Updatable fields for Subscription Note
/// </summary>
public record UpdateSubscriptionNoteRequest
{
    /// <summary>
    /// Updatable fields for Subscription Note
    /// </summary>
    [JsonPropertyName("note")]
    public required UpdateSubscriptionNote Note { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
