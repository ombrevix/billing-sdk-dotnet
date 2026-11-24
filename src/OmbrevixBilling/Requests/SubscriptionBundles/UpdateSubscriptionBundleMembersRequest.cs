using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.SubscriptionBundles;

/// <summary>
/// The inputs of the UpdateSubscriptionBundleMembers operation.
/// </summary>
public sealed record UpdateSubscriptionBundleMembersRequest
{
    /// <summary>
    /// The uid of the subscription bundle
    /// </summary>
    public required string Uid { get; init; }

    public UpdateSubscriptionBundleRequest? Body { get; init; }
}
