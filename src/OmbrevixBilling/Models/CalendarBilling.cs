using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models.AnyOf;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Models;

/// <summary>
/// (Optional). Cannot be used when also specifying next_billing_at.
/// </summary>
public record CalendarBilling
{
    /// <summary>
    /// A day of month that subscription will be processed on. Can be 1 up to 28 or 'end'.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("anchor_day")]
    public AnchorDay? AnchorDay { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("calendar_billing_first_charge")]
    public FirstChargeType? CalendarBillingFirstCharge { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
