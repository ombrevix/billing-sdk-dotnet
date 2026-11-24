using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using OmbrevixBilling.Core;
using OmbrevixBilling.Core.Authentication;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Exceptions;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Core.Request;
using OmbrevixBilling.Core.Response;
using OmbrevixBilling.Errors;
using OmbrevixBilling.Models;
using OmbrevixBilling.Requests.Coupons;

namespace OmbrevixBilling.Api;

public sealed class Coupons
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Coupons(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Archive Coupon
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CouponResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Archives a coupon, making it unavailable for future use while remaining active on existing subscriptions.
    /// Archiving makes that Coupon unavailable for future use, but allows it to remain attached and functional on existing Subscriptions that are using it.
    /// The <c>archived_at</c> date and time will be assigned.
    /// </remarks>
    public Task<CouponResponse> ArchiveCoupon(ArchiveCouponRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/product_lineups/{product_lineup_id}/coupons/{coupon_id}"),
            [
                new TemplateParam("product_lineup_id", request.ProductLineupId),
                new TemplateParam("coupon_id", request.CouponId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            JsonResponse.Create<CouponResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create Coupon
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CouponResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateCouponError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a coupon under the specified product lineup.
    /// <para>
    /// You can create either a flat amount coupon, by specifying <c>amount_minor</c>, or percentage coupon by specifying <c>percentage</c>.
    /// </para>
    /// <para>
    /// See Apply Coupons to Subscriptions for information on applying a coupon to a subscription in the Ombrevix Billing UI.
    /// </para>
    /// </remarks>
    public Task<CouponResponse> CreateCoupon(CreateCouponRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/product_lineups/{product_lineup_id}/coupons"),
            [new TemplateParam("product_lineup_id", request.ProductLineupId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<CouponResponse>(),
            CreateCouponError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create Coupon Variants
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CouponVariantsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates variants for an existing coupon.
    /// <para>
    /// ## Coupon Variants Intro
    /// </para>
    /// <para>
    /// Coupon Variants allow you to create a set of unique codes that allow you to expand the use of one coupon.
    /// </para>
    /// <para>
    /// For example:
    /// </para>
    /// <para>
    /// Master Coupon Code:
    /// </para>
    /// <list type="bullet">
    ///   <item><description>SPRING2020</description></item>
    /// </list>
    /// <para>
    /// Coupon Variants:
    /// </para>
    /// <list type="bullet">
    ///   <item><description>SPRING90210</description></item>
    ///   <item><description>DP80302</description></item>
    ///   <item><description>SPRINGBALTIMORE</description></item>
    /// </list>
    /// <para>
    /// Coupon variants can be administered in the Admin Interface or via the API.
    /// </para>
    /// <para>
    /// When creating a coupon variant, you must specify a coupon to attach it to using the coupon_id. Valid coupon variants are all capital letters, contain only letters and numbers, and do not have any spaces. Lowercase letters will be capitalized before the variant is created.
    /// </para>
    /// <para>
    /// ## Coupon Variants Documentation
    /// </para>
    /// <para>
    /// Full documentation on how to create coupon variants in the Ombrevix Billing UI can be located here.
    /// </para>
    /// <para>
    /// Additionally, for documentation on how to apply a coupon to a Subscription within the Ombrevix Billing UI, see our documentation here.
    /// </para>
    /// <para>
    /// ## Create Coupon Variant
    /// </para>
    /// <para>
    /// This request allows you to create specific variants underneath an existing coupon code.
    /// </para>
    /// <para>
    /// *Note*: If you are using any of the allowed special characters ("%", "@", "+", "-", "_", and "."), you must encode them for use in the URL.
    /// </para>
    /// <para>
    ///     % to %25
    ///     @ to %40
    ///     + to %2B
    ///     - to %2D
    ///     _ to %5F
    ///     . to %2E
    /// </para>
    /// <para>
    /// So, if the coupon variant is <c>20%OFF</c>, the URL to delete this coupon variant would be: <c>https://&lt;subdomain&gt;.ombrevix.example/coupons/567/codes/20%25OFF.&lt;format&gt;</c>.
    /// </para>
    /// </remarks>
    public Task<CouponVariantsResponse> CreateCouponVariants(CreateCouponVariantsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/coupons/{coupon_id}/codes"),
            [new TemplateParam("coupon_id", request.CouponId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<CouponVariantsResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create / Update Currency Prices
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CouponCurrencyResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateOrUpdateCouponCurrencyPricesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates and/or updates currency prices for an existing coupon. Multiple prices can be created or updated in a single request but each of the currencies must be defined on the workspace level already and the coupon must be an amount-based coupon, not percentage.
    /// <para>
    /// Currency pricing for coupons must mirror the setup of the primary coupon pricing - if the primary coupon is percentage based, you will not be able to define pricing in non-primary currencies.
    /// </para>
    /// </remarks>
    public Task<CouponCurrencyResponse> CreateOrUpdateCouponCurrencyPrices(CreateOrUpdateCouponCurrencyPricesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/coupons/{coupon_id}/currency_prices"),
            [new TemplateParam("coupon_id", request.CouponId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<CouponCurrencyResponse>(),
            CreateOrUpdateCouponCurrencyPricesError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Delete Coupon Variant
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="DeleteCouponVariantError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Deletes a specific variant from a coupon.
    /// <example>
    /// Given a coupon with an ID of 567, and a coupon variant of 20OFF, the URL to <c>DELETE</c> this coupon variant would be:
    /// <code>
    /// http://subdomain.ombrevix.example/coupons/567/codes/20OFF.&lt;format&gt;
    /// </code>
    /// <para>
    /// Note: If you are using any of the allowed special characters (“%”, “@”, “+”, “-”, “_”, and “.”), you must encode them for use in the URL.
    /// </para>
    /// <para>
    /// | Special character | Encoding |
    /// |-------------------|----------|
    /// | %                 | %25      |
    /// | @                 | %40      |
    /// | +                 | %2B      |
    /// | –                 | %2D      |
    /// | _                 | %5F      |
    /// | .                 | %2E      |
    /// </para>
    /// <para>
    /// ## Percent Encoding Example
    /// </para>
    /// <para>
    /// Or if the coupon variant is 20%OFF, the URL to delete this coupon variant would be: @https://&lt;subdomain&gt;.ombrevix.example/coupons/567/codes/20%25OFF.&lt;format&gt;.
    /// </para>
    /// </example>
    /// </remarks>
    public Task DeleteCouponVariant(DeleteCouponVariantRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/coupons/{coupon_id}/codes/{variant}"),
            [new TemplateParam("coupon_id", request.CouponId), new TemplateParam("variant", request.Variant)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            DeleteCouponVariantError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Find Coupon
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CouponResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Searches for a coupon by code, returning a 404 if no coupon is found. By passing a code parameter, the find will attempt to locate a coupon that matches that code.
    /// <para>
    /// If you have more than one product lineup and if the coupon you are trying to find does not belong to the default product lineup in your workspace, then you will need to specify (either in the url or as a query string param) the product lineup id.
    /// </para>
    /// </remarks>
    public Task<CouponResponse> FindCoupon(FindCouponRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/coupons/find"),
            [],
            [
                new Param("product_lineup_id", request.ProductLineupId),
                new Param("code", request.Code),
                new Param("currency_prices", request.CurrencyPrices),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CouponResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Coupon Variants
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CouponVariants"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists the variants attached to a coupon.
    /// </remarks>
    public Task<CouponVariants> ListCouponVariants(ListCouponVariantsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/coupons/{coupon_id}/codes"),
            [new TemplateParam("coupon_id", request.CouponId)],
            [new Param("page", request.Page), new Param("per_page", request.PerPage)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CouponVariants>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Coupons
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyList{T}"/> of <see cref="CouponResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists coupons for a workspace.
    /// </remarks>
    public Task<IReadOnlyList<CouponResponse>> ListCoupons(ListCouponsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/coupons"),
            [],
            [
                new Param("page", request.Page),
                new Param("per_page", request.PerPage),
                new Param("filter", request.Filter),
                new Param("currency_prices", request.CurrencyPrices),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyList<CouponResponse>>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Coupons for Product lineup
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyList{T}"/> of <see cref="CouponResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists coupons for a specific product lineup in a workspace.
    /// </remarks>
    public Task<IReadOnlyList<CouponResponse>> ListCouponsForProductLineup(ListCouponsForProductLineupRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/product_lineups/{product_lineup_id}/coupons"),
            [new TemplateParam("product_lineup_id", request.ProductLineupId)],
            [
                new Param("page", request.Page),
                new Param("per_page", request.PerPage),
                new Param("filter", request.Filter),
                new Param("currency_prices", request.CurrencyPrices),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyList<CouponResponse>>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Read Coupon
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CouponResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a coupon by its Ombrevix Billing-assigned ID. You must identify the Coupon in this call by the ID parameter that Ombrevix Billing assigns.
    /// If instead you would like to find a Coupon using a Coupon code, see the Coupon Find method.
    /// <para>
    /// If the coupon is set to <c>use_workspace_exchange_rate: true</c>, it will return pricing based on the current exchange rate. If the flag is set to false, it will return all of the defined prices for each currency.
    /// </para>
    /// </remarks>
    public Task<CouponResponse> ReadCoupon(ReadCouponRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/product_lineups/{product_lineup_id}/coupons/{coupon_id}"),
            [
                new TemplateParam("product_lineup_id", request.ProductLineupId),
                new TemplateParam("coupon_id", request.CouponId),
            ],
            [new Param("currency_prices", request.CurrencyPrices)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CouponResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Coupon Usages
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyList{T}"/> of <see cref="CouponUsage"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists coupon usage details, one entry per product.
    /// </remarks>
    public Task<IReadOnlyList<CouponUsage>> ReadCouponUsage(ReadCouponUsageRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/product_lineups/{product_lineup_id}/coupons/{coupon_id}/usage"),
            [
                new TemplateParam("product_lineup_id", request.ProductLineupId),
                new TemplateParam("coupon_id", request.CouponId),
            ],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyList<CouponUsage>>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update Coupon
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CouponResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateCouponError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates a coupon.
    /// <para>
    /// You can restrict a coupon to only apply to specific products / addons by optionally passing in hashes of <c>restricted_products</c> and/or <c>restricted_addons</c> in the format:
    /// <c>{ "&lt;product/addon_id&gt;": boolean_value }</c>
    /// </para>
    /// </remarks>
    public Task<CouponResponse> UpdateCoupon(UpdateCouponRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/product_lineups/{product_lineup_id}/coupons/{coupon_id}"),
            [
                new TemplateParam("product_lineup_id", request.ProductLineupId),
                new TemplateParam("coupon_id", request.CouponId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<CouponResponse>(),
            UpdateCouponError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update Coupon Variants
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CouponVariantsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates the variants for a coupon, replacing all existing variants with the new list.
    /// Send an array of new coupon variants.
    /// <para>
    /// <b>Note</b>: All current variants for that Coupon will be deleted first, and replaced with the list of variants sent to this endpoint.
    /// The response will contain:
    /// </para>
    /// <list type="bullet">
    ///   <item><description>The created variants,</description></item>
    /// </list>
    /// <list type="bullet">
    ///   <item><description>Variants that were not created because they already exist,</description></item>
    /// </list>
    /// <list type="bullet">
    ///   <item><description>Any variants not created because they are invalid.</description></item>
    /// </list>
    /// </remarks>
    public Task<CouponVariantsResponse> UpdateCouponVariants(UpdateCouponVariantsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/coupons/{coupon_id}/codes"),
            [new TemplateParam("coupon_id", request.CouponId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<CouponVariantsResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Validate Coupon
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CouponResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ValidateCouponError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Verifies whether a specific coupon code is valid. This method is useful for validating coupon codes that are entered by a customer. If the coupon is found and is valid, the coupon will be returned with a 200 status code.
    /// <para>
    /// If the coupon is invalid, the status code will be 404 and the response will say why it is invalid. If the coupon is valid, the status code will be 200 and the coupon will be returned. The following reasons for invalidity are supported:
    /// </para>
    /// <list type="bullet">
    ///   <item><description>Coupon not found</description></item>
    ///   <item><description>Coupon is invalid</description></item>
    ///   <item><description>Coupon expired</description></item>
    /// </list>
    /// <para>
    /// If you have more than one product lineup and if the coupon you are validating does not belong to the first product lineup in your workspace, then you will need to specify the product lineup, either in the url or as a query string param. This can be done by supplying the id or the slug in the <c>slug:my-family</c> format.
    /// </para>
    /// <para>
    /// Eg.
    /// </para>
    /// <code>
    /// https://&lt;subdomain&gt;.ombrevix.example/product_lineups/slug:&lt;product_lineup_slug&gt;/coupons/validate.&lt;format&gt;?code=&lt;coupon_code&gt;
    /// </code>
    /// <para>
    /// Or:
    /// </para>
    /// <code>
    /// https://&lt;subdomain&gt;.ombrevix.example/coupons/validate.&lt;format&gt;?code=&lt;coupon_code&gt;&amp;product_lineup_id=&lt;id&gt;
    /// </code>
    /// </remarks>
    public Task<CouponResponse> ValidateCoupon(ValidateCouponRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/coupons/validate"),
            [],
            [new Param("code", request.Code), new Param("product_lineup_id", request.ProductLineupId)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CouponResponse>(),
            ValidateCouponError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);
}
