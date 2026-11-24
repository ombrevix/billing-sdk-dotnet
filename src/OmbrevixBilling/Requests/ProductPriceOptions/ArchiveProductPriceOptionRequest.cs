using OmbrevixBilling.Models.AnyOf;

namespace OmbrevixBilling.Requests.ProductPriceOptions;

/// <summary>
/// The inputs of the ArchiveProductPriceOption operation.
/// </summary>
public sealed record ArchiveProductPriceOptionRequest
{
    /// <summary>
    /// The id or slug of the product. When using the slug, it must be prefixed with <c>slug:</c>. Example: <c>123</c> for an integer ID, or <c>slug:example-product-slug</c> for a string slug.
    /// </summary>
    public required ProductIdModel ProductId { get; init; }

    /// <summary>
    /// The id or slug of the price option. When using the slug, it must be prefixed with <c>slug:</c>. Example: <c>123</c> for an integer ID, or <c>slug:example-product-price-point-slug</c> for a string slug.
    /// </summary>
    public required PriceOptionIdModel PriceOptionId { get; init; }
}
