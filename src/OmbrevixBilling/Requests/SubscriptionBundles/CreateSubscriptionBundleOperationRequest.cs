using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.SubscriptionBundles;

/// <summary>
/// The inputs of the CreateSubscriptionBundle operation.
/// </summary>
public sealed record CreateSubscriptionBundleOperationRequest
{
    public CreateSubscriptionBundleRequest? Body { get; init; }
}
