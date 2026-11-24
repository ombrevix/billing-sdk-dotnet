using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Enum;

namespace OmbrevixBilling.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<EstimateInvoiceStatus>))]
public sealed record EstimateInvoiceStatus : OpenStringEnum<EstimateInvoiceStatus>
{
    private EstimateInvoiceStatus(string value) : base(value)
    {
    }

    public static readonly EstimateInvoiceStatus Draft = new("draft");

    public static readonly EstimateInvoiceStatus Voided = new("voided");

    public static readonly EstimateInvoiceStatus Archived = new("archived");

    public TResult Match<TResult>(Func<TResult> onDraft,
        Func<TResult> onVoided,
        Func<TResult> onArchived,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Draft => onDraft(),
            _ when this == Voided => onVoided(),
            _ when this == Archived => onArchived(),
            _ => otherwise(Value)
        };

    public void Match(Action onDraft, Action onVoided, Action onArchived, Action<string> otherwise)
    {
        if (this == Draft) onDraft();
        else if (this == Voided) onVoided();
        else if (this == Archived) onArchived();
        else otherwise(Value);
    }
}
