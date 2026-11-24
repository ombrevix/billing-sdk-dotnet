using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Enum;

namespace OmbrevixBilling.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<EstimateInvoiceDiscountSourceType>))]
public sealed record EstimateInvoiceDiscountSourceType : OpenStringEnum<EstimateInvoiceDiscountSourceType>
{
    private EstimateInvoiceDiscountSourceType(string value) : base(value)
    {
    }

    public static readonly EstimateInvoiceDiscountSourceType Coupon = new("Coupon");

    public static readonly EstimateInvoiceDiscountSourceType Affiliate = new("Affiliate");

    public TResult Match<TResult>(Func<TResult> onCoupon, Func<TResult> onAffiliate, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Coupon => onCoupon(),
            _ when this == Affiliate => onAffiliate(),
            _ => otherwise(Value)
        };

    public void Match(Action onCoupon, Action onAffiliate, Action<string> otherwise)
    {
        if (this == Coupon) onCoupon();
        else if (this == Affiliate) onAffiliate();
        else otherwise(Value);
    }
}
