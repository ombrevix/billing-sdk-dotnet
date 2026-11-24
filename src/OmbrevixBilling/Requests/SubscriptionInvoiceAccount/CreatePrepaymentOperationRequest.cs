using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.SubscriptionInvoiceAccount;

/// <summary>
/// The inputs of the CreatePrepayment operation.
/// </summary>
public sealed record CreatePrepaymentOperationRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }

    public CreatePrepaymentRequest? Body { get; init; }
}
