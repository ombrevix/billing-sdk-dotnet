namespace OmbrevixBilling.Requests.SubscriptionBundleStatus;

/// <summary>
/// The inputs of the CancelDeferredCancellationForBundle operation.
/// </summary>
public sealed record CancelDeferredCancellationForBundleRequest
{
    /// <summary>
    /// The uid of the subscription bundle
    /// </summary>
    public required string Uid { get; init; }
}
