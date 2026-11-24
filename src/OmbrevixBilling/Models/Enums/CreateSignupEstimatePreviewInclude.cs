using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Enum;

namespace OmbrevixBilling.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<CreateSignupEstimatePreviewInclude>))]
public sealed record CreateSignupEstimatePreviewInclude : OpenStringEnum<CreateSignupEstimatePreviewInclude>
{
    private CreateSignupEstimatePreviewInclude(string value) : base(value)
    {
    }

    public static readonly CreateSignupEstimatePreviewInclude NextEstimateInvoice = new("next_estimate_invoice");

    public TResult Match<TResult>(Func<TResult> onNextEstimateInvoice, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == NextEstimateInvoice => onNextEstimateInvoice(),
            _ => otherwise(Value)
        };

    public void Match(Action onNextEstimateInvoice, Action<string> otherwise)
    {
        if (this == NextEstimateInvoice) onNextEstimateInvoice();
        else otherwise(Value);
    }
}
