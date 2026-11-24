namespace OmbrevixBilling.Requests.EstimateInvoices;

/// <summary>
/// The inputs of the ReadEstimateInvoice operation.
/// </summary>
public sealed record ReadEstimateInvoiceRequest
{
    /// <summary>
    /// The uid of the estimate invoice
    /// </summary>
    public required string EstimateInvoiceUid { get; init; }
}
