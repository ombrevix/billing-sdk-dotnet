using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.Subscriptions;

/// <summary>
/// The inputs of the UpdateSubscription operation.
/// </summary>
public sealed record UpdateSubscriptionOperationRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }

    public UpdateSubscriptionRequest? Body { get; init; }
}
