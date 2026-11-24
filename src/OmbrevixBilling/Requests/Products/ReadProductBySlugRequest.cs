namespace OmbrevixBilling.Requests.Products;

/// <summary>
/// The inputs of the ReadProductBySlug operation.
/// </summary>
public sealed record ReadProductBySlugRequest
{
    /// <summary>
    /// The slug of the product
    /// </summary>
    public required string ApiSlug { get; init; }
}
