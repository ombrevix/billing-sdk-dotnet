using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.AddonPriceOptions;

/// <summary>
/// The inputs of the UpdateCurrencyPrices operation.
/// </summary>
public sealed record UpdateCurrencyPricesOperationRequest
{
    /// <summary>
    /// The Ombrevix Billing id of the price option
    /// </summary>
    public required int PriceOptionId { get; init; }

    public UpdateCurrencyPricesRequest? Body { get; init; }
}
