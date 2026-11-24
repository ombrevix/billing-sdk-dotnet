namespace OmbrevixBilling.Requests.AdvanceInvoice;

/// <summary>
/// The inputs of the ReadAdvanceInvoice operation.
/// </summary>
public sealed record ReadAdvanceInvoiceRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }
}
