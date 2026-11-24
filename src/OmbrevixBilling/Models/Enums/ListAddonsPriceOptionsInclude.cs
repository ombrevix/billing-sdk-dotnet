using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Enum;

namespace OmbrevixBilling.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ListAddonsPriceOptionsInclude>))]
public sealed record ListAddonsPriceOptionsInclude : OpenStringEnum<ListAddonsPriceOptionsInclude>
{
    private ListAddonsPriceOptionsInclude(string value) : base(value)
    {
    }

    public static readonly ListAddonsPriceOptionsInclude CurrencyPrices = new("currency_prices");

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
