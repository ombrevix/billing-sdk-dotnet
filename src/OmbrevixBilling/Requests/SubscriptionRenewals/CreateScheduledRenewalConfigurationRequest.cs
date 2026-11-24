using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.SubscriptionRenewals;

/// <summary>
/// The inputs of the CreateScheduledRenewalConfiguration operation.
/// </summary>
public sealed record CreateScheduledRenewalConfigurationRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }

    public ScheduledRenewalConfigurationRequest? Body { get; init; }
}
