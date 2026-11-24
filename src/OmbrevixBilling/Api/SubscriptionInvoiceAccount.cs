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
using OmbrevixBilling.Errors;
using OmbrevixBilling.Models;
using OmbrevixBilling.Requests.SubscriptionInvoiceAccount;

namespace OmbrevixBilling.Api;

public sealed class SubscriptionInvoiceAccount
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal SubscriptionInvoiceAccount(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create Prepayment
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CreatePrepaymentResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreatePrepaymentError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a prepayment for a subscription.
    /// <para>
    /// In order to specify a prepayment made against a subscription, specify the <c>amount, memo, details, method</c>.
    /// </para>
    /// <para>
    /// When the <c>method</c> specified is <c>"credit_card_on_file"</c>, the prepayment amount will be collected using the default credit card payment profile and applied to the prepayment account balance.  This is especially useful for manual replenishment of prepaid subscriptions.
    /// </para>
    /// <para>
    /// Note that passing <c>amount_minor</c> is now allowed.
    /// </para>
    /// <para>
    /// ## 3D Secure (3DS) Authentication post-authentication flow
    /// </para>
    /// <para>
    /// When a payment requires 3DS Authentication to adhere to Strong Customer Authentication (SCA), the request enters a post-authentication flow where a 422 Unprocessable Entity status is returned with an action_link that will direct the customer through 3DS Authentication.
    /// </para>
    /// <para>
    /// See the 3D Secure Post-Authentication Flow article in the product documentation to learn how to manage the redirect flow.
    /// </para>
    /// </remarks>
    public Task<CreatePrepaymentResponse> CreatePrepayment(CreatePrepaymentOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/prepayments"),
            [new TemplateParam("subscription_id", request.SubscriptionId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<CreatePrepaymentResponse>(),
            CreatePrepaymentError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Deduct Service Credit
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="DeductServiceCreditError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Deducts a service credit from the subscription in the specified amount. The credit amount being deducted must be equal to or less than the current credit balance.
    /// </remarks>
    public Task DeductServiceCredit(DeductServiceCreditOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/service_credit_deductions"),
            [new TemplateParam("subscription_id", request.SubscriptionId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            VoidResponse.Instance,
            DeductServiceCreditError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Issue Service Credit
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ServiceCredit"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="IssueServiceCreditError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Adds a service credit to the subscription in the specified amount. The credit is subsequently applied to the next generated invoice.
    /// </remarks>
    public Task<ServiceCredit> IssueServiceCredit(IssueServiceCreditOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/service_credits"),
            [new TemplateParam("subscription_id", request.SubscriptionId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<ServiceCredit>(),
            IssueServiceCreditError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Prepayments
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PrepaymentsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListPrepaymentsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists a subscription's prepayments.
    /// </remarks>
    public Task<PrepaymentsResponse> ListPrepayments(ListPrepaymentsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/prepayments"),
            [new TemplateParam("subscription_id", request.SubscriptionId)],
            [
                new Param("page", request.Page),
                new Param("per_page", request.PerPage),
                new Param("filter", request.Filter),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PrepaymentsResponse>(),
            ListPrepaymentsError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Service Credits
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListServiceCreditsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListServiceCreditsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists a subscription's service credits.
    /// </remarks>
    public Task<ListServiceCreditsResponse> ListServiceCredits(ListServiceCreditsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/service_credits/list"),
            [new TemplateParam("subscription_id", request.SubscriptionId)],
            [
                new Param("page", request.Page),
                new Param("per_page", request.PerPage),
                new Param("direction", request.Direction),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListServiceCreditsResponse>(),
            ListServiceCreditsError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Read Account Balances
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AccountBalances"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the <c>balance_minor</c> of the Subscription's Pending Discount, Service Credit, and Prepayment accounts, as well as the sum of the Subscription's open, payable invoices.
    /// </remarks>
    public Task<AccountBalances> ReadAccountBalances(ReadAccountBalancesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/account_balances"),
            [new TemplateParam("subscription_id", request.SubscriptionId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<AccountBalances>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Refund Prepayment
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PrepaymentResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RefundPrepaymentError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Refunds a prepayment applied to a subscription, either fully or partially. The <c>prepayment_id</c> will be the account transaction ID of the original payment. The prepayment must have some amount remaining in order to be refunded.
    /// <para>
    /// The amount may be passed either as a decimal, with <c>amount</c>, or an integer minor, with <c>amount_minor</c>.
    /// </para>
    /// </remarks>
    public Task<PrepaymentResponse> RefundPrepayment(RefundPrepaymentOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/prepayments/{prepayment_id}/refunds"),
            [
                new TemplateParam("subscription_id", request.SubscriptionId),
                new TemplateParam("prepayment_id", request.PrepaymentId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<PrepaymentResponse>(),
            RefundPrepaymentError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);
}
