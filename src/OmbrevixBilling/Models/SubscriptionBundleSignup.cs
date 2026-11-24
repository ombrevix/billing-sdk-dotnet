using System.Collections.Generic;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Models;

public record SubscriptionBundleSignup
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("payment_profile_id")]
    public int? PaymentProfileId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("payer_id")]
    public int? PayerId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("payer_reference")]
    public string? PayerReference { get; init; }

    /// <summary>
    /// The type of payment collection to be used in the subscription. For legacy Statements Architecture valid options are - <c>invoice</c>, <c>automatic</c>. For current Account Invoicing Architecture valid options are - <c>manual</c>, <c>automatic</c>, <c>prepaid</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("collection_mode")]
    public CollectionMethod? CollectionMode { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("payer_attributes")]
    public PayerAttributes? PayerAttributes { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("credit_card_attributes")]
    public SubscriptionBundleCreditCard? CreditCardAttributes { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("bank_account_attributes")]
    public SubscriptionBundleBankAccount? BankAccountAttributes { get; init; }

    [JsonPropertyName("subscriptions")]
    public required IReadOnlyList<SubscriptionBundleSignupItem> Subscriptions { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
