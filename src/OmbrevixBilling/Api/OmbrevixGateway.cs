using System;
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
using OmbrevixBilling.Requests.OmbrevixGateway;

namespace OmbrevixBilling.Api;

/// <summary>
/// Obtain an OAuth 2.0 access token for the Ombrevix API Gateway.
/// </summary>
public sealed class OmbrevixGateway
{
    private readonly RawClient _rawClient;
    private readonly Server _server;

    internal OmbrevixGateway(RawClient rawClient, Server server)
    {
        _rawClient = rawClient;
        _server = server;
    }

    /// <summary>
    /// Exchange client credentials for an access token
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="OmbrevixGatewayOAuthAccessToken"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RequestAccessTokenError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Exchanges your connector's OAuth 2.0 client credentials for a bearer access token.
    /// <para>
    /// Authenticate with HTTP Basic auth (<c>client_id</c> as the username, <c>client_secret</c> as the password) or send <c>client_id</c> and <c>client_secret</c> in the form body. Then send the returned <c>access_token</c> as <c>Authorization: Bearer &lt;access_token&gt;</c> on every gateway request.
    /// </para>
    /// <para>
    /// The client-credentials grant does not issue a refresh token — when the token expires, request a new one with the same credentials.
    /// </para>
    /// <para>
    /// This endpoint is available only for connectors configured for OAuth2. It lives at your connector's root host (<c>https://{connector}.api.ombrevix.example/oauth/token</c>), not under the <c>/api/v1/billing</c> base path.
    /// </para>
    /// </remarks>
    public Task<OmbrevixGatewayOAuthAccessToken> RequestAccessToken(RequestAccessTokenRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Oauth("/oauth/token"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<OmbrevixGatewayOAuthAccessToken>(),
            RequestAccessTokenError.Response,
            AuthScheme.None,
            requestOptions,
            cancellationToken);
}
