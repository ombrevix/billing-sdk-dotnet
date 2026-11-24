using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record BundleSettings
{
    /// <summary>
    /// Attributes of the target customer who will be the responsible payer of the created subscription. Required.
    /// </summary>
    [JsonPropertyName("target")]
    public required BundleTarget Target { get; init; }

    /// <summary>
    /// (Optional) Attributes related to billing date and accrual. Note: Only applicable for new subscriptions.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("billing")]
    public BundleBilling? Billing { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
