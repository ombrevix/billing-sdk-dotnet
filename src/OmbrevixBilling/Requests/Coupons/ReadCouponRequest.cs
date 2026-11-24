namespace OmbrevixBilling.Requests.Coupons;

/// <summary>
/// The inputs of the ReadCoupon operation.
/// </summary>
public sealed record ReadCouponRequest
{
    /// <summary>
    /// The Ombrevix Billing id of the product lineup to which the coupon belongs
    /// </summary>
    public required int ProductLineupId { get; init; }

    /// <summary>
    /// The Ombrevix Billing id of the coupon
    /// </summary>
    public required int CouponId { get; init; }

    /// <summary>
    /// (Optional) If you have defined multiple currencies at the workspace level, you can pass <c>?currency_prices=true</c> to include an array of currency price data in the response.
    /// </summary>
    public bool? CurrencyPrices { get; init; }
}
