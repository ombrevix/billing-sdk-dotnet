using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Enum;

namespace OmbrevixBilling.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<RestrictionType>))]
public sealed record RestrictionType : OpenStringEnum<RestrictionType>
{
    private RestrictionType(string value) : base(value)
    {
    }

    public static readonly RestrictionType Addon = new("Addon");

    public static readonly RestrictionType Product = new("Product");

    public TResult Match<TResult>(Func<TResult> onAddon, Func<TResult> onProduct, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Addon => onAddon(),
            _ when this == Product => onProduct(),
            _ => otherwise(Value)
        };

    public void Match(Action onAddon, Action onProduct, Action<string> otherwise)
    {
        if (this == Addon) onAddon();
        else if (this == Product) onProduct();
        else otherwise(Value);
    }
}
