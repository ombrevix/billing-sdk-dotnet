using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.SubscriptionBundles;

/// <summary>
/// The inputs of the SignupWithSubscriptionBundle operation.
/// </summary>
public sealed record SignupWithSubscriptionBundleRequest
{
    public SubscriptionBundleSignupRequest? Body { get; init; }
}
