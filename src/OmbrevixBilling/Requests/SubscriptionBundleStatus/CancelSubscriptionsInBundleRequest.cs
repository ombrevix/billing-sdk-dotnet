using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.SubscriptionBundleStatus;

/// <summary>
/// The inputs of the CancelSubscriptionsInBundle operation.
/// </summary>
public sealed record CancelSubscriptionsInBundleRequest
{
    /// <summary>
    /// The uid of the subscription bundle
    /// </summary>
    public required string Uid { get; init; }

    public CancelGroupedSubscriptionsRequest? Body { get; init; }
}
