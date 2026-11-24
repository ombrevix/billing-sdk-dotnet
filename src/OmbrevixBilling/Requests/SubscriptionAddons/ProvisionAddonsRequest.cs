using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.SubscriptionAddons;

/// <summary>
/// The inputs of the ProvisionAddons operation.
/// </summary>
public sealed record ProvisionAddonsRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }

    public ProvisionAddons? Body { get; init; }
}
