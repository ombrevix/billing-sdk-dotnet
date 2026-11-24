using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Enum;

namespace OmbrevixBilling.Models.Enums;

/// <summary>
/// Allowed values for filtering by the current state of the subscription.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<SubscriptionStateFilter>))]
public sealed record SubscriptionStateFilter : OpenStringEnum<SubscriptionStateFilter>
{
    private SubscriptionStateFilter(string value) : base(value)
    {
    }

    public static readonly SubscriptionStateFilter Active = new("active");

    public static readonly SubscriptionStateFilter Canceled = new("canceled");

    public static readonly SubscriptionStateFilter Expired = new("expired");

    public static readonly SubscriptionStateFilter ExpiredCards = new("expired_cards");

    public static readonly SubscriptionStateFilter Frozen = new("frozen");

    public static readonly SubscriptionStateFilter PastDue = new("past_due");

    public static readonly SubscriptionStateFilter PendingCancellation = new("pending_cancellation");

    public static readonly SubscriptionStateFilter PendingRenewal = new("pending_renewal");

    public static readonly SubscriptionStateFilter Suspended = new("suspended");

    public static readonly SubscriptionStateFilter TrialOver = new("trial_over");

    public static readonly SubscriptionStateFilter Trialing = new("trialing");

    public static readonly SubscriptionStateFilter Unpaid = new("unpaid");

    public TResult Match<TResult>(Func<TResult> onActive,
        Func<TResult> onCanceled,
        Func<TResult> onExpired,
        Func<TResult> onExpiredCards,
        Func<TResult> onFrozen,
        Func<TResult> onPastDue,
        Func<TResult> onPendingCancellation,
        Func<TResult> onPendingRenewal,
        Func<TResult> onSuspended,
        Func<TResult> onTrialOver,
        Func<TResult> onTrialing,
        Func<TResult> onUnpaid,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Active => onActive(),
            _ when this == Canceled => onCanceled(),
            _ when this == Expired => onExpired(),
            _ when this == ExpiredCards => onExpiredCards(),
            _ when this == Frozen => onFrozen(),
            _ when this == PastDue => onPastDue(),
            _ when this == PendingCancellation => onPendingCancellation(),
            _ when this == PendingRenewal => onPendingRenewal(),
            _ when this == Suspended => onSuspended(),
            _ when this == TrialOver => onTrialOver(),
            _ when this == Trialing => onTrialing(),
            _ when this == Unpaid => onUnpaid(),
            _ => otherwise(Value)
        };

    public void Match(Action onActive,
        Action onCanceled,
        Action onExpired,
        Action onExpiredCards,
        Action onFrozen,
        Action onPastDue,
        Action onPendingCancellation,
        Action onPendingRenewal,
        Action onSuspended,
        Action onTrialOver,
        Action onTrialing,
        Action onUnpaid,
        Action<string> otherwise)
    {
        if (this == Active) onActive();
        else if (this == Canceled) onCanceled();
        else if (this == Expired) onExpired();
        else if (this == ExpiredCards) onExpiredCards();
        else if (this == Frozen) onFrozen();
        else if (this == PastDue) onPastDue();
        else if (this == PendingCancellation) onPendingCancellation();
        else if (this == PendingRenewal) onPendingRenewal();
        else if (this == Suspended) onSuspended();
        else if (this == TrialOver) onTrialOver();
        else if (this == Trialing) onTrialing();
        else if (this == Unpaid) onUnpaid();
        else otherwise(Value);
    }
}
