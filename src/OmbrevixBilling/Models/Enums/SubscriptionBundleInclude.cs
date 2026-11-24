using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Enum;

namespace OmbrevixBilling.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<SubscriptionBundleInclude>))]
public sealed record SubscriptionBundleInclude : OpenStringEnum<SubscriptionBundleInclude>
{
    private SubscriptionBundleInclude(string value) : base(value)
    {
    }

    public static readonly SubscriptionBundleInclude CurrentBillingAmountMinor = new("current_billing_amount_minor");

    public TResult Match<TResult>(Func<TResult> onCurrentBillingAmountMinor, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == CurrentBillingAmountMinor => onCurrentBillingAmountMinor(),
            _ => otherwise(Value)
        };

    public void Match(Action onCurrentBillingAmountMinor, Action<string> otherwise)
    {
        if (this == CurrentBillingAmountMinor) onCurrentBillingAmountMinor();
        else otherwise(Value);
    }
}
