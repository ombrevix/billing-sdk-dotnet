using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.AddonPriceOptions;

/// <summary>
/// The inputs of the CreateAddonPriceOption operation.
/// </summary>
public sealed record CreateAddonPriceOptionOperationRequest
{
    /// <summary>
    /// The Ombrevix Billing id of the addon
    /// </summary>
    public required int AddonId { get; init; }

    public CreateAddonPriceOptionRequest? Body { get; init; }
}
