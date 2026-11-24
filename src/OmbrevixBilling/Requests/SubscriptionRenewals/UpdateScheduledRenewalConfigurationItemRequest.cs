using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.SubscriptionRenewals;

/// <summary>
/// The inputs of the UpdateScheduledRenewalConfigurationItem operation.
/// </summary>
public sealed record UpdateScheduledRenewalConfigurationItemRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }

    /// <summary>
    /// The scheduled renewal configuration id.
    /// </summary>
    public required int ScheduledRenewalsConfigurationId { get; init; }

    /// <summary>
    /// The scheduled renewal configuration item id.
    /// </summary>
    public required int Id { get; init; }

    public ScheduledRenewalUpdateRequest? Body { get; init; }
}
