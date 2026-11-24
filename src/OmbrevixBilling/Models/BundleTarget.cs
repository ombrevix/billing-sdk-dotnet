using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Models;

/// <summary>
/// Attributes of the target customer who will be the responsible payer of the created subscription. Required.
/// </summary>
public record BundleTarget
{
    /// <summary>
    /// The type of object indicated by the id attribute.
    /// </summary>
    [JsonPropertyName("type")]
    public required BundleTargetType Type { get; init; }

    /// <summary>
    /// The id of the target customer or subscription to group the existing subscription with. Ignored and should not be included if type is "self", "parent", or "eldest".
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
