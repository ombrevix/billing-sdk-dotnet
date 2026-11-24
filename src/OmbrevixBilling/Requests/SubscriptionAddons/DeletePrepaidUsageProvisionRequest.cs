using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.SubscriptionAddons;

/// <summary>
/// The inputs of the DeletePrepaidUsageProvision operation.
/// </summary>
public sealed record DeletePrepaidUsageProvisionRequest
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

    public CreditSchemeRequest? Body { get; init; }
}
