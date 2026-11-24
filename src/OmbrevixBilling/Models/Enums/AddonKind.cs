using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Enum;

namespace OmbrevixBilling.Models.Enums;

/// <summary>
/// A slug for the addon type
/// </summary>
[JsonConverter(typeof(StringEnumConverter<AddonKind>))]
public sealed record AddonKind : OpenStringEnum<AddonKind>
{
    private AddonKind(string value) : base(value)
    {
    }

    public static readonly AddonKind MeteredAddon = new("metered_addon");

    public static readonly AddonKind SeatBasedAddon = new("seat_based_addon");

    public static readonly AddonKind ToggleAddon = new("toggle_addon");

    public static readonly AddonKind PrepaidUsageAddon = new("prepaid_usage_addon");

    public static readonly AddonKind EventBasedAddon = new("event_based_addon");

    public TResult Match<TResult>(Func<TResult> onMeteredAddon,
        Func<TResult> onSeatBasedAddon,
        Func<TResult> onToggleAddon,
        Func<TResult> onPrepaidUsageAddon,
        Func<TResult> onEventBasedAddon,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == MeteredAddon => onMeteredAddon(),
            _ when this == SeatBasedAddon => onSeatBasedAddon(),
            _ when this == ToggleAddon => onToggleAddon(),
            _ when this == PrepaidUsageAddon => onPrepaidUsageAddon(),
            _ when this == EventBasedAddon => onEventBasedAddon(),
            _ => otherwise(Value)
        };

    public void Match(Action onMeteredAddon,
        Action onSeatBasedAddon,
        Action onToggleAddon,
        Action onPrepaidUsageAddon,
        Action onEventBasedAddon,
        Action<string> otherwise)
    {
        if (this == MeteredAddon) onMeteredAddon();
        else if (this == SeatBasedAddon) onSeatBasedAddon();
        else if (this == ToggleAddon) onToggleAddon();
        else if (this == PrepaidUsageAddon) onPrepaidUsageAddon();
        else if (this == EventBasedAddon) onEventBasedAddon();
        else otherwise(Value);
    }
}
