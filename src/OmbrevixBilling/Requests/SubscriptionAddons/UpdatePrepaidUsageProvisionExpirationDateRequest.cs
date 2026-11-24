using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.SubscriptionAddons;

/// <summary>
/// The inputs of the UpdatePrepaidUsageProvisionExpirationDate operation.
/// </summary>
public sealed record UpdatePrepaidUsageProvisionExpirationDateRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }

    /// <summary>
    /// The Ombrevix Billing id of the addon
    /// </summary>
    public required int AddonId { get; init; }

    /// <summary>
    /// The Ombrevix Billing id of the provision
    /// </summary>
    public required int ProvisionId { get; init; }

    public UpdateProvisionExpirationDate? Body { get; init; }
}
