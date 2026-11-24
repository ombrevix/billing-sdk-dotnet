using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Enum;

namespace OmbrevixBilling.Models.Enums;

/// <summary>
/// The type of object indicated by the id attribute.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<BundleTargetType>))]
public sealed record BundleTargetType : OpenStringEnum<BundleTargetType>
{
    private BundleTargetType(string value) : base(value)
    {
    }

    public static readonly BundleTargetType Customer = new("customer");

    public static readonly BundleTargetType Subscription = new("subscription");

    public static readonly BundleTargetType Self = new("self");

    public static readonly BundleTargetType Parent = new("parent");

    public static readonly BundleTargetType Eldest = new("eldest");

    public TResult Match<TResult>(Func<TResult> onCustomer,
        Func<TResult> onSubscription,
        Func<TResult> onSelf,
        Func<TResult> onParent,
        Func<TResult> onEldest,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Customer => onCustomer(),
            _ when this == Subscription => onSubscription(),
            _ when this == Self => onSelf(),
            _ when this == Parent => onParent(),
            _ when this == Eldest => onEldest(),
            _ => otherwise(Value)
        };

    public void Match(Action onCustomer,
        Action onSubscription,
        Action onSelf,
        Action onParent,
        Action onEldest,
        Action<string> otherwise)
    {
        if (this == Customer) onCustomer();
        else if (this == Subscription) onSubscription();
        else if (this == Self) onSelf();
        else if (this == Parent) onParent();
        else if (this == Eldest) onEldest();
        else otherwise(Value);
    }
}
