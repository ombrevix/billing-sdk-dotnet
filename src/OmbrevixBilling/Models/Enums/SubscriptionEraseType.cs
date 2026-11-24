using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Enum;

namespace OmbrevixBilling.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<SubscriptionEraseType>))]
public sealed record SubscriptionEraseType : OpenStringEnum<SubscriptionEraseType>
{
    private SubscriptionEraseType(string value) : base(value)
    {
    }

    public static readonly SubscriptionEraseType Customer = new("customer");

    public static readonly SubscriptionEraseType PaymentProfile = new("payment_profile");

    public TResult Match<TResult>(Func<TResult> onCustomer,
        Func<TResult> onPaymentProfile,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Customer => onCustomer(),
            _ when this == PaymentProfile => onPaymentProfile(),
            _ => otherwise(Value)
        };

    public void Match(Action onCustomer, Action onPaymentProfile, Action<string> otherwise)
    {
        if (this == Customer) onCustomer();
        else if (this == PaymentProfile) onPaymentProfile();
        else otherwise(Value);
    }
}
