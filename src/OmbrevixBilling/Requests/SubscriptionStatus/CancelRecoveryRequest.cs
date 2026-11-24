namespace OmbrevixBilling.Requests.SubscriptionStatus;

/// <summary>
/// The inputs of the CancelRecovery operation.
/// </summary>
public sealed record CancelRecoveryRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }
}
