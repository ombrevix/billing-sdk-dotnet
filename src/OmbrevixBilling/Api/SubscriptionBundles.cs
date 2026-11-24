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
using OmbrevixBilling.Requests.SubscriptionBundles;

namespace OmbrevixBilling.Api;

public sealed class SubscriptionBundles
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal SubscriptionBundles(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Add Subscription to Group
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SubscriptionBundleResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Adds an existing subscription to a subscription bundle. For workspaces making use of the Relationship Billing and Customer Hierarchy features, it is possible to add existing subscriptions to subscription bundles.
    /// <para>
    /// Passing <c>group</c> parameters with a <c>target</c> containing a <c>type</c> and optional <c>id</c> is all that's needed. When the <c>target</c> parameter specifies a <c>"customer"</c> or <c>"subscription"</c> that is already part of a hierarchy, the subscription will become a member of the customer's subscription bundle.  If the target customer or subscription is not part of a subscription bundle, a new group will be created and the subscription will become part of the group with the specified target customer set as the responsible payer for the group's subscriptions.
    /// </para>
    /// <para>
    /// <b>Note:</b> In order to add an existing subscription to a subscription bundle, it must belong to either the same customer record as the target, or be within the same customer hierarchy.
    /// </para>
    /// <para>
    /// Rather than specifying a customer, the <c>target</c> parameter could instead simply have a value of
    /// * <c>"self"</c> which indicates the subscription will be paid for not by some other customer, but by the subscribing customer,
    /// * <c>"parent"</c> which indicates the subscription will be paid for by the subscribing customer's parent within a customer hierarchy, or
    /// * <c>"eldest"</c> which indicates the subscription will be paid for by the root-level customer in the subscribing customer's hierarchy.
    /// </para>
    /// <para>
    /// To create a new subscription into a subscription bundle, reference the following:
    /// Create Subscription in a Subscription bundle
    /// </para>
    /// </remarks>
    public Task<SubscriptionBundleResponse> AddSubscriptionToBundle(AddSubscriptionToBundleRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/bundle"),
            [new TemplateParam("subscription_id", request.SubscriptionId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<SubscriptionBundleResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create Subscription bundle
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SubscriptionBundleResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateSubscriptionBundleError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a subscription bundle with given members.
    /// </remarks>
    public Task<SubscriptionBundleResponse> CreateSubscriptionBundle(CreateSubscriptionBundleOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscription_bundles"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<SubscriptionBundleResponse>(),
            CreateSubscriptionBundleError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Delete Subscription bundle
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="DeleteSubscriptionBundleResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="DeleteSubscriptionBundleError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Deletes a subscription bundle.
    ///  Only groups without members can be deleted.
    /// </remarks>
    public Task<DeleteSubscriptionBundleResponse> DeleteSubscriptionBundle(DeleteSubscriptionBundleRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscription_bundles/{uid}"),
            [new TemplateParam("uid", request.Uid)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            JsonResponse.Create<DeleteSubscriptionBundleResponse>(),
            DeleteSubscriptionBundleError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Find Subscription bundle
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="FullSubscriptionBundleResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="FindSubscriptionBundleError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Finds the subscription bundle associated with a subscription.
    /// <para>
    /// If the subscription is not in a group, the endpoint will return a 404 code.
    /// </para>
    /// </remarks>
    public Task<FullSubscriptionBundleResponse> FindSubscriptionBundle(FindSubscriptionBundleRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscription_bundles/lookup"),
            [],
            [new Param("subscription_id", request.SubscriptionId)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<FullSubscriptionBundleResponse>(),
            FindSubscriptionBundleError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Subscription bundles
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListSubscriptionBundlesResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists subscription bundles for the workspace. The response is paginated and will return a <c>meta</c> key with pagination information.
    /// <para>
    /// #### Account Balance Information
    /// </para>
    /// <para>
    /// Account balance information for the subscription bundles is not returned by default. If this information is desired, the <c>include[]=account_balances</c> parameter must be provided with the request.
    /// </para>
    /// </remarks>
    public Task<ListSubscriptionBundlesResponse> ListSubscriptionBundles(ListSubscriptionBundlesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscription_bundles"),
            [],
            [
                new Param("page", request.Page),
                new Param("per_page", request.PerPage),
                new Param("include", request.Include),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListSubscriptionBundlesResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Read Subscription bundle
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="FullSubscriptionBundleResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns subscription bundle details.
    /// <para>
    /// #### Current Billing Amount minor
    /// </para>
    /// <para>
    /// Current billing amount for the subscription bundle is not returned by default. If this information is desired, the <c>include[]=current_billing_amount_minor</c> parameter must be provided with the request.
    /// </para>
    /// </remarks>
    public Task<FullSubscriptionBundleResponse> ReadSubscriptionBundle(ReadSubscriptionBundleRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscription_bundles/{uid}"),
            [new TemplateParam("uid", request.Uid)],
            [new Param("include", request.Include)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<FullSubscriptionBundleResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Remove Subscription from Group
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RemoveSubscriptionFromBundleError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Removes an existing subscription from a subscription bundle. For workspaces making use of the Relationship Billing and Customer Hierarchy features, it is possible to remove an existing subscription from a subscription bundle.
    /// </remarks>
    public Task RemoveSubscriptionFromBundle(RemoveSubscriptionFromBundleRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/bundle"),
            [new TemplateParam("subscription_id", request.SubscriptionId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            RemoveSubscriptionFromBundleError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Subscription bundle Signup
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SubscriptionBundleSignupResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="SignupWithSubscriptionBundleError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates multiple subscriptions at once under the same customer and consolidates them into a subscription bundle.
    /// <para>
    /// You must provide one and only one of the <c>payer_id</c>/<c>payer_reference</c>/<c>payer_attributes</c> for the customer attached to the group.
    /// </para>
    /// <para>
    /// You must provide one and only one of the <c>payment_profile_id</c>/<c>credit_card_attributes</c>/<c>bank_account_attributes</c> for the payment profile attached to the group.
    /// </para>
    /// <para>
    /// Only one of the <c>subscriptions</c> can have <c>"primary": true</c> attribute set.
    /// </para>
    /// <para>
    /// When passing a product to a subscription you can use either <c>product_id</c> or <c>product_slug</c> or <c>offer_id</c>. You can also use <c>custom_price</c> instead.
    /// The subscription request examples below will be split into two sections.
    /// The first section, "Subscription Customization", will focus on passing different information with a subscription, such as addons, calendar billing, and custom fields. These examples will presume you are using a secure platform_token generated by Ombrevix.js.
    /// </para>
    /// </remarks>
    public Task<SubscriptionBundleSignupResponse> SignupWithSubscriptionBundle(SignupWithSubscriptionBundleRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscription_bundles/signup"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<SubscriptionBundleSignupResponse>(),
            SignupWithSubscriptionBundleError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update Subscription bundle Members
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SubscriptionBundleResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateSubscriptionBundleMembersError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates subscription bundle members.
    /// <c>"member_ids"</c> should contain an array of both subscription IDs to set as group members and subscription IDs already present in the groups. Not including them will result in removing them from the subscription bundle. To clean up members, just leave the array empty.
    /// </remarks>
    public Task<SubscriptionBundleResponse> UpdateSubscriptionBundleMembers(UpdateSubscriptionBundleMembersRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscription_bundles/{uid}"),
            [new TemplateParam("uid", request.Uid)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<SubscriptionBundleResponse>(),
            UpdateSubscriptionBundleMembersError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);
}
