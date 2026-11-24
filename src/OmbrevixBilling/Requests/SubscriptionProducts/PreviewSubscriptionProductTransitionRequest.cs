using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.SubscriptionProducts;

/// <summary>
/// The inputs of the PreviewSubscriptionProductTransition operation.
/// </summary>
public sealed record PreviewSubscriptionProductTransitionRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }

    public SubscriptionTransitionPreviewRequest? Body { get; init; }
}
