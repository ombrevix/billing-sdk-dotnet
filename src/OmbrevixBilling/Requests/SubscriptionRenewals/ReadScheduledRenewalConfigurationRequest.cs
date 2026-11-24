namespace OmbrevixBilling.Requests.SubscriptionRenewals;

/// <summary>
/// The inputs of the ReadScheduledRenewalConfiguration operation.
/// </summary>
public sealed record ReadScheduledRenewalConfigurationRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }

    /// <summary>
    /// The renewal id.
    /// </summary>
    public required int Id { get; init; }
}
