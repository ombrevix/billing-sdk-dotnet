using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Enum;

namespace OmbrevixBilling.Models.Enums;

/// <summary>
/// 'estimate' value is deprecated in favor of estimate_adhoc and estimate_automatic.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<EstimateInvoiceRole>))]
public sealed record EstimateInvoiceRole : OpenStringEnum<EstimateInvoiceRole>
{
    private EstimateInvoiceRole(string value) : base(value)
    {
    }

    public static readonly EstimateInvoiceRole Unset = new("unset");

    public static readonly EstimateInvoiceRole Estimate = new("estimate");

    public static readonly EstimateInvoiceRole EstimateAdhoc = new("estimate_adhoc");

    public static readonly EstimateInvoiceRole EstimateAutomatic = new("estimate_automatic");

    public TResult Match<TResult>(Func<TResult> onUnset,
        Func<TResult> onEstimate,
        Func<TResult> onEstimateAdhoc,
        Func<TResult> onEstimateAutomatic,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Unset => onUnset(),
            _ when this == Estimate => onEstimate(),
            _ when this == EstimateAdhoc => onEstimateAdhoc(),
            _ when this == EstimateAutomatic => onEstimateAutomatic(),
            _ => otherwise(Value)
        };

    public void Match(Action onUnset,
        Action onEstimate,
        Action onEstimateAdhoc,
        Action onEstimateAutomatic,
        Action<string> otherwise)
    {
        if (this == Unset) onUnset();
        else if (this == Estimate) onEstimate();
        else if (this == EstimateAdhoc) onEstimateAdhoc();
        else if (this == EstimateAutomatic) onEstimateAutomatic();
        else otherwise(Value);
    }
}
