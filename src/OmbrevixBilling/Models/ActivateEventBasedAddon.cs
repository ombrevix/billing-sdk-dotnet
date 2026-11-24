using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record ActivateEventBasedAddon
{
    /// <summary>
    /// The Ombrevix id of the price option
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("price_option_id")]
    public int? PriceOptionId { get; init; }

    /// <summary>
    /// Billing schedule settings for addon provisions or usages on multi-frequency subscriptions. Use this to start a addon's billing period on a custom date instead of aligning with the product charge schedule.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("billing_schedule")]
    public BillingSchedule? BillingSchedule { get; init; }

    /// <summary>
    /// Create or update custom pricing unique to the subscription. Used in place of <c>price_option_id</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("custom_price")]
    public AddonCustomPrice? CustomPrice { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
