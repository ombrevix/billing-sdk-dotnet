using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models.AnyOf;

namespace OmbrevixBilling.Models;

public record AddonProvisionChange
{
    [JsonPropertyName("previous_provision")]
    public required int PreviousProvision { get; init; }

    [JsonPropertyName("new_provision")]
    public required int NewProvision { get; init; }

    [JsonPropertyName("addon_id")]
    public required int AddonId { get; init; }

    [JsonPropertyName("addon_slug")]
    public required string AddonSlug { get; init; }

    [JsonPropertyName("memo")]
    public required string Memo { get; init; }

    [JsonPropertyName("provision_id")]
    public required int ProvisionId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("provisioned_quantity")]
    public ProvisionedQuantity? ProvisionedQuantity { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
