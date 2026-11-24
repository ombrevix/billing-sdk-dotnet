using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.EstimateInvoices;

/// <summary>
/// The inputs of the DeliverEstimateInvoice operation.
/// </summary>
public sealed record DeliverEstimateInvoiceOperationRequest
{
    /// <summary>
    /// The uid of the estimate invoice
    /// </summary>
    public required string EstimateInvoiceUid { get; init; }

    public DeliverEstimateInvoiceRequest? Body { get; init; }
}
