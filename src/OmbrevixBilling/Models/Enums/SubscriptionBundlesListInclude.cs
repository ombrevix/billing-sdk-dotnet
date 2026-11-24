using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Enum;

namespace OmbrevixBilling.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<SubscriptionBundlesListInclude>))]
public sealed record SubscriptionBundlesListInclude : OpenStringEnum<SubscriptionBundlesListInclude>
{
    private SubscriptionBundlesListInclude(string value) : base(value)
    {
    }

    public static readonly SubscriptionBundlesListInclude AccountBalances = new("account_balances");

    public TResult Match<TResult>(Func<TResult> onAccountBalances, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == AccountBalances => onAccountBalances(),
            _ => otherwise(Value)
        };

    public void Match(Action onAccountBalances, Action<string> otherwise)
    {
        if (this == AccountBalances) onAccountBalances();
        else otherwise(Value);
    }
}
