using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Enum;

namespace OmbrevixBilling.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ListProductsPriceOptionsInclude>))]
public sealed record ListProductsPriceOptionsInclude : OpenStringEnum<ListProductsPriceOptionsInclude>
{
    private ListProductsPriceOptionsInclude(string value) : base(value)
    {
    }

    public static readonly ListProductsPriceOptionsInclude CurrencyPrices = new("currency_prices");

    public TResult Match<TResult>(Func<TResult> onCurrencyPrices, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == CurrencyPrices => onCurrencyPrices(),
            _ => otherwise(Value)
        };

    public void Match(Action onCurrencyPrices, Action<string> otherwise)
    {
        if (this == CurrencyPrices) onCurrencyPrices();
        else otherwise(Value);
    }
}
