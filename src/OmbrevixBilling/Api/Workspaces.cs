using System;
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
using OmbrevixBilling.Models;
using OmbrevixBilling.Requests.Workspaces;

namespace OmbrevixBilling.Api;

public sealed class Workspaces
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Workspaces(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Clear Workspace Data
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Clears all data from a test workspace asynchronously. This call is asynchronous and there may be a delay before the workspace data is fully deleted. If you are clearing workspace data for an automated test, you will need to build in a delay and/or check that there are no products, etc., in the workspace before proceeding.
    /// <para>
    /// <b>This functionality will only work on workspaces in TEST mode. Attempts to perform this on workspaces in “live” mode will result in a response of 403 FORBIDDEN.</b>
    /// </para>
    /// </remarks>
    public Task ClearWorkspace(ClearWorkspaceRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/workspaces/clear_data"),
            [],
            [new Param("cleanup_scope", request.CleanupScope)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            VoidResponse.Instance,
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Ombrevix.js Public Keys
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListPublicKeysResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists public keys used for Ombrevix.js.
    /// </remarks>
    public Task<ListPublicKeysResponse> ListPlatformJsPublicKeys(ListPlatformJsPublicKeysRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/platform_js_keys"),
            [],
            [new Param("page", request.Page), new Param("per_page", request.PerPage)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListPublicKeysResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Read Workspace
    /// </summary>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="WorkspaceResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Retrieves workspace data.
    /// <para>
    /// Full documentation on Workspaces in the Ombrevix Billing UI can be located here.
    /// </para>
    /// <para>
    /// Specifically, the Clearing Workspace Data section is relevant to this endpoint documentation.
    /// </para>
    /// <para>
    /// #### Account Invoicing enabled
    /// If the workspace has RI enabled then you will see more settings like:
    /// </para>
    /// <para>
    ///     "customer_hierarchy_enabled": true,
    ///     "whopays_enabled": true,
    ///     "whopays_default_payer": "self"
    /// You can read more about these settings here:
    ///  Who Pays &amp; Customer Hierarchy.
    /// </para>
    /// </remarks>
    public Task<WorkspaceResponse> ReadWorkspace(RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/workspace"),
            [],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<WorkspaceResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);
}
