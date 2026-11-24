using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.SubscriptionStatus;

/// <summary>
/// The inputs of the UpdateAutomaticSubscriptionResumption operation.
/// </summary>
public sealed record UpdateAutomaticSubscriptionResumptionRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }

    public PauseRequest? Body { get; init; }
}
