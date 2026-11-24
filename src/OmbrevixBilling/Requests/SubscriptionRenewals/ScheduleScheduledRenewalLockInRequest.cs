using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.SubscriptionRenewals;

/// <summary>
/// The inputs of the ScheduleScheduledRenewalLockIn operation.
/// </summary>
public sealed record ScheduleScheduledRenewalLockInRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }

    /// <summary>
    /// The renewal id.
    /// </summary>
    public required int Id { get; init; }

    public ScheduledRenewalLockInRequest? Body { get; init; }
}
