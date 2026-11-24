using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.SubscriptionProducts;

/// <summary>
/// The inputs of the TransitionSubscriptionProduct operation.
/// </summary>
public sealed record TransitionSubscriptionProductRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }

    public SubscriptionProductTransitionRequest? Body { get; init; }
}
