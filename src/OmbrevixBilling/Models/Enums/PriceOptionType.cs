using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Enum;

namespace OmbrevixBilling.Models.Enums;

/// <summary>
/// Price option type. We expose the following types:
/// 1. <b>default</b>: a price option that is marked as a default price for a certain product.
/// 2. <b>custom</b>: a custom price option.
/// 3. <b>catalog</b>: a price option that is <b>not</b> marked as a default price for a certain product and is <b>not</b> a custom one.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<PriceOptionType>))]
public sealed record PriceOptionType : OpenStringEnum<PriceOptionType>
{
    private PriceOptionType(string value) : base(value)
    {
    }

    public static readonly PriceOptionType Catalog = new("catalog");

    public static readonly PriceOptionType Default = new("default");

    public static readonly PriceOptionType Custom = new("custom");

    public TResult Match<TResult>(Func<TResult> onCatalog,
        Func<TResult> onDefault,
        Func<TResult> onCustom,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Catalog => onCatalog(),
            _ when this == Default => onDefault(),
            _ when this == Custom => onCustom(),
            _ => otherwise(Value)
        };

    public void Match(Action onCatalog, Action onDefault, Action onCustom, Action<string> otherwise)
    {
        if (this == Catalog) onCatalog();
        else if (this == Default) onDefault();
        else if (this == Custom) onCustom();
        else otherwise(Value);
    }
}
