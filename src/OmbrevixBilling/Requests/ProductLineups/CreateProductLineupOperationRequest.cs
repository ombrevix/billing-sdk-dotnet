using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.ProductLineups;

/// <summary>
/// The inputs of the CreateProductLineup operation.
/// </summary>
public sealed record CreateProductLineupOperationRequest
{
    public CreateProductLineupRequest? Body { get; init; }
}
