using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.ProductPriceOptions;

/// <summary>
/// The inputs of the UpdateProductCurrencyPrices operation.
/// </summary>
public sealed record UpdateProductCurrencyPricesRequest
{
    /// <summary>
    /// The Ombrevix Billing id of the product price option
    /// </summary>
    public required int ProductPriceOptionId { get; init; }

    public UpdateCurrencyPricesRequest? Body { get; init; }
}
