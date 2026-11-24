using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Models;

/// <summary>
/// Example schema for an <c>change_chargeback_status</c> event
/// </summary>
public record ChangeChargebackStatusEventData
{
    [JsonPropertyName("chargeback_status")]
    public required ChargebackStatus ChargebackStatus { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
