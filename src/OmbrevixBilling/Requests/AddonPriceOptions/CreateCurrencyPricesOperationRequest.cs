using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.AddonPriceOptions;

/// <summary>
/// The inputs of the CreateCurrencyPrices operation.
/// </summary>
public sealed record CreateCurrencyPricesOperationRequest
{
    /// <summary>
    /// The Ombrevix Billing id of the price option
    /// </summary>
    public required int PriceOptionId { get; init; }

    public CreateCurrencyPricesRequest? Body { get; init; }
}
