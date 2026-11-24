using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Enum;

namespace OmbrevixBilling.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ListSubscriptionAddonsInclude>))]
public sealed record ListSubscriptionAddonsInclude : OpenStringEnum<ListSubscriptionAddonsInclude>
{
    private ListSubscriptionAddonsInclude(string value) : base(value)
    {
    }

    public static readonly ListSubscriptionAddonsInclude Subscription = new("subscription");

    public static readonly ListSubscriptionAddonsInclude HistoricUsages = new("historic_usages");

    public TResult Match<TResult>(Func<TResult> onSubscription,
        Func<TResult> onHistoricUsages,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Subscription => onSubscription(),
            _ when this == HistoricUsages => onHistoricUsages(),
            _ => otherwise(Value)
        };

    public void Match(Action onSubscription, Action onHistoricUsages, Action<string> otherwise)
    {
        if (this == Subscription) onSubscription();
        else if (this == HistoricUsages) onHistoricUsages();
        else otherwise(Value);
    }
}
