using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.SubscriptionBundles;

/// <summary>
/// The inputs of the AddSubscriptionToBundle operation.
/// </summary>
public sealed record AddSubscriptionToBundleRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }

    public AddSubscriptionToABundle? Body { get; init; }
}
