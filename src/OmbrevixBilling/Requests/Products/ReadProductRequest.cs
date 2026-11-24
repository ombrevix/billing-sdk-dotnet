namespace OmbrevixBilling.Requests.Products;

/// <summary>
/// The inputs of the ReadProduct operation.
/// </summary>
public sealed record ReadProductRequest
{
    /// <summary>
    /// The Ombrevix Billing id of the product
    /// </summary>
    public required int ProductId { get; init; }
}
