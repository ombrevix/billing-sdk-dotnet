namespace OmbrevixBilling.Requests.EstimateInvoices;

/// <summary>
/// The inputs of the CreateEstimateInvoice operation.
/// </summary>
public sealed record CreateEstimateInvoiceRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }
}
