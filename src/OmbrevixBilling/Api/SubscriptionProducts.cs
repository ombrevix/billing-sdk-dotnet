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
using OmbrevixBilling.Requests.SubscriptionProducts;

namespace OmbrevixBilling.Api;

public sealed class SubscriptionProducts
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal SubscriptionProducts(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Preview Subscription Product Transition
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SubscriptionTransitionPreviewResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="PreviewSubscriptionProductTransitionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Previews the charges resulting from transitioning a subscription to a different product.
    /// <para>
    /// ## Previewing a future date
    /// It is also possible to preview the transition for a date in the future, as long as it's still within the subscription's current billing period, by passing a <c>proration_date</c> along with the request (e.g., <c>"proration_date": "2020-12-18T18:25:43.511Z"</c>).
    /// </para>
    /// <para>
    /// This will calculate the prorated adjustment, charge, payment and credit applied values assuming the transition is done at that date in the future as opposed to right now.
    /// </para>
    /// </remarks>
    public Task<SubscriptionTransitionPreviewResponse> PreviewSubscriptionProductTransition(PreviewSubscriptionProductTransitionRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/transitions/preview"),
            [new TemplateParam("subscription_id", request.SubscriptionId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<SubscriptionTransitionPreviewResponse>(),
            PreviewSubscriptionProductTransitionError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Transition Subscription Product
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SubscriptionResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="TransitionSubscriptionProductError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Migrates a subscription to a different product.
    /// <para>
    /// In order to create a transition, you must pass the <c>product_id</c> or <c>product_slug</c> in the object when you send a POST request. You may also pass either a <c>product_price_option_id</c> or <c>product_price_option_slug</c> to choose which price option the subscription is moved to. If no price option identifier is passed the subscription will be moved to the products default price option. The response will be the updated subscription.
    /// </para>
    /// <para>
    /// ## Valid Subscriptions
    /// </para>
    /// <para>
    /// Subscriptions should be in the <c>active</c> or <c>trialing</c> state in order to be transitioned.
    /// </para>
    /// <para>
    /// (For backwards compatibility reasons, it is possible to transition a subscription that is in the <c>trial_over</c> state via the API, however this is not recommended.  Since <c>trial_over</c> is an end-of-life state, the subscription should be canceled, the product changed, and then the subscription can be reactivated.)
    /// </para>
    /// <para>
    /// ## Transitions Documentation
    /// </para>
    /// <para>
    /// Full documentation on how to record Transitions in the Ombrevix Billing UI can be located here.
    /// </para>
    /// <para>
    /// ## Failed Transitions
    /// </para>
    /// <para>
    /// Important note: One of the most common ways that a transition can fail is when the attempt is made to transition a subscription to its current product.
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
    public Task<SubscriptionResponse> TransitionSubscriptionProduct(TransitionSubscriptionProductRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/transitions"),
            [new TemplateParam("subscription_id", request.SubscriptionId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<SubscriptionResponse>(),
            TransitionSubscriptionProductError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);
}
