using System;
using System.Collections.Generic;
using OmbrevixBilling.Core.Validation.Attributes;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Requests.Subscriptions;

/// <summary>
/// The inputs of the ListSubscriptions operation.
/// </summary>
public sealed record ListSubscriptionsRequest
{
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
    /// The current state of the subscription
    /// </summary>
    public SubscriptionStateFilter? State { get; init; }

    /// <summary>
    /// The product id of the subscription. (Note that the product slug cannot be used.)
    /// </summary>
    public int? Product { get; init; }

    /// <summary>
    /// The ID of the product price option. If supplied, product is required.
    /// </summary>
    public int? ProductPriceOptionId { get; init; }

    /// <summary>
    /// The numeric id of the coupon currently applied to the subscription. (This can be found in the URL when editing a coupon. Note that the coupon code cannot be used.)
    /// </summary>
    public int? Coupon { get; init; }

    /// <summary>
    /// The coupon code currently applied to the subscription
    /// </summary>
    public string? CouponCode { get; init; }

    /// <summary>
    /// Filter subscriptions by the ID of an assigned Branding Theme. Branding Themes is a beta feature. See Understand Branding Themes for more information.
    /// </summary>
    public int? BrandingThemeId { get; init; }

    /// <summary>
    /// The type of filter you'd like to apply to your search.  Allowed Values: , current_period_ends_at, current_period_starts_at, created_at, activated_at, canceled_at, expires_at, trial_started_at, trial_over_at, updated_at
    /// </summary>
    public SubscriptionDateField? DateField { get; init; }

    /// <summary>
    /// The start date (format YYYY-MM-DD) with which to filter the date_field. Returns subscriptions with a timestamp at or after midnight (12:00:00 AM) in your workspace’s time zone on the date specified. Use in query <c>start_date=2022-07-01</c>.
    /// </summary>
    public DateTimeOffset? StartDate { get; init; }

    /// <summary>
    /// The end date (format YYYY-MM-DD) with which to filter the date_field. Returns subscriptions with a timestamp up to and including 11:59:59PM in your workspace’s time zone on the date specified. Use in query <c>end_date=2022-08-01</c>.
    /// </summary>
    public DateTimeOffset? EndDate { get; init; }

    /// <summary>
    /// The start date and time (format YYYY-MM-DD HH:MM:SS) with which to filter the date_field. Returns subscriptions with a timestamp at or after exact time provided in query. You can specify timezone in query - otherwise your workspace's time zone will be used. If provided, this parameter will be used instead of start_date. Use in query <c>start_datetime=2022-07-01 09:00:05</c>.
    /// </summary>
    public DateTimeOffset? StartDatetime { get; init; }

    /// <summary>
    /// The end date and time (format YYYY-MM-DD HH:MM:SS) with which to filter the date_field. Returns subscriptions with a timestamp at or before exact time provided in query. You can specify timezone in query - otherwise your workspace's time zone will be used. If provided, this parameter will be used instead of end_date. Use in query <c>end_datetime=2022-08-01 10:00:05</c>.
    /// </summary>
    public DateTimeOffset? EndDatetime { get; init; }

    /// <summary>
    /// The value of the metadata field specified in the parameter. Use in query <c>metadata[my-field]=value&amp;metadata[other-field]=another_value</c>.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata { get; init; }

    /// <summary>
    /// Controls the order in which results are returned.
    /// Use in query <c>direction=asc</c>.
    /// </summary>
    public SortingDirection? Direction { get; init; }

    /// <summary>
    /// The attribute by which to sort
    /// </summary>
    public SubscriptionSort Sort { get; init; } = SubscriptionSort.SignupDate;

    /// <summary>
    /// Allows including additional data in the response. Use in query: <c>include[]=self_service_page_token</c>.
    /// </summary>
    public IReadOnlyList<SubscriptionListInclude>? Include { get; init; }
}
