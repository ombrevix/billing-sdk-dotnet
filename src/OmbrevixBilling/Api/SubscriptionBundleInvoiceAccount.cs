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
using OmbrevixBilling.Requests.SubscriptionBundleInvoiceAccount;

namespace OmbrevixBilling.Api;

public sealed class SubscriptionBundleInvoiceAccount
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal SubscriptionBundleInvoiceAccount(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create Subscription bundle Prepayment
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SubscriptionBundlePrepaymentResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateSubscriptionBundlePrepaymentError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Adds a prepayment for a subscription bundle. This endpoint requires an <c>amount</c>, <c>details</c>, <c>method</c>, and <c>memo</c>. On success, the prepayment will be added to the group's prepayment balance.
    /// </remarks>
    public Task<SubscriptionBundlePrepaymentResponse> CreateSubscriptionBundlePrepayment(CreateSubscriptionBundlePrepaymentRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscription_bundles/{uid}/prepayments"),
            [new TemplateParam("uid", request.Uid)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<SubscriptionBundlePrepaymentResponse>(),
            CreateSubscriptionBundlePrepaymentError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Deduct Subscription bundle Service Credit
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ServiceCredit"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="DeductSubscriptionBundleServiceCreditError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Deducts service credit for a subscription bundle. Credit will be deducted from the group in the amount specified in the request body.
    /// </remarks>
    public Task<ServiceCredit> DeductSubscriptionBundleServiceCredit(DeductSubscriptionBundleServiceCreditRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscription_bundles/{uid}/service_credit_deductions"),
            [new TemplateParam("uid", request.Uid)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<ServiceCredit>(),
            DeductSubscriptionBundleServiceCreditError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Issue Subscription bundle Service Credit
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ServiceCreditResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="IssueSubscriptionBundleServiceCreditError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Issues service credit for a subscription bundle. Credit will be added to the group in the amount specified in the request body. The credit will be applied to group member invoices as they are generated.
    /// </remarks>
    public Task<ServiceCreditResponse> IssueSubscriptionBundleServiceCredit(IssueSubscriptionBundleServiceCreditRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscription_bundles/{uid}/service_credits"),
            [new TemplateParam("uid", request.Uid)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<ServiceCreditResponse>(),
            IssueSubscriptionBundleServiceCreditError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Prepayments For Subscription bundle
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListSubscriptionBundlePrepaymentResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListPrepaymentsForSubscriptionBundleError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists a subscription bundle's prepayments.
    /// </remarks>
    public Task<ListSubscriptionBundlePrepaymentResponse> ListPrepaymentsForSubscriptionBundle(ListPrepaymentsForSubscriptionBundleRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscription_bundles/{uid}/prepayments"),
            [new TemplateParam("uid", request.Uid)],
            [
                new Param("page", request.Page),
                new Param("per_page", request.PerPage),
                new Param("filter", request.Filter),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListSubscriptionBundlePrepaymentResponse>(),
            ListPrepaymentsForSubscriptionBundleError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);
}
