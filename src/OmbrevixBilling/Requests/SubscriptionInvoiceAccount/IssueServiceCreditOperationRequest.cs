using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.SubscriptionInvoiceAccount;

/// <summary>
/// The inputs of the IssueServiceCredit operation.
/// </summary>
public sealed record IssueServiceCreditOperationRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }

    public IssueServiceCreditRequest? Body { get; init; }
}
