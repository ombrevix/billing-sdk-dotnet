namespace OmbrevixBilling.Requests.AddonPriceOptions;

/// <summary>
/// The inputs of the UnarchiveAddonPriceOption operation.
/// </summary>
public sealed record UnarchiveAddonPriceOptionRequest
{
    /// <summary>
    /// The Ombrevix Billing id of the addon to which the price option belongs
    /// </summary>
    public required int AddonId { get; init; }

    /// <summary>
    /// The Ombrevix Billing id of the price option
    /// </summary>
    public required int PriceOptionId { get; init; }
}
