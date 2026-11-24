namespace OmbrevixBilling.Requests.SubscriptionRenewals;

/// <summary>
/// The inputs of the UnpublishScheduledRenewalConfiguration operation.
/// </summary>
public sealed record UnpublishScheduledRenewalConfigurationRequest
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
