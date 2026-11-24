using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.EventsUsageBillingSegments;

/// <summary>
/// The inputs of the BulkCreateSegments operation.
/// </summary>
public sealed record BulkCreateSegmentsRequest
{
    /// <summary>
    /// ID or Slug for the Addon
    /// </summary>
    public required string AddonId { get; init; }

    /// <summary>
    /// ID or Slug for the Price option belonging to the Addon
    /// </summary>
    public required string PriceOptionId { get; init; }

    public BulkCreateSegments? Body { get; init; }
}
