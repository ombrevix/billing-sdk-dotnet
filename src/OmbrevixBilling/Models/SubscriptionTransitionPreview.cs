using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record SubscriptionTransitionPreview
{
    /// <summary>
    /// The amount of the prorated adjustment that would be issued for the current subscription.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("prorated_adjustment_minor")]
    public long? ProratedAdjustmentMinor { get; init; }

    /// <summary>
    /// The amount of the charge that would be created for the new product.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("charge_minor")]
    public long? ChargeMinor { get; init; }

    /// <summary>
    /// The amount of the payment due in the case of an upgrade.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("payment_due_minor")]
    public long? PaymentDueMinor { get; init; }

    /// <summary>
    /// Represents a credit minor that is applied to your subscription as part of a transition process for a specific product, which reduces the amount owed for the subscription.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("credit_applied_minor")]
    public long? CreditAppliedMinor { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
