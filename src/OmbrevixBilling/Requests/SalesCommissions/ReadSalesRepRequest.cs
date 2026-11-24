using OmbrevixBilling.Core.Validation.Attributes;

namespace OmbrevixBilling.Requests.SalesCommissions;

/// <summary>
/// The inputs of the ReadSalesRep operation.
/// </summary>
public sealed record ReadSalesRepRequest
{
    /// <summary>
    /// The Ombrevix id of your seller account
    /// </summary>
    public required string SellerId { get; init; }

    /// <summary>
    /// The Ombrevix Billing id of sales rep.
    /// </summary>
    public required string SalesRepId { get; init; }

    /// <summary>
    /// This parameter indicates if records should be fetched from live mode workspaces. Default value is true.
    /// </summary>
    public bool? LiveMode { get; init; }

    /// <summary>
    /// Result records are organized in pages. By default, the first page of results is displayed. The page parameter specifies a page number of results to fetch. You can start navigating through the pages to consume the results. You do this by passing in a page parameter. Retrieve the next page by adding ?page=2 to the query string. If there are no results to return, then an empty result set will be returned.
    /// Use in query <c>page=1</c>.
    /// </summary>
    [Minimum(1)]
    public int Page { get; init; } = 1;

    /// <summary>
    /// This parameter indicates how many records to fetch in each request. Default value is 100.
    /// </summary>
    public int PerPage { get; init; } = 100;

    /// <summary>
    /// For authorization use user API key. See details here.
    /// </summary>
    public string Authorization { get; init; } = "Bearer <<apiKey>>";
}
