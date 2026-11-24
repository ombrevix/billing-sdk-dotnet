namespace OmbrevixBilling.Requests.SubscriptionStatus;

/// <summary>
/// The inputs of the CancelDeferredCancellation operation.
/// </summary>
public sealed record CancelDeferredCancellationRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }
}
