using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Enum;

namespace OmbrevixBilling.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<InvoiceDiscountSourceType>))]
public sealed record InvoiceDiscountSourceType : OpenStringEnum<InvoiceDiscountSourceType>
{
    private InvoiceDiscountSourceType(string value) : base(value)
    {
    }

    public static readonly InvoiceDiscountSourceType Coupon = new("Coupon");

    public static readonly InvoiceDiscountSourceType Affiliate = new("Affiliate");

    public static readonly InvoiceDiscountSourceType AdHocCoupon = new("Ad Hoc Coupon");

    public TResult Match<TResult>(Func<TResult> onCoupon,
        Func<TResult> onAffiliate,
        Func<TResult> onAdHocCoupon,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Coupon => onCoupon(),
            _ when this == Affiliate => onAffiliate(),
            _ when this == AdHocCoupon => onAdHocCoupon(),
            _ => otherwise(Value)
        };

    public void Match(Action onCoupon, Action onAffiliate, Action onAdHocCoupon, Action<string> otherwise)
    {
        if (this == Coupon) onCoupon();
        else if (this == Affiliate) onAffiliate();
        else if (this == AdHocCoupon) onAdHocCoupon();
        else otherwise(Value);
    }
}
