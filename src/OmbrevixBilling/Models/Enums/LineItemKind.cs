using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Enum;

namespace OmbrevixBilling.Models.Enums;

/// <summary>
/// A slug for the line item kind
/// </summary>
[JsonConverter(typeof(StringEnumConverter<LineItemKind>))]
public sealed record LineItemKind : OpenStringEnum<LineItemKind>
{
    private LineItemKind(string value) : base(value)
    {
    }

    public static readonly LineItemKind Baseline = new("baseline");

    public static readonly LineItemKind Initial = new("initial");

    public static readonly LineItemKind Trial = new("trial");

    public static readonly LineItemKind SeatBasedAddon = new("seat_based_addon");

    public static readonly LineItemKind PrepaidUsageAddon = new("prepaid_usage_addon");

    public static readonly LineItemKind ToggleAddon = new("toggle_addon");

    public static readonly LineItemKind MeteredAddon = new("metered_addon");

    public static readonly LineItemKind EventBasedAddon = new("event_based_addon");

    public static readonly LineItemKind Coupon = new("coupon");

    public static readonly LineItemKind Tax = new("tax");

    public TResult Match<TResult>(Func<TResult> onBaseline,
        Func<TResult> onInitial,
        Func<TResult> onTrial,
        Func<TResult> onSeatBasedAddon,
        Func<TResult> onPrepaidUsageAddon,
        Func<TResult> onToggleAddon,
        Func<TResult> onMeteredAddon,
        Func<TResult> onEventBasedAddon,
        Func<TResult> onCoupon,
        Func<TResult> onTax,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Baseline => onBaseline(),
            _ when this == Initial => onInitial(),
            _ when this == Trial => onTrial(),
            _ when this == SeatBasedAddon => onSeatBasedAddon(),
            _ when this == PrepaidUsageAddon => onPrepaidUsageAddon(),
            _ when this == ToggleAddon => onToggleAddon(),
            _ when this == MeteredAddon => onMeteredAddon(),
            _ when this == EventBasedAddon => onEventBasedAddon(),
            _ when this == Coupon => onCoupon(),
            _ when this == Tax => onTax(),
            _ => otherwise(Value)
        };

    public void Match(Action onBaseline,
        Action onInitial,
        Action onTrial,
        Action onSeatBasedAddon,
        Action onPrepaidUsageAddon,
        Action onToggleAddon,
        Action onMeteredAddon,
        Action onEventBasedAddon,
        Action onCoupon,
        Action onTax,
        Action<string> otherwise)
    {
        if (this == Baseline) onBaseline();
        else if (this == Initial) onInitial();
        else if (this == Trial) onTrial();
        else if (this == SeatBasedAddon) onSeatBasedAddon();
        else if (this == PrepaidUsageAddon) onPrepaidUsageAddon();
        else if (this == ToggleAddon) onToggleAddon();
        else if (this == MeteredAddon) onMeteredAddon();
        else if (this == EventBasedAddon) onEventBasedAddon();
        else if (this == Coupon) onCoupon();
        else if (this == Tax) onTax();
        else otherwise(Value);
    }
}
