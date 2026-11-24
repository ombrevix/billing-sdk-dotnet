using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Enum;

namespace OmbrevixBilling.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<EstimateInvoiceTaxSourceType>))]
public sealed record EstimateInvoiceTaxSourceType : OpenStringEnum<EstimateInvoiceTaxSourceType>
{
    private EstimateInvoiceTaxSourceType(string value) : base(value)
    {
    }

    public static readonly EstimateInvoiceTaxSourceType Tax = new("Tax");

    public static readonly EstimateInvoiceTaxSourceType Avalara = new("Avalara");

    public TResult Match<TResult>(Func<TResult> onTax, Func<TResult> onAvalara, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Tax => onTax(),
            _ when this == Avalara => onAvalara(),
            _ => otherwise(Value)
        };

    public void Match(Action onTax, Action onAvalara, Action<string> otherwise)
    {
        if (this == Tax) onTax();
        else if (this == Avalara) onAvalara();
        else otherwise(Value);
    }
}
