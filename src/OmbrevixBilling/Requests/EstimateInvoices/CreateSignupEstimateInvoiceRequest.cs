using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.EstimateInvoices;

/// <summary>
/// The inputs of the CreateSignupEstimateInvoice operation.
/// </summary>
public sealed record CreateSignupEstimateInvoiceRequest
{
    public CreateSubscriptionRequest? Body { get; init; }
}
