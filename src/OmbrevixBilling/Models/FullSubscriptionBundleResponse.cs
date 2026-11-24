using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Models;

public record FullSubscriptionBundleResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("uid")]
    public string? Uid { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("scheme")]
    public int? Scheme { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("customer_id")]
    public int? CustomerId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("payment_profile_id")]
    public int? PaymentProfileId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("subscription_ids")]
    public IReadOnlyList<int>? SubscriptionIds { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("primary_subscription_id")]
    public int? PrimarySubscriptionId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("next_evaluation_at")]
    public DateTimeOffset? NextEvaluationAt { get; init; }

    /// <summary>
    /// The state of a subscription.
    /// * <b>Live States</b>
    ///     * <c>active</c> - A normal, active subscription. It is not in a trial and is paid and up to date.
    ///     * <c>assessing</c> - An internal (transient) state that indicates a subscription is in the middle of periodic assessment. Do not base any access decisions in your app on this state, as it may not always be exposed.
    ///     * <c>pending</c> - An internal (transient) state that indicates a subscription is in the creation process. Do not base any access decisions in your app on this state, as it may not always be exposed.
    ///     * <c>trialing</c> - A subscription in trialing state has a valid trial subscription. This type of subscription may transition to active once payment is received when the trial has ended. Otherwise, it may go to a Problem or End of Life state.
    ///     * <c>paused</c> - An internal state that indicates that your account with Ombrevix Billing is in arrears.
    /// * <b>Problem States</b>
    ///     * <c>past_due</c> - Indicates that the most recent payment has failed, and payment is past due for this subscription. If you have enabled our automated recovery, this subscription will be in the recovery process (additional status and callbacks from the recovery process will be available in the future). If you are handling recovery and payment updates yourself, you will want to use this state to initiate a payment update from your customers.
    ///     * <c>retrying</c> - Indicates that normal assessment/processing of the subscription has failed for a reason that cannot be fixed by the Customer. For example, a Soft Fail may result from a timeout at the gateway or incorrect credentials on your part. The subscriptions should be retried automatically. An interface is being built for you to review problems resulting from these events to take manual action when needed.
    ///     * <c>unpaid</c> - Indicates an unpaid subscription. A subscription is marked unpaid if the retry period expires and you have configured your Recovery settings to have a Final Action of <c>mark the subscription unpaid</c>.
    /// * <b>End of Life States</b>
    ///     * <c>canceled</c> - Indicates a canceled subscription. This may happen at your request (via the API or the web interface) or due to the expiration of the Recovery process without payment. See the Reactivation documentation for info on how to restart a canceled subscription.
    ///     While a subscription is canceled, its period will not advance, it will not accrue any new charges, and Ombrevix Billing will not attempt to collect the overdue balance.
    ///     * <c>expired</c> - Indicates a subscription that has expired due to running its normal life cycle. Some products may be configured to have an expiration period. An expired subscription then is one that stayed active until it fulfilled its full period.
    ///     * <c>creation_failed</c> - Indicates that signup has failed. (You may see this state in a signup_failure webhook.)
    ///     * <c>frozen</c> - Indicates that a subscription’s billing has been temporarily stopped. While it is expected that the subscription will resume and return to active status, this is still treated as an “End of Life” state because the customer is not paying for services during this time.
    ///     * <c>suspended</c> - Indicates that a prepaid subscription has used up all their prepayment balance. If a prepayment is applied, it will return to an active state.
    ///     * <c>trial_over</c> - A subscription in a trial_over state is a subscription that completed a no-obligation trial and did not have a card on file at the expiration of the trial period. See Product Pricing – No Obligation Trials for more details.
    /// <para>
    /// See Subscription States for more info about subscription states and state transitions.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("state")]
    public SubscriptionState? State { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cancel_when_period_ends")]
    public bool? CancelWhenPeriodEnds { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("current_billing_amount_minor")]
    public long? CurrentBillingAmountMinor { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("customer")]
    public SubscriptionBundleCustomer? Customer { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("account_balances")]
    public SubscriptionBundleBalances? AccountBalances { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
