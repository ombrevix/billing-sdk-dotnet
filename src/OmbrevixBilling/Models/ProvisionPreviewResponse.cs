using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record ProvisionPreviewResponse
{
    [JsonPropertyName("provision_preview")]
    public required ProvisionPreview ProvisionPreview { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
