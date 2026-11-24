namespace OmbrevixBilling.Requests.AddonPriceOptions;

/// <summary>
/// The inputs of the PromoteAddonPriceOptionToDefault operation.
/// </summary>
public sealed record PromoteAddonPriceOptionToDefaultRequest
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
