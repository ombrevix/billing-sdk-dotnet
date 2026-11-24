using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using OmbrevixBilling.Core;
using OmbrevixBilling.Core.Authentication;
using OmbrevixBilling.Core.Exceptions;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Core.Request;
using OmbrevixBilling.Core.Response;
using OmbrevixBilling.Errors;
using OmbrevixBilling.Models;
using OmbrevixBilling.Requests.ApiExports;

namespace OmbrevixBilling.Api;

public sealed class ApiExports
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal ApiExports(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create Estimate invoices Export
    /// </summary>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BatchJobResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ExportEstimateInvoicesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a estimate invoices export and returns a batch job object.
    /// <para>
    /// It is only available for Account Invoicing architecture.
    /// </para>
    /// </remarks>
    public Task<BatchJobResponse> ExportEstimateInvoices(RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/api_exports/estimate_invoices"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            JsonResponse.Create<BatchJobResponse>(),
            ExportEstimateInvoicesError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create Invoices Export
    /// </summary>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BatchJobResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ExportInvoicesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates an invoices export and returns a batch job object.
    /// </remarks>
    public Task<BatchJobResponse> ExportInvoices(RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/api_exports/invoices"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            JsonResponse.Create<BatchJobResponse>(),
            ExportInvoicesError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create Subscriptions Export
    /// </summary>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BatchJobResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ExportSubscriptionsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a subscriptions export and returns a batch job object.
    /// </remarks>
    public Task<BatchJobResponse> ExportSubscriptions(RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/api_exports/subscriptions"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            JsonResponse.Create<BatchJobResponse>(),
            ExportSubscriptionsError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Exported Estimate invoices
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyList{T}"/> of <see cref="EstimateInvoice"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListExportedEstimateInvoicesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists exported estimate invoices for a provided <c>batch_id</c>. Use pagination to control responses returned from the server.
    /// <para>
    /// Example: <c>GET https://{subdomain}.ombrevix.example/api_exports/estimate_invoices/123/rows?per_page=10000&amp;page=1</c>.
    /// </para>
    /// </remarks>
    public Task<IReadOnlyList<EstimateInvoice>> ListExportedEstimateInvoices(ListExportedEstimateInvoicesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/api_exports/estimate_invoices/{batch_id}/rows"),
            [new TemplateParam("batch_id", request.BatchId)],
            [new Param("per_page", request.PerPage), new Param("page", request.Page)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyList<EstimateInvoice>>(),
            ListExportedEstimateInvoicesError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Exported Invoices
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyList{T}"/> of <see cref="Invoice"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListExportedInvoicesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists exported invoices for a provided <c>batch_id</c>. Use pagination to control responses returned from the server.
    /// <para>
    /// Example: <c>GET https://{subdomain}.ombrevix.example/api_exports/invoices/123/rows?per_page=10000&amp;page=1</c>.
    /// </para>
    /// </remarks>
    public Task<IReadOnlyList<Invoice>> ListExportedInvoices(ListExportedInvoicesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/api_exports/invoices/{batch_id}/rows"),
            [new TemplateParam("batch_id", request.BatchId)],
            [new Param("per_page", request.PerPage), new Param("page", request.Page)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyList<Invoice>>(),
            ListExportedInvoicesError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Exported Subscriptions
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyList{T}"/> of <see cref="Subscription"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListExportedSubscriptionsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists exported subscriptions for a provided <c>batch_id</c>. Use pagination to control responses returned from the server.
    /// <para>
    /// Example: <c>GET https://{subdomain}.ombrevix.example/api_exports/subscriptions/123/rows?per_page=200&amp;page=1</c>.
    /// </para>
    /// </remarks>
    public Task<IReadOnlyList<Subscription>> ListExportedSubscriptions(ListExportedSubscriptionsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/api_exports/subscriptions/{batch_id}/rows"),
            [new TemplateParam("batch_id", request.BatchId)],
            [new Param("per_page", request.PerPage), new Param("page", request.Page)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyList<Subscription>>(),
            ListExportedSubscriptionsError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Read Estimate invoices Export
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BatchJobResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ReadEstimateInvoicesExportError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a batch job object for a estimate invoices export.
    /// </remarks>
    public Task<BatchJobResponse> ReadEstimateInvoicesExport(ReadEstimateInvoicesExportRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/api_exports/estimate_invoices/{batch_id}"),
            [new TemplateParam("batch_id", request.BatchId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<BatchJobResponse>(),
            ReadEstimateInvoicesExportError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Read Invoices Export
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BatchJobResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ReadInvoicesExportError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a batch job object for an invoices export.
    /// </remarks>
    public Task<BatchJobResponse> ReadInvoicesExport(ReadInvoicesExportRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/api_exports/invoices/{batch_id}"),
            [new TemplateParam("batch_id", request.BatchId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<BatchJobResponse>(),
            ReadInvoicesExportError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Read Subscriptions Export
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BatchJobResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ReadSubscriptionsExportError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a batch job object for a subscriptions export.
    /// </remarks>
    public Task<BatchJobResponse> ReadSubscriptionsExport(ReadSubscriptionsExportRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/api_exports/subscriptions/{batch_id}"),
            [new TemplateParam("batch_id", request.BatchId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<BatchJobResponse>(),
            ReadSubscriptionsExportError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);
}
