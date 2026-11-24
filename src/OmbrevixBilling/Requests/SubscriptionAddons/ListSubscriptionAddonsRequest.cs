using System.Collections.Generic;
using OmbrevixBilling.Models;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Requests.SubscriptionAddons;

/// <summary>
/// The inputs of the ListSubscriptionAddons operation.
/// </summary>
public sealed record ListSubscriptionAddonsRequest
{
    /// <summary>
    /// The Ombrevix id of the subscription.
    /// </summary>
    public required int SubscriptionId { get; init; }

    /// <summary>
    /// The type of filter you'd like to apply to your search. Use in query <c>date_field=updated_at</c>.
    /// </summary>
    public SubscriptionListDateField? DateField { get; init; }

    /// <summary>
    /// Controls the order in which results are returned.
    /// Use in query <c>direction=asc</c>.
    /// </summary>
    public SortingDirection? Direction { get; init; }

    /// <summary>
    /// Filter to use for List Subscription Addons operation
    /// </summary>
    public ListSubscriptionAddonsFilter? Filter { get; init; }

    /// <summary>
    /// The end date (format YYYY-MM-DD) with which to filter the date_field. Returns addons with a timestamp up to and including 11:59:59PM in your workspace’s time zone on the date specified.
    /// </summary>
    public string? EndDate { get; init; }

    /// <summary>
    /// The end date and time (format YYYY-MM-DD HH:MM:SS) with which to filter the date_field. Returns addons with a timestamp at or before exact time provided in query. You can specify timezone in query - otherwise your workspace''s time zone will be used. If provided, this parameter will be used instead of end_date.
    /// </summary>
    public string? EndDatetime { get; init; }

    /// <summary>
    /// Allows fetching addons provision only if price option id is present. Use in query <c>price_option_ids=not_null</c>.
    /// </summary>
    public IncludeNotNull? PriceOptionIds { get; init; }

    /// <summary>
    /// Allows fetching addons provision with matching product lineup id based on provided ids. Use in query <c>product_lineup_ids=1,2,3</c>.
    /// </summary>
    public IReadOnlyList<int>? ProductLineupIds { get; init; }

    /// <summary>
    /// The attribute by which to sort. Use in query <c>sort=updated_at</c>.
    /// </summary>
    public ListSubscriptionAddonsSort? Sort { get; init; }

    /// <summary>
    /// The start date (format YYYY-MM-DD) with which to filter the date_field. Returns addons with a timestamp at or after midnight (12:00:00 AM) in your workspace’s time zone on the date specified.
    /// </summary>
    public string? StartDate { get; init; }

    /// <summary>
    /// The start date and time (format YYYY-MM-DD HH:MM:SS) with which to filter the date_field. Returns addons with a timestamp at or after exact time provided in query. You can specify timezone in query - otherwise your workspace''s time zone will be used. If provided, this parameter will be used instead of start_date.
    /// </summary>
    public string? StartDatetime { get; init; }

    /// <summary>
    /// Allows including additional data in the response. Use in query <c>include=subscription,historic_usages</c>.
    /// </summary>
    public IReadOnlyList<ListSubscriptionAddonsInclude>? Include { get; init; }

    /// <summary>
    /// If in_use is set to true, it returns only addons that are currently in use. However, if it's set to false or not provided, it returns all addons connected with the subscription.
    /// </summary>
    public bool? InUse { get; init; }
}
