namespace OmbrevixBilling.Requests.SubscriptionBundleStatus;

/// <summary>
/// The inputs of the InitiateDeferredCancellationForBundle operation.
/// </summary>
public sealed record InitiateDeferredCancellationForBundleRequest
{
    /// <summary>
    /// The uid of the subscription bundle
    /// </summary>
    public required string Uid { get; init; }
}
