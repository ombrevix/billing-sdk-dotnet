using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.SubscriptionStatus;

/// <summary>
/// The inputs of the PreviewRenewal operation.
/// </summary>
public sealed record PreviewRenewalRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }

    public RenewalPreviewRequest? Body { get; init; }
}
