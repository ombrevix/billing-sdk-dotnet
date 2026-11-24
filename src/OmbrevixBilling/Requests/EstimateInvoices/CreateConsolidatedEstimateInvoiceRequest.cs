namespace OmbrevixBilling.Requests.EstimateInvoices;

/// <summary>
/// The inputs of the CreateConsolidatedEstimateInvoice operation.
/// </summary>
public sealed record CreateConsolidatedEstimateInvoiceRequest
{
    /// <summary>
    /// The uid of the subscription bundle
    /// </summary>
    public required string Uid { get; init; }
}
