using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.EventsUsageBillingSegments;

/// <summary>
/// The inputs of the UpdateSegment operation.
/// </summary>
public sealed record UpdateSegmentOperationRequest
{
    /// <summary>
    /// ID or Slug of the Addon
    /// </summary>
    public required string AddonId { get; init; }

    /// <summary>
    /// ID or Slug of the Price option belonging to the Addon
    /// </summary>
    public required string PriceOptionId { get; init; }

    /// <summary>
    /// The ID of the Segment
    /// </summary>
    public required double Id { get; init; }

    public UpdateSegmentRequest? Body { get; init; }
}
