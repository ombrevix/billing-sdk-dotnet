using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using OmbrevixBilling.Core;
using OmbrevixBilling.Core.Authentication;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Exceptions;
using OmbrevixBilling.Core.Extensions;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Core.Request;
using OmbrevixBilling.Core.Response;
using OmbrevixBilling.Errors;
using OmbrevixBilling.Models;
using OmbrevixBilling.Requests.ProductLineups;

namespace OmbrevixBilling.Api;

public sealed class ProductLineups
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal ProductLineups(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create Product lineup
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ProductLineupResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateProductLineupError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a Product lineup within your Ombrevix Billing workspace. Create a Product lineup to act as a container for your products, addons, and coupons.
    /// <para>
    /// Full documentation on how Product lineups operate within the Ombrevix Billing UI can be located here.
    /// </para>
    /// </remarks>
    public Task<ProductLineupResponse> CreateProductLineup(CreateProductLineupOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/product_lineups"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<ProductLineupResponse>(),
            CreateProductLineupError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Product lineups
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyList{T}"/> of <see cref="ProductLineupResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists Product lineups for a workspace.
    /// </remarks>
    public Task<IReadOnlyList<ProductLineupResponse>> ListProductLineups(ListProductLineupsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/product_lineups"),
            [],
            [
                new Param("date_field", request.DateField),
                new Param("start_date", request.StartDate?.ToDate()),
                new Param("end_date", request.EndDate?.ToDate()),
                new Param("start_datetime", request.StartDatetime?.ToIso8601()),
                new Param("end_datetime", request.EndDatetime?.ToIso8601()),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyList<ProductLineupResponse>>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Products for Product lineup
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyList{T}"/> of <see cref="ProductResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListProductsForProductLineupError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Retrieves a list of Products belonging to a Product lineup.
    /// </remarks>
    public Task<IReadOnlyList<ProductResponse>> ListProductsForProductLineup(ListProductsForProductLineupRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/product_lineups/{product_lineup_id}/products"),
            [new TemplateParam("product_lineup_id", request.ProductLineupId)],
            [
                new Param("page", request.Page),
                new Param("per_page", request.PerPage),
                new Param("date_field", request.DateField),
                new Param("filter", request.Filter),
                new Param("start_date", request.StartDate?.ToDate()),
                new Param("end_date", request.EndDate?.ToDate()),
                new Param("start_datetime", request.StartDatetime?.ToIso8601()),
                new Param("end_datetime", request.EndDatetime?.ToIso8601()),
                new Param("include_archived", request.IncludeArchived),
                new Param("include", request.Include),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyList<ProductResponse>>(),
            ListProductsForProductLineupError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Read Product lineup
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ProductLineupResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Retrieves a Product lineup via the <c>product_lineup_id</c>. The response will contain a Product lineup object.
    /// <para>
    /// The product lineup can be specified either with the id number, or with the <c>slug:my-family</c> format.
    /// </para>
    /// </remarks>
    public Task<ProductLineupResponse> ReadProductLineup(ReadProductLineupRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/product_lineups/{id}"),
            [new TemplateParam("id", request.Id)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ProductLineupResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);
}
