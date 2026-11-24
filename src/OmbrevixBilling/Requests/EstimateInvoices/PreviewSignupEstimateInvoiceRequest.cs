using OmbrevixBilling.Models;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Requests.EstimateInvoices;

/// <summary>
/// The inputs of the PreviewSignupEstimateInvoice operation.
/// </summary>
public sealed record PreviewSignupEstimateInvoiceRequest
{
    /// <summary>
    /// Choose to include a estimate invoice preview for the first renewal. Use in query <c>include=next_estimate_invoice</c>.
    /// </summary>
    public CreateSignupEstimatePreviewInclude? Include { get; init; }

    public CreateSubscriptionRequest? Body { get; init; }
}
