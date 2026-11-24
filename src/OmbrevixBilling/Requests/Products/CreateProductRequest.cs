using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.Products;

/// <summary>
/// The inputs of the CreateProduct operation.
/// </summary>
public sealed record CreateProductRequest
{
    /// <summary>
    /// Either the product lineup's id or its slug prefixed with <c>slug:</c>
    /// </summary>
    public required string ProductLineupId { get; init; }

    public CreateOrUpdateProductRequest? Body { get; init; }
}
