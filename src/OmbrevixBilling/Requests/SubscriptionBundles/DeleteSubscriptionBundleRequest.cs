namespace OmbrevixBilling.Requests.SubscriptionBundles;

/// <summary>
/// The inputs of the DeleteSubscriptionBundle operation.
/// </summary>
public sealed record DeleteSubscriptionBundleRequest
{
    /// <summary>
    /// The uid of the subscription bundle
    /// </summary>
    public required string Uid { get; init; }
}
