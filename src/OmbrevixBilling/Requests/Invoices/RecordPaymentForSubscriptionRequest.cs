using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.Invoices;

/// <summary>
/// The inputs of the RecordPaymentForSubscription operation.
/// </summary>
public sealed record RecordPaymentForSubscriptionRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }

    public RecordPaymentRequest? Body { get; init; }
}
