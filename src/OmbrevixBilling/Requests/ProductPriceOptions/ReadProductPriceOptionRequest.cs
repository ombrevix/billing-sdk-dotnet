using OmbrevixBilling.Models.AnyOf;

namespace OmbrevixBilling.Requests.ProductPriceOptions;

/// <summary>
/// The inputs of the ReadProductPriceOption operation.
/// </summary>
public sealed record ReadProductPriceOptionRequest
{
    /// <summary>
    /// The id or slug of the product. When using the slug, it must be prefixed with <c>slug:</c>. Example: <c>123</c> for an integer ID, or <c>slug:example-product-slug</c> for a string slug.
    /// </summary>
    public required ProductIdModel ProductId { get; init; }

    /// <summary>
    /// The id or slug of the price option. When using the slug, it must be prefixed with <c>slug:</c>. Example: <c>123</c> for an integer ID, or <c>slug:example-product-price-point-slug</c> for a string slug.
    /// </summary>
    public required PriceOptionIdModel PriceOptionId { get; init; }

    /// <summary>
    /// (Optional) If you have defined multiple currencies at the workspace level, you can pass ?currency_prices=true to include an array of currency price data in the response. If the product price option is set to use_workspace_exchange_rate: true, it will return pricing based on the current exchange rate. If the flag is set to false, it will return all of the defined prices for each currency.
    /// </summary>
    public bool? CurrencyPrices { get; init; }
}
