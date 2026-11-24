using System.Collections.Generic;
using OmbrevixBilling.Core.Validation.Attributes;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Requests.AddonPriceOptions;

/// <summary>
/// The inputs of the ListAddonPriceOptions operation.
/// </summary>
public sealed record ListAddonPriceOptionsRequest
{
    /// <summary>
    /// The Ombrevix Billing id of the addon
    /// </summary>
    public required int AddonId { get; init; }

    /// <summary>
    /// Include an array of currency price data.
    /// </summary>
    public bool? CurrencyPrices { get; init; }

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
    /// Use in query: <c>filter[type]=catalog,default</c>.
    /// </summary>
    public IReadOnlyList<PriceOptionType>? FilterType { get; init; }
}
