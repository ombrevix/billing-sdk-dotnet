namespace OmbrevixBilling.Requests.EstimateInvoices;

/// <summary>
/// The inputs of the PreviewEstimateInvoice operation.
/// </summary>
public sealed record PreviewEstimateInvoiceRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }
}
