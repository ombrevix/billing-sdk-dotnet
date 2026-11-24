namespace OmbrevixBilling.Requests.ProductLineups;

/// <summary>
/// The inputs of the ReadProductLineup operation.
/// </summary>
public sealed record ReadProductLineupRequest
{
    /// <summary>
    /// The Ombrevix Billing id of the product lineup
    /// </summary>
    public required int Id { get; init; }
}
