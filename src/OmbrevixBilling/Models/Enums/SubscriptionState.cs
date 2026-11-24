using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Enum;

namespace OmbrevixBilling.Models.Enums;

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
[JsonConverter(typeof(StringEnumConverter<SubscriptionState>))]
public sealed record SubscriptionState : OpenStringEnum<SubscriptionState>
{
    private SubscriptionState(string value) : base(value)
    {
    }

    public static readonly SubscriptionState Pending = new("pending");

    public static readonly SubscriptionState CreationFailed = new("creation_failed");

    public static readonly SubscriptionState Trialing = new("trialing");

    public static readonly SubscriptionState Evaluating = new("evaluating");

    public static readonly SubscriptionState Active = new("active");

    public static readonly SubscriptionState Retrying = new("retrying");

    public static readonly SubscriptionState PastDue = new("past_due");

    public static readonly SubscriptionState Suspended = new("suspended");

    public static readonly SubscriptionState Canceled = new("canceled");

    public static readonly SubscriptionState Expired = new("expired");

    public static readonly SubscriptionState Paused = new("paused");

    public static readonly SubscriptionState Unpaid = new("unpaid");

    public static readonly SubscriptionState TrialOver = new("trial_over");

    public static readonly SubscriptionState Frozen = new("frozen");

    public static readonly SubscriptionState AwaitingActivation = new("awaiting_activation");

    public TResult Match<TResult>(Func<TResult> onPending,
        Func<TResult> onCreationFailed,
        Func<TResult> onTrialing,
        Func<TResult> onEvaluating,
        Func<TResult> onActive,
        Func<TResult> onRetrying,
        Func<TResult> onPastDue,
        Func<TResult> onSuspended,
        Func<TResult> onCanceled,
        Func<TResult> onExpired,
        Func<TResult> onPaused,
        Func<TResult> onUnpaid,
        Func<TResult> onTrialOver,
        Func<TResult> onFrozen,
        Func<TResult> onAwaitingActivation,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Pending => onPending(),
            _ when this == CreationFailed => onCreationFailed(),
            _ when this == Trialing => onTrialing(),
            _ when this == Evaluating => onEvaluating(),
            _ when this == Active => onActive(),
            _ when this == Retrying => onRetrying(),
            _ when this == PastDue => onPastDue(),
            _ when this == Suspended => onSuspended(),
            _ when this == Canceled => onCanceled(),
            _ when this == Expired => onExpired(),
            _ when this == Paused => onPaused(),
            _ when this == Unpaid => onUnpaid(),
            _ when this == TrialOver => onTrialOver(),
            _ when this == Frozen => onFrozen(),
            _ when this == AwaitingActivation => onAwaitingActivation(),
            _ => otherwise(Value)
        };

    public void Match(Action onPending,
        Action onCreationFailed,
        Action onTrialing,
        Action onEvaluating,
        Action onActive,
        Action onRetrying,
        Action onPastDue,
        Action onSuspended,
        Action onCanceled,
        Action onExpired,
        Action onPaused,
        Action onUnpaid,
        Action onTrialOver,
        Action onFrozen,
        Action onAwaitingActivation,
        Action<string> otherwise)
    {
        if (this == Pending) onPending();
        else if (this == CreationFailed) onCreationFailed();
        else if (this == Trialing) onTrialing();
        else if (this == Evaluating) onEvaluating();
        else if (this == Active) onActive();
        else if (this == Retrying) onRetrying();
        else if (this == PastDue) onPastDue();
        else if (this == Suspended) onSuspended();
        else if (this == Canceled) onCanceled();
        else if (this == Expired) onExpired();
        else if (this == Paused) onPaused();
        else if (this == Unpaid) onUnpaid();
        else if (this == TrialOver) onTrialOver();
        else if (this == Frozen) onFrozen();
        else if (this == AwaitingActivation) onAwaitingActivation();
        else otherwise(Value);
    }
}
