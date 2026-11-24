using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.ProductPriceOptions;

/// <summary>
/// The inputs of the CreateProductCurrencyPrices operation.
/// </summary>
public sealed record CreateProductCurrencyPricesOperationRequest
{
    /// <summary>
    /// The Ombrevix Billing id of the product price option
    /// </summary>
    public required int ProductPriceOptionId { get; init; }

    public CreateProductCurrencyPricesRequest? Body { get; init; }
}
