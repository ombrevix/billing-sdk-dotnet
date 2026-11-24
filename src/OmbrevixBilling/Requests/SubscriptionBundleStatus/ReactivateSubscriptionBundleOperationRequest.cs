using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.SubscriptionBundleStatus;

/// <summary>
/// The inputs of the ReactivateSubscriptionBundle operation.
/// </summary>
public sealed record ReactivateSubscriptionBundleOperationRequest
{
    /// <summary>
    /// The uid of the subscription bundle
    /// </summary>
    public required string Uid { get; init; }

    public ReactivateSubscriptionBundleRequest? Body { get; init; }
}
