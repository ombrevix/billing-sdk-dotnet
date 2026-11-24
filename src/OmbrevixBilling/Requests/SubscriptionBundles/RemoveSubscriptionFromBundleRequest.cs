namespace OmbrevixBilling.Requests.SubscriptionBundles;

/// <summary>
/// The inputs of the RemoveSubscriptionFromBundle operation.
/// </summary>
public sealed record RemoveSubscriptionFromBundleRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }
}
