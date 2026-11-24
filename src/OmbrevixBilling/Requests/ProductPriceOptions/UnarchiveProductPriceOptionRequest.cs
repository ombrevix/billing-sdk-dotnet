namespace OmbrevixBilling.Requests.ProductPriceOptions;

/// <summary>
/// The inputs of the UnarchiveProductPriceOption operation.
/// </summary>
public sealed record UnarchiveProductPriceOptionRequest
{
    /// <summary>
    /// The Ombrevix Billing id of the product to which the price option belongs
    /// </summary>
    public required int ProductId { get; init; }

    /// <summary>
    /// The Ombrevix Billing id of the product price option
    /// </summary>
    public required int PriceOptionId { get; init; }
}
