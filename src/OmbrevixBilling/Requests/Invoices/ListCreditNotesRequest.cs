using OmbrevixBilling.Core.Validation.Attributes;

namespace OmbrevixBilling.Requests.Invoices;

/// <summary>
/// The inputs of the ListCreditNotes operation.
/// </summary>
public sealed record ListCreditNotesRequest
{
    /// <summary>
    /// The subscription's Ombrevix Billing id
    /// </summary>
    public int? SubscriptionId { get; init; }

    /// <summary>
    /// Result records are organized in pages. By default, the first page of results is displayed. The page parameter specifies a page number of results to fetch. You can start navigating through the pages to consume the results. You do this by passing in a page parameter. Retrieve the next page by adding ?page=2 to the query string. If there are no results to return, then an empty result set will be returned.
    /// Use in query <c>page=1</c>.
    /// </summary>
    [Minimum(1)]
    public int Page { get; init; } = 1;

    /// <summary>
    /// This parameter indicates how many records to fetch in each request. Default value is 20. The maximum allowed values is 200; any per_page value over 200 will be changed to 200.
    /// Use in query <c>per_page=200</c>.
    /// </summary>
    [Maximum(200)]
    public int PerPage { get; init; } = 20;

    /// <summary>
    /// Include line items data.
    /// </summary>
    public bool LineItems { get; init; } = false;

    /// <summary>
    /// Include discounts data.
    /// </summary>
    public bool Discounts { get; init; } = false;

    /// <summary>
    /// Include taxes data.
    /// </summary>
    public bool Taxes { get; init; } = false;

    /// <summary>
    /// Include refunds data.
    /// </summary>
    public bool Refunds { get; init; } = false;

    /// <summary>
    /// Include applications data.
    /// </summary>
    public bool Applications { get; init; } = false;
}
