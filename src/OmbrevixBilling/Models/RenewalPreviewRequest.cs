using System.Collections.Generic;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record RenewalPreviewRequest
{
    /// <summary>
    /// (Optional) Array of addon definitions to preview. Providing any addon definitions here will override the actual addons on the subscription (and their quantities), and the billing preview will contain only these addons (in addition to any product base fees).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("addons")]
    public IReadOnlyList<RenewalPreviewAddon>? Addons { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
