using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Enum;

namespace OmbrevixBilling.Models.Enums;

/// <summary>
/// A slug for the line item kind for provision preview
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ProvisionPreviewLineItemKind>))]
public sealed record ProvisionPreviewLineItemKind : OpenStringEnum<ProvisionPreviewLineItemKind>
{
    private ProvisionPreviewLineItemKind(string value) : base(value)
    {
    }

    public static readonly ProvisionPreviewLineItemKind SeatBasedAddon = new("seat_based_addon");

    public static readonly ProvisionPreviewLineItemKind ToggleAddon = new("toggle_addon");

    public static readonly ProvisionPreviewLineItemKind Coupon = new("coupon");

    public static readonly ProvisionPreviewLineItemKind Tax = new("tax");

    public TResult Match<TResult>(Func<TResult> onSeatBasedAddon,
        Func<TResult> onToggleAddon,
        Func<TResult> onCoupon,
        Func<TResult> onTax,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == SeatBasedAddon => onSeatBasedAddon(),
            _ when this == ToggleAddon => onToggleAddon(),
            _ when this == Coupon => onCoupon(),
            _ when this == Tax => onTax(),
            _ => otherwise(Value)
        };

    public void Match(Action onSeatBasedAddon,
        Action onToggleAddon,
        Action onCoupon,
        Action onTax,
        Action<string> otherwise)
    {
        if (this == SeatBasedAddon) onSeatBasedAddon();
        else if (this == ToggleAddon) onToggleAddon();
        else if (this == Coupon) onCoupon();
        else if (this == Tax) onTax();
        else otherwise(Value);
    }
}
