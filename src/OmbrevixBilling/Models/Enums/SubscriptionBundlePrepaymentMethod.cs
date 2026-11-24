using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Enum;

namespace OmbrevixBilling.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<SubscriptionBundlePrepaymentMethod>))]
public sealed record SubscriptionBundlePrepaymentMethod : OpenStringEnum<SubscriptionBundlePrepaymentMethod>
{
    private SubscriptionBundlePrepaymentMethod(string value) : base(value)
    {
    }

    public static readonly SubscriptionBundlePrepaymentMethod Check = new("check");

    public static readonly SubscriptionBundlePrepaymentMethod Cash = new("cash");

    public static readonly SubscriptionBundlePrepaymentMethod MoneyOrder = new("money_order");

    public static readonly SubscriptionBundlePrepaymentMethod Ach = new("ach");

    public static readonly SubscriptionBundlePrepaymentMethod PaypalAccount = new("paypal_account");

    public static readonly SubscriptionBundlePrepaymentMethod Other = new("other");

    public TResult Match<TResult>(Func<TResult> onCheck,
        Func<TResult> onCash,
        Func<TResult> onMoneyOrder,
        Func<TResult> onAch,
        Func<TResult> onPaypalAccount,
        Func<TResult> onOther,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Check => onCheck(),
            _ when this == Cash => onCash(),
            _ when this == MoneyOrder => onMoneyOrder(),
            _ when this == Ach => onAch(),
            _ when this == PaypalAccount => onPaypalAccount(),
            _ when this == Other => onOther(),
            _ => otherwise(Value)
        };

    public void Match(Action onCheck,
        Action onCash,
        Action onMoneyOrder,
        Action onAch,
        Action onPaypalAccount,
        Action onOther,
        Action<string> otherwise)
    {
        if (this == Check) onCheck();
        else if (this == Cash) onCash();
        else if (this == MoneyOrder) onMoneyOrder();
        else if (this == Ach) onAch();
        else if (this == PaypalAccount) onPaypalAccount();
        else if (this == Other) onOther();
        else otherwise(Value);
    }
}
