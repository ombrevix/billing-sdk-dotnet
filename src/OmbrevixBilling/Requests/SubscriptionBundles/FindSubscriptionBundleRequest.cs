namespace OmbrevixBilling.Requests.SubscriptionBundles;

/// <summary>
/// The inputs of the FindSubscriptionBundle operation.
/// </summary>
public sealed record FindSubscriptionBundleRequest
{
    /// <summary>
    /// The Ombrevix Billing id of the subscription associated with the subscription bundle
    /// </summary>
    public required string SubscriptionId { get; init; }
}
