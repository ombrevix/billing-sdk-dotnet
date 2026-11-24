using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Enum;

namespace OmbrevixBilling.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ListSubscriptionAddonsSort>))]
public sealed record ListSubscriptionAddonsSort : OpenStringEnum<ListSubscriptionAddonsSort>
{
    private ListSubscriptionAddonsSort(string value) : base(value)
    {
    }

    public static readonly ListSubscriptionAddonsSort Id = new("id");

    public static readonly ListSubscriptionAddonsSort UpdatedAt = new("updated_at");

    public TResult Match<TResult>(Func<TResult> onId, Func<TResult> onUpdatedAt, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Id => onId(),
            _ when this == UpdatedAt => onUpdatedAt(),
            _ => otherwise(Value)
        };

    public void Match(Action onId, Action onUpdatedAt, Action<string> otherwise)
    {
        if (this == Id) onId();
        else if (this == UpdatedAt) onUpdatedAt();
        else otherwise(Value);
    }
}
