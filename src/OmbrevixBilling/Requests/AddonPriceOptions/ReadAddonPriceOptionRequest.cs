using OmbrevixBilling.Models.AnyOf;

namespace OmbrevixBilling.Requests.AddonPriceOptions;

/// <summary>
/// The inputs of the ReadAddonPriceOption operation.
/// </summary>
public sealed record ReadAddonPriceOptionRequest
{
    /// <summary>
    /// The id or slug of the addon. When using the slug, it must be prefixed with <c>slug:</c>. Example: <c>123</c> for an integer ID, or <c>slug:example-product-slug</c> for a string slug.
    /// </summary>
    public required AddonIdModel AddonId { get; init; }

    /// <summary>
    /// The id or slug of the price option. When using the slug, it must be prefixed with <c>slug:</c>. Example: <c>123</c> for an integer ID, or <c>slug:example-price_option-slug</c> for a string slug.
    /// </summary>
    public required PriceOptionIdModel PriceOptionId { get; init; }

    /// <summary>
    /// Include an array of currency price data.
    /// </summary>
    public bool? CurrencyPrices { get; init; }
}
