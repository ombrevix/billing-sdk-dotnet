using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record RenewalPreviewResponse
{
    [JsonPropertyName("renewal_preview")]
    public required RenewalPreview RenewalPreview { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
