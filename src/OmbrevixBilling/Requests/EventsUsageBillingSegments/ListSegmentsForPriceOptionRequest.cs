using OmbrevixBilling.Core.Validation.Attributes;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.EventsUsageBillingSegments;

/// <summary>
/// The inputs of the ListSegmentsForPriceOption operation.
/// </summary>
public sealed record ListSegmentsForPriceOptionRequest
{
    /// <summary>
    /// ID or Slug for the Addon
    /// </summary>
    public required string AddonId { get; init; }

    /// <summary>
    /// ID or Slug for the Price option belonging to the Addon
    /// </summary>
    public required string PriceOptionId { get; init; }

    /// <summary>
    /// Result records are organized in pages. By default, the first page of results is displayed. The page parameter specifies a page number of results to fetch. You can start navigating through the pages to consume the results. You do this by passing in a page parameter. Retrieve the next page by adding ?page=2 to the query string. If there are no results to return, then an empty result set will be returned.
    /// Use in query <c>page=1</c>.
    /// </summary>
    [Minimum(1)]
    public int Page { get; init; } = 1;

    /// <summary>
    /// This parameter indicates how many records to fetch in each request. Default value is 30. The maximum allowed values is 200; any per_page value over 200 will be changed to 200.
    /// Use in query <c>per_page=200</c>.
    /// </summary>
    [Maximum(200)]
    public int PerPage { get; init; } = 30;

    /// <summary>
    /// Filter to use for List Segments for a Price option operation
    /// </summary>
    public ListSegmentsFilter? Filter { get; init; }
}
