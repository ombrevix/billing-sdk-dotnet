using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.EventsUsageBillingSegments;

/// <summary>
/// The inputs of the CreateSegment operation.
/// </summary>
public sealed record CreateSegmentOperationRequest
{
    /// <summary>
    /// ID or Slug for the Addon
    /// </summary>
    public required string AddonId { get; init; }

    /// <summary>
    /// ID or Slug for the Price option belonging to the Addon
    /// </summary>
    public required string PriceOptionId { get; init; }

    public CreateSegmentRequest? Body { get; init; }
}
