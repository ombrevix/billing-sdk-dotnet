using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.EstimateInvoices;

/// <summary>
/// The inputs of the VoidEstimateInvoice operation.
/// </summary>
public sealed record VoidEstimateInvoiceRequest
{
    /// <summary>
    /// The uid of the estimate invoice
    /// </summary>
    public required string EstimateInvoiceUid { get; init; }

    public VoidInvoiceRequest? Body { get; init; }
}
