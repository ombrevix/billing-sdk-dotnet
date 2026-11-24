using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.SubscriptionStatus;

/// <summary>
/// The inputs of the InitiateDeferredCancellation operation.
/// </summary>
public sealed record InitiateDeferredCancellationRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }

    public CancellationRequest? Body { get; init; }
}
