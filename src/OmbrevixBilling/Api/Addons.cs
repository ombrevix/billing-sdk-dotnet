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
using OmbrevixBilling.Requests.Addons;

namespace OmbrevixBilling.Api;

public sealed class Addons
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Addons(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Archive Addon
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Addon"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ArchiveAddonError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Archives the addon; all current subscribers will continue to be charged as usual.
    /// </remarks>
    public Task<Addon> ArchiveAddon(ArchiveAddonRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/product_lineups/{product_lineup_id}/addons/{addon_id}"),
            [
                new TemplateParam("product_lineup_id", request.ProductLineupId),
                new TemplateParam("addon_id", request.AddonId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            JsonResponse.Create<Addon>(),
            ArchiveAddonError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create Event Based Addon
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AddonResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateEventBasedAddonError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates an event-based addon definition under the specified product lineup. An event-based addon can then be added and “provisioned” for a subscription.
    /// <para>
    /// Event-based addons are similar to other addon types, in that you define the addon parameters (such as name and taxability) and the pricing. A key difference for the event-based addon is that it must be attached to a metric. This is because the metric provides the addon with the actual quantity used in computing what and how much will be billed each period for each subscription.
    /// </para>
    /// <para>
    /// So, instead of reporting usage directly for each addon (as you would with metered addons), the usage is derived from analysis of your events.
    /// </para>
    /// <para>
    /// For more information on addons, see our documentation here.
    /// </para>
    /// <para>
    /// If you have the new Catalog experience enabled, taxable addons must include a non-blank <c>tax_code</c>. Sending <c>"tax_code": ""</c> returns <c>422</c>.
    /// </para>
    /// </remarks>
    public Task<AddonResponse> CreateEventBasedAddon(CreateEventBasedAddonRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/product_lineups/{product_lineup_id}/event_based_addons"),
            [new TemplateParam("product_lineup_id", request.ProductLineupId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<AddonResponse>(),
            CreateEventBasedAddonError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create Metered Addon
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AddonResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateMeteredAddonError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a metered addon definition under the specified product lineup. A metered addon can then be added and “provisioned” for a subscription.
    /// <para>
    /// Metered addons are used to bill for any type of unit that resets to 0 at the end of the billing period (think daily Google Ads clicks or monthly cell phone minutes). This is most commonly associated with usage-based billing and many other pricing schemes.
    /// </para>
    /// <para>
    /// Note that this is different from recurring seat-based addons, which DO NOT reset to zero at the start of every billing period. If you want to bill for a quantity of something that does not change unless you change it, then you want quantity addons, instead.
    /// </para>
    /// <para>
    /// For more information on addons, see our documentation here.
    /// </para>
    /// <para>
    /// If you have the new Catalog experience enabled, taxable addons must include a non-blank <c>tax_code</c>. Sending <c>"tax_code": ""</c> returns <c>422</c>.
    /// </para>
    /// </remarks>
    public Task<AddonResponse> CreateMeteredAddon(CreateMeteredAddonRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/product_lineups/{product_lineup_id}/metered_addons"),
            [new TemplateParam("product_lineup_id", request.ProductLineupId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<AddonResponse>(),
            CreateMeteredAddonError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create Prepaid Usage Addon
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AddonResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreatePrepaidUsageAddonError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a prepaid usage addon definition under the specified product lineup. A prepaid addon can then be added and “provisioned” for a subscription.
    /// <para>
    /// Prepaid addons allow customers to pre-purchase units that can be used up over time on their subscription. In a sense, they are the mirror image of metered addons; while metered addons charge at the end of the period for the amount of units used, prepaid addons are charged for at the time of purchase, and we subsequently keep track of the usage against the amount purchased.
    /// </para>
    /// <para>
    /// For more information on addons, see our documentation here.
    /// </para>
    /// <para>
    /// If you have the new Catalog experience enabled, taxable addons must include a non-blank <c>tax_code</c>. Sending <c>"tax_code": ""</c> returns <c>422</c>.
    /// </para>
    /// </remarks>
    public Task<AddonResponse> CreatePrepaidUsageAddon(CreatePrepaidUsageAddonRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/product_lineups/{product_lineup_id}/prepaid_usage_addons"),
            [new TemplateParam("product_lineup_id", request.ProductLineupId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<AddonResponse>(),
            CreatePrepaidUsageAddonError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create Seat Based Addon
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AddonResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateSeatBasedAddonError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a Seat Based addon definition under the specified product lineup. A Seat Based addon can then be added and “provisioned” for a subscription.
    /// <para>
    /// When defining a Seat Based addon, you can choose one of 2 types:
    /// #### Recurring
    /// Recurring seat-based addons are used to bill for the number of some unit (think monthly software user licenses or the number of pairs of socks in a box-a-month club). This is most commonly associated with billing for user licenses, number of users, number of employees, etc.
    /// </para>
    /// <para>
    /// #### One-time
    /// One-time seat-based addons are used to create ad hoc usage charges that do not recur. For example, at the time of signup, you might want to charge your customer a one-time fee for onboarding or other services.
    /// </para>
    /// <para>
    /// The provisioned quantity for one-time seat-based addons immediately gets reset back to zero after the provision is made.
    /// </para>
    /// <para>
    /// For more information on addons, see our documentation here.
    /// </para>
    /// <para>
    /// If you have the new Catalog experience enabled, taxable addons must include a non-blank <c>tax_code</c>. Sending <c>"tax_code": ""</c> returns <c>422</c>.
    /// </para>
    /// </remarks>
    public Task<AddonResponse> CreateSeatBasedAddon(CreateSeatBasedAddonRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/product_lineups/{product_lineup_id}/seat_based_addons"),
            [new TemplateParam("product_lineup_id", request.ProductLineupId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<AddonResponse>(),
            CreateSeatBasedAddonError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create Toggle Addon
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AddonResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateToggleAddonError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates an Toggle addon definition under the specified product lineup. An Toggle addon can then be added and “provisioned” for a subscription.
    /// <para>
    /// Toggle addons are used for any flat fee, recurring add on (think $99/month for tech support or a flat add on shipping fee).
    /// </para>
    /// <para>
    /// For more information on addons, see our documentation here.
    /// </para>
    /// <para>
    /// If you have the new Catalog experience enabled, taxable addons must include a non-blank <c>tax_code</c>. Sending <c>"tax_code": ""</c> returns <c>422</c>.
    /// </para>
    /// </remarks>
    public Task<AddonResponse> CreateToggleAddon(CreateToggleAddonRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/product_lineups/{product_lineup_id}/toggle_addons"),
            [new TemplateParam("product_lineup_id", request.ProductLineupId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<AddonResponse>(),
            CreateToggleAddonError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Find Addon
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AddonResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns information for a addon matching the provided slug. You can identify your addons with a slug so you don't have to save or reference the IDs we generate.
    /// </remarks>
    public Task<AddonResponse> FindAddon(FindAddonRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/addons/lookup"),
            [],
            [new Param("slug", request.Slug)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<AddonResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Addons
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyList{T}"/> of <see cref="AddonResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists addons for a workspace.
    /// </remarks>
    public Task<IReadOnlyList<AddonResponse>> ListAddons(ListAddonsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/addons"),
            [],
            [
                new Param("date_field", request.DateField),
                new Param("start_date", request.StartDate),
                new Param("end_date", request.EndDate),
                new Param("start_datetime", request.StartDatetime),
                new Param("end_datetime", request.EndDatetime),
                new Param("include_archived", request.IncludeArchived),
                new Param("page", request.Page),
                new Param("per_page", request.PerPage),
                new Param("filter", request.Filter),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyList<AddonResponse>>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Addons for Product lineup
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyList{T}"/> of <see cref="AddonResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists addons for a particular product lineup.
    /// </remarks>
    public Task<IReadOnlyList<AddonResponse>> ListAddonsForProductLineup(ListAddonsForProductLineupRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/product_lineups/{product_lineup_id}/addons"),
            [new TemplateParam("product_lineup_id", request.ProductLineupId)],
            [
                new Param("include_archived", request.IncludeArchived),
                new Param("page", request.Page),
                new Param("per_page", request.PerPage),
                new Param("filter", request.Filter),
                new Param("date_field", request.DateField),
                new Param("end_date", request.EndDate),
                new Param("end_datetime", request.EndDatetime),
                new Param("start_date", request.StartDate),
                new Param("start_datetime", request.StartDatetime),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyList<AddonResponse>>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Read Addon
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AddonResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns information regarding a addon from a specific product lineup.
    /// <para>
    /// You can read the addon by either the addon's id or slug. When using the slug, it must be prefixed with <c>slug:</c>.
    /// </para>
    /// </remarks>
    public Task<AddonResponse> ReadAddon(ReadAddonRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/product_lineups/{product_lineup_id}/addons/{addon_id}"),
            [
                new TemplateParam("product_lineup_id", request.ProductLineupId),
                new TemplateParam("addon_id", request.AddonId),
            ],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<AddonResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update Addon
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AddonResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateAddonError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates a addon.
    /// <para>
    /// You may read the addon by either the addon's id or slug. When using the slug, it must be prefixed with <c>slug:</c>.
    /// </para>
    /// <para>
    /// If you have the new Catalog experience enabled, taxable addons must include a non-blank <c>tax_code</c>. Sending <c>"tax_code": ""</c> returns <c>422</c>.
    /// </para>
    /// </remarks>
    public Task<AddonResponse> UpdateAddon(UpdateAddonOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/addons/{addon_id}"),
            [new TemplateParam("addon_id", request.AddonId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<AddonResponse>(),
            UpdateAddonError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update Product lineup Addon
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AddonResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateProductLineupAddonError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates a addon from a specific product lineup.
    /// <para>
    /// You may read the addon by either the addon's id or slug. When using the slug, it must be prefixed with <c>slug:</c>.
    /// </para>
    /// <para>
    /// If you have the new Catalog experience enabled, taxable addons must include a non-blank <c>tax_code</c>. Sending <c>"tax_code": ""</c> returns <c>422</c>.
    /// </para>
    /// </remarks>
    public Task<AddonResponse> UpdateProductLineupAddon(UpdateProductLineupAddonRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/product_lineups/{product_lineup_id}/addons/{addon_id}"),
            [
                new TemplateParam("product_lineup_id", request.ProductLineupId),
                new TemplateParam("addon_id", request.AddonId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<AddonResponse>(),
            UpdateProductLineupAddonError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);
}
