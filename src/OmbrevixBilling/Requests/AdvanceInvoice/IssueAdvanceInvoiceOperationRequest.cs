using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.AdvanceInvoice;

/// <summary>
/// The inputs of the IssueAdvanceInvoice operation.
/// </summary>
public sealed record IssueAdvanceInvoiceOperationRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }

    public IssueAdvanceInvoiceRequest? Body { get; init; }
}
