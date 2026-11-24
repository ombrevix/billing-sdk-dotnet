using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.Subscriptions;

/// <summary>
/// The inputs of the ActivateSubscription operation.
/// </summary>
public sealed record ActivateSubscriptionOperationRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }

    public ActivateSubscriptionRequest? Body { get; init; }
}
