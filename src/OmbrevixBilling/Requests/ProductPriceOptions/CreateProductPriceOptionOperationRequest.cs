using OmbrevixBilling.Models;
using OmbrevixBilling.Models.AnyOf;

namespace OmbrevixBilling.Requests.ProductPriceOptions;

/// <summary>
/// The inputs of the CreateProductPriceOption operation.
/// </summary>
public sealed record CreateProductPriceOptionOperationRequest
{
    /// <summary>
    /// The id or slug of the product. When using the slug, it must be prefixed with <c>slug:</c>
    /// </summary>
    public required ProductIdModel ProductId { get; init; }

    public CreateProductPriceOptionRequest? Body { get; init; }
}
