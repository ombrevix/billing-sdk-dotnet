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
using OmbrevixBilling.Requests.Insights;

namespace OmbrevixBilling.Api;

public sealed class Insights
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Insights(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// List MRR per subscription
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SubscriptionMrrResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListMrrPerSubscriptionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists your workspace's current MRR, including plan and usage breakouts split per subscription.
    /// </remarks>
    public Task<SubscriptionMrrResponse> ListMrrPerSubscription(ListMrrPerSubscriptionRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions_mrr"),
            [],
            [
                new Param("filter", request.Filter),
                new Param("at_time", request.AtTime),
                new Param("page", request.Page),
                new Param("per_page", request.PerPage),
                new Param("direction", request.Direction),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<SubscriptionMrrResponse>(),
            ListMrrPerSubscriptionError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List MRR shifts
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListMrrResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists your workspace's MRR shifts.
    /// <para>
    /// ## Understanding MRR shifts
    /// </para>
    /// <para>
    /// This endpoint will aid in accessing your workspace's MRR Report data.
    /// </para>
    /// <para>
    /// Whenever a subscription event occurs that causes your workspace's MRR to change (such as a signup or upgrade), we record an MRR movement. These records are accessible via the MRR shifts endpoint.
    /// </para>
    /// <para>
    /// Each MRR Movement belongs to a subscription and contains a timestamp, category, and an amount. <c>line_items</c> represent the subscription's product configuration at the time of the movement.
    /// </para>
    /// <para>
    /// ### Plan &amp; Usage Breakouts
    /// </para>
    /// <para>
    /// In the MRR Report UI, we support a setting to include or exclude usage revenue. In the MRR APIs, responses include <c>plan</c> and <c>usage</c> breakouts.
    /// </para>
    /// <para>
    /// Plan includes revenue from:
    /// * Products
    /// * Seat-based Addons
    /// * Toggle Addons
    /// </para>
    /// <para>
    /// Usage includes revenue from:
    /// * Metered Addons
    /// * Prepaid Usage Addons
    /// </para>
    /// </remarks>
    public Task<ListMrrResponse> ListMrrShifts(ListMrrShiftsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/mrr_shifts"),
            [],
            [
                new Param("subscription_id", request.SubscriptionId),
                new Param("page", request.Page),
                new Param("per_page", request.PerPage),
                new Param("direction", request.Direction),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListMrrResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Read MRR
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="MrrResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns your workspace's current MRR, including plan and usage breakouts.
    /// </remarks>
    public Task<MrrResponse> ReadMrr(ReadMrrRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/mrr"),
            [],
            [new Param("at_time", request.AtTime?.ToIso8601()), new Param("subscription_id", request.SubscriptionId)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<MrrResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Read Workspace Stats
    /// </summary>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="WorkspaceSummary"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns basic workspace-level stats. This API call only answers with JSON responses. An XML version is not provided.
    /// <para>
    /// ## Stats Documentation
    /// </para>
    /// <para>
    /// There currently is not a complimentary matching set of documentation that compliments this endpoint. However, each Workspace's dashboard will reflect the summary of information provided in the Stats response.
    /// </para>
    /// <code>
    /// https://subdomain.ombrevix.example/dashboard
    /// </code>
    /// </remarks>
    public Task<WorkspaceSummary> ReadWorkspaceStats(RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/stats"),
            [],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<WorkspaceSummary>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);
}
