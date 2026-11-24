using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.ProductPriceOptions;

/// <summary>
/// The inputs of the BulkCreateProductPriceOptions operation.
/// </summary>
public sealed record BulkCreateProductPriceOptionsOperationRequest
{
    /// <summary>
    /// The Ombrevix Billing id of the product to which the price options belong
    /// </summary>
    public required int ProductId { get; init; }

    public BulkCreateProductPriceOptionsRequest? Body { get; init; }
}
