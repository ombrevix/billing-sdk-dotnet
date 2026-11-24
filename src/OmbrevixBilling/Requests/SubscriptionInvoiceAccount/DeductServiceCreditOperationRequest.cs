using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.SubscriptionInvoiceAccount;

/// <summary>
/// The inputs of the DeductServiceCredit operation.
/// </summary>
public sealed record DeductServiceCreditOperationRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }

    public DeductServiceCreditRequest? Body { get; init; }
}
