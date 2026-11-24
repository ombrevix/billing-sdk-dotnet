using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Enum;

namespace OmbrevixBilling.Models.Enums;

/// <summary>
/// A slug for the billing manifest line item kind
/// </summary>
[JsonConverter(typeof(StringEnumConverter<BillingManifestLineItemKind>))]
public sealed record BillingManifestLineItemKind : OpenStringEnum<BillingManifestLineItemKind>
{
    private BillingManifestLineItemKind(string value) : base(value)
    {
    }

    public static readonly BillingManifestLineItemKind Baseline = new("baseline");

    public static readonly BillingManifestLineItemKind Initial = new("initial");

    public static readonly BillingManifestLineItemKind Trial = new("trial");

    public static readonly BillingManifestLineItemKind Coupon = new("coupon");

    public static readonly BillingManifestLineItemKind Addon = new("addon");

    public static readonly BillingManifestLineItemKind Tax = new("tax");

    public TResult Match<TResult>(Func<TResult> onBaseline,
        Func<TResult> onInitial,
        Func<TResult> onTrial,
        Func<TResult> onCoupon,
        Func<TResult> onAddon,
        Func<TResult> onTax,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Baseline => onBaseline(),
            _ when this == Initial => onInitial(),
            _ when this == Trial => onTrial(),
            _ when this == Coupon => onCoupon(),
            _ when this == Addon => onAddon(),
            _ when this == Tax => onTax(),
            _ => otherwise(Value)
        };

    public void Match(Action onBaseline,
        Action onInitial,
        Action onTrial,
        Action onCoupon,
        Action onAddon,
        Action onTax,
        Action<string> otherwise)
    {
        if (this == Baseline) onBaseline();
        else if (this == Initial) onInitial();
        else if (this == Trial) onTrial();
        else if (this == Coupon) onCoupon();
        else if (this == Addon) onAddon();
        else if (this == Tax) onTax();
        else otherwise(Value);
    }
}
