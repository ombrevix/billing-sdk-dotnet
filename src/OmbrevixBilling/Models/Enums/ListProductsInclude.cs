using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Enum;

namespace OmbrevixBilling.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ListProductsInclude>))]
public sealed record ListProductsInclude : OpenStringEnum<ListProductsInclude>
{
    private ListProductsInclude(string value) : base(value)
    {
    }

    public static readonly ListProductsInclude PrepaidProductPriceOption = new("prepaid_product_price_option");

    public TResult Match<TResult>(Func<TResult> onPrepaidProductPriceOption, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == PrepaidProductPriceOption => onPrepaidProductPriceOption(),
            _ => otherwise(Value)
        };

    public void Match(Action onPrepaidProductPriceOption, Action<string> otherwise)
    {
        if (this == PrepaidProductPriceOption) onPrepaidProductPriceOption();
        else otherwise(Value);
    }
}
