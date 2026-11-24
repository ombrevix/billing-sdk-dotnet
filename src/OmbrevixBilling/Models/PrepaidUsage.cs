using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record PrepaidUsage
{
    [JsonPropertyName("previous_unit_balance")]
    [MinLength(1)]
    public required string PreviousUnitBalance { get; init; }

    [JsonPropertyName("previous_overage_unit_balance")]
    [MinLength(1)]
    public required string PreviousOverageUnitBalance { get; init; }

    [JsonPropertyName("new_unit_balance")]
    public required int NewUnitBalance { get; init; }

    [JsonPropertyName("new_overage_unit_balance")]
    public required int NewOverageUnitBalance { get; init; }

    [JsonPropertyName("usage_quantity")]
    public required int UsageQuantity { get; init; }

    [JsonPropertyName("overage_usage_quantity")]
    public required int OverageUsageQuantity { get; init; }

    [JsonPropertyName("addon_id")]
    public required int AddonId { get; init; }

    [JsonPropertyName("addon_slug")]
    public required string AddonSlug { get; init; }

    [JsonPropertyName("memo")]
    public required string Memo { get; init; }

    [JsonPropertyName("provision_details")]
    public required IReadOnlyList<PrepaidUsageProvisionDetail> ProvisionDetails { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
