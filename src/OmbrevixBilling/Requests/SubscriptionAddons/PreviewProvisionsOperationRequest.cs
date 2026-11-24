using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.SubscriptionAddons;

/// <summary>
/// The inputs of the PreviewProvisions operation.
/// </summary>
public sealed record PreviewProvisionsOperationRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }

    public PreviewProvisionsRequest? Body { get; init; }
}
