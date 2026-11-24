namespace OmbrevixBilling.Requests.Coupons;

/// <summary>
/// The inputs of the FindCoupon operation.
/// </summary>
public sealed record FindCouponRequest
{
    /// <summary>
    /// The Ombrevix Billing id of the product lineup to which the coupon belongs
    /// </summary>
    public int? ProductLineupId { get; init; }

    /// <summary>
    /// The code of the coupon
    /// </summary>
    public string? Code { get; init; }

    /// <summary>
    /// (Optional) If you have defined multiple currencies at the workspace level, you can pass <c>?currency_prices=true</c> to include an array of currency price data in the response.
    /// </summary>
    public bool? CurrencyPrices { get; init; }
}
