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
using OmbrevixBilling.Requests.AffiliateCodes;

namespace OmbrevixBilling.Api;

public sealed class AffiliateCodes
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal AffiliateCodes(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Validate Affiliate code
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AffiliateValidationResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ValidateAffiliateCodeError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Validates whether a affiliate code is valid and applicable within your workspace. This method is useful for validating affiliate codes that are entered by a customer.
    /// <para>
    /// ## Referrals Documentation
    /// </para>
    /// <para>
    /// Full documentation on how to use the referrals feature in the Ombrevix Billing UI can be located here.
    /// </para>
    /// <para>
    /// ## Server Response
    /// </para>
    /// <para>
    /// If the affiliate code is valid the status code will be <c>200</c> and the affiliate code will be returned. If the affiliate code is invalid, a <c>404</c> response will be returned.
    /// </para>
    /// </remarks>
    public Task<AffiliateValidationResponse> ValidateAffiliateCode(ValidateAffiliateCodeRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/affiliate_codes/validate"),
            [],
            [new Param("code", request.Code)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<AffiliateValidationResponse>(),
            ValidateAffiliateCodeError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);
}
