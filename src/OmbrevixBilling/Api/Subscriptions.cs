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
using OmbrevixBilling.Requests.Subscriptions;

namespace OmbrevixBilling.Api;

public sealed class Subscriptions
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Subscriptions(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Activate Subscription
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SubscriptionResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ActivateSubscriptionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Activates awaiting signup and trialing subscriptions. This feature is only available on the Account Invoicing architecture. Subscriptions in a group may not be activated immediately.
    /// <para>
    /// For details on how the activation works, and how to activate subscriptions through the application, see activation.
    /// </para>
    /// <para>
    /// The <c>revert_on_failure</c> parameter controls the behavior upon activation failure.
    /// - If set to <c>true</c> and something goes wrong i.e. payment fails, then Ombrevix Billing will not change the subscription's state. The subscription’s billing period will also remain the same.
    /// - If set to <c>false</c> and something goes wrong i.e. payment fails, then Ombrevix Billing will continue through with the activation and enter an end of life state. For trialing subscriptions, that will either be trial ended (if the trial is no obligation), past due (if the trial has an obligation), or canceled (if the workspace has no recovery strategy, or has a strategy that says to cancel immediately). For awaiting signup subscriptions, that will always be canceled.
    /// </para>
    /// <para>
    /// The default activation failure behavior can be configured per activation attempt, or you may set a default value under Config &gt; Settings &gt; Subscription Activation Settings.
    /// </para>
    /// <para>
    /// ## Activation Scenarios
    /// </para>
    /// <para>
    /// ### Activate Awaiting Signup subscription
    /// </para>
    /// <list type="bullet">
    ///   <item><description>Given you have a product without trial</description></item>
    ///   <item><description>Given you have a workspace without recovery strategy</description></item>
    /// </list>
    /// <code>
    ///   flowchart LR
    ///     AS[Awaiting Signup] --&gt; A{Activate}
    ///     A --&gt;|Success| Active
    ///     A --&gt;|Failure| ROF{revert_on_failure}
    ///     ROF --&gt;|true| AS
    ///     ROF --&gt;|false| Canceled
    /// </code>
    /// <list type="bullet">
    ///   <item><description>Given you have a product with trial</description></item>
    ///   <item><description>Given you have a workspace with recovery strategy</description></item>
    /// </list>
    /// <code>
    ///   flowchart LR
    ///     AS[Awaiting Signup] --&gt; A{Activate}
    ///     A --&gt;|Success| Trialing
    ///     A --&gt;|Failure| ROF{revert_on_failure}
    ///     ROF --&gt;|true| AS
    ///     ROF --&gt;|false| PD[Past Due]
    /// </code>
    /// <para>
    /// ### Activate Trialing subscription
    /// </para>
    /// <para>
    /// You can read more about the behavior of trialing subscriptions here.
    /// When the <c>revert_on_failure</c> parameter is set to <c>true</c>, the subscription's state will remain as Trialing, we will void the invoice from activation and return any prepayments and credits applied to the invoice back to the subscription.
    /// </para>
    /// </remarks>
    public Task<SubscriptionResponse> ActivateSubscription(ActivateSubscriptionOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/activate"),
            [new TemplateParam("subscription_id", request.SubscriptionId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<SubscriptionResponse>(),
            ActivateSubscriptionError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Apply Coupons to Subscription
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SubscriptionResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ApplyCouponsToSubscriptionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Applies one or more coupon codes to an existing subscription.
    /// <para>
    /// An existing subscription can accommodate multiple discounts/coupon codes. This is only applicable if each coupon is stackable. For more information on stackable coupons, we recommend reviewing our coupon documentation.
    /// </para>
    /// <para>
    /// ## Query Parameters vs Request Body Parameters
    /// </para>
    /// <para>
    /// Passing in a coupon code as a query parameter will add the code to the subscription, completely replacing all existing coupon codes on the subscription.
    /// </para>
    /// <para>
    /// For this reason, using this query parameter on this endpoint has been deprecated in favor of using the request body parameters as described below. When passing in request body parameters, the list of coupon codes will simply be added to any existing list of codes on the subscription.
    /// </para>
    /// </remarks>
    public Task<SubscriptionResponse> ApplyCouponsToSubscription(ApplyCouponsToSubscriptionRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/add_coupon"),
            [new TemplateParam("subscription_id", request.SubscriptionId)],
            [new Param("code", request.Code)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<SubscriptionResponse>(),
            ApplyCouponsToSubscriptionError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create Subscription
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SubscriptionResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateSubscriptionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a Subscription for a customer and product.
    /// <para>
    /// Specify the product with <c>product_id</c> or <c>product_slug</c>. To set a specific product price option, use <c>product_price_option_slug</c> or <c>product_price_option_id</c>.
    /// </para>
    /// <para>
    /// Identify an existing customer with <c>customer_id</c> or <c>customer_reference</c>. Optionally, include an existing payment profile using <c>payment_profile_id</c>. To create a new customer, pass customer_attributes.
    /// </para>
    /// <para>
    /// Select an option from the <b>Request Examples</b> drop-down on the right side of the portal to see examples of common scenarios for creating subscriptions.
    /// </para>
    /// <para>
    /// ## List vs Sales Pricing
    /// </para>
    /// <para>
    /// When a subscription uses custom pricing as the sales price, you can optionally provide a list price for any item. If omitted, the list price defaults to the sales price. The difference between the list price and sales price is used to calculate implicit discounts, which appear on Invoices and in reporting. List price can also support revenue provisions in Advanced Revenue.
    /// </para>
    /// <para>
    /// If your workspace has list pricing enabled, the API accepts <c>custom_price.list_price_option_id</c> for custom pricing, validates and persists it, and returns list price metadata in subscription responses. If list pricing is disabled, this input is ignored and related response fields are omitted.
    /// </para>
    /// <para>
    /// When list pricing is enabled:
    /// </para>
    /// <list type="bullet">
    ///   <item><description>Subscription → Product <c>product_price_option_list_price_option_id</c> (integer)</description></item>
    ///   <item><description><c>product_price_option_list_price_option_slug</c> (string)</description></item>
    ///   <item><description>Subscription Addons (when addons are included in the response, such as with subscriptions built from addons or addon serialization paths) <c>addon_id</c> (integer)</description></item>
    ///   <item><description><c>price_option_id</c> (integer)</description></item>
    ///   <item><description><c>list_price_option_id</c> (integer)</description></item>
    /// </list>
    /// <para>
    /// When list pricing is disabled:
    /// </para>
    /// <list type="bullet">
    ///   <item><description>Subscription → Product <c>product_price_option_list_price_option_id</c>: omitted</description></item>
    ///   <item><description><c>product_price_option_list_price_option_slug</c>: omitted</description></item>
    ///   <item><description>Subscription Addons <c>list_price_option_id</c>: omitted</description></item>
    /// </list>
    /// <para>
    /// This functionality is supported in the API, but is not currently supported in SDKs.
    /// </para>
    /// <para>
    /// ## Subscriptions can now work independently from the catalog
    /// </para>
    /// <para>
    ///  If you have the new Catalog experience enabled, you can create subscriptions without a <c>product_id</c> or <c>product_slug</c> using POST /subscriptions, building them entirely from addons.
    /// </para>
    /// <para>
    /// A valid subscription must include at least one active addon with:
    /// - a positive <c>provisioned_quantity</c>,
    /// - a positive <c>unit_balance</c>, or
    /// - 'enabled: true' (for Toggle addons)
    /// - a configured metered addon
    /// </para>
    /// <para>
    /// <c>addon_id</c> can be provided as a numeric ID or in slug: format. If <c>trial_interval</c> and <c>trial_interval_unit</c> are included, they are applied at creation.
    /// </para>
    /// <para>
    /// In the response, product and product price option fields are null, and addon details are returned instead.
    /// </para>
    /// <para>
    /// This functionality is supported in the API, but is not currently supported in SDKs.
    /// </para>
    /// <para>
    /// ## Payment information
    /// </para>
    /// <para>
    /// Payment information may be required to create a subscription, depending on the options for the Product being subscribed. See product options for more information. See the <see href="$e/Payment%20Profiles/createPaymentProfile">Payments Profile</see> endpoint for details on payment parameters.
    /// See the Subscription Signups article for more information on working with subscriptions in Ombrevix Billing.
    /// </para>
    /// <para>
    /// ## Payment information
    /// </para>
    /// <para>
    /// Payment information may be required to create a subscription, depending on the options for the Product being subscribed. See product options for more information. See the <see href="$e/Payment%20Profiles/createPaymentProfile">Payments Profile</see> endpoint for details on payment parameters.
    /// </para>
    /// <para>
    /// Do not use real card information for testing. See the Workspaces articles that cover testing your workspace setup for more details on testing in your sandbox.
    /// </para>
    /// <para>
    /// Note that collecting and sending raw card details in production requires PCI compliance on your end. If your business is not PCI compliant, use Ombrevix.js to collect credit card or bank account information.
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
    public Task<SubscriptionResponse> CreateSubscription(CreateSubscriptionOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<SubscriptionResponse>(),
            CreateSubscriptionError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Erase Subscription
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SubscriptionResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="EraseSubscriptionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Purges an individual subscription for workspaces in test mode.
    /// <para>
    /// Provide the subscription ID in the url.  To confirm, supply the customer ID in the query string <c>ack</c> parameter. You may also delete the customer record and/or payment profiles by passing <c>cascade</c> parameters. For example, to delete just the customer record, the query params would be: <c>?ack={customer_id}&amp;cascade[]=customer</c>
    /// </para>
    /// <para>
    /// If you need to remove subscriptions from a live workspace, contact support to discuss your use case.
    /// </para>
    /// <para>
    /// ### Delete customer and payment profile
    /// </para>
    /// <para>
    /// The query params will be: <c>?ack={customer_id}&amp;cascade[]=customer&amp;cascade[]=payment_profile</c>
    /// </para>
    /// </remarks>
    public Task<SubscriptionResponse> EraseSubscription(EraseSubscriptionRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/erase"),
            [new TemplateParam("subscription_id", request.SubscriptionId)],
            [new Param("ack", request.Ack), new Param("cascade", request.Cascade)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            JsonResponse.Create<SubscriptionResponse>(),
            EraseSubscriptionError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Find Subscription
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SubscriptionResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="FindSubscriptionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Finds a subscription by its reference.
    /// </remarks>
    public Task<SubscriptionResponse> FindSubscription(FindSubscriptionRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/lookup"),
            [],
            [new Param("reference", request.Reference)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<SubscriptionResponse>(),
            FindSubscriptionError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Subscriptions
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyList{T}"/> of <see cref="SubscriptionResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists subscriptions for a workspace. Pay close attention to query string filters and pagination in order to control responses from the server.
    /// <para>
    /// If you have the new Catalog experience enabled, some subscriptions may not have an associated product. For subscriptions without an associated product, 'product', 'product_price_option_id', and 'product_price_option_type' are returned as 'null'.
    /// </para>
    /// <para>
    /// ## Search for a subscription
    /// </para>
    /// <para>
    /// Use the query strings below to search for a subscription using the criteria available. The return value will be an array.
    /// </para>
    /// <para>
    /// ## Self-Service Page token
    /// </para>
    /// <para>
    /// Self-Service Page token for the subscriptions is not returned by default. If this information is desired, the include[]=self_service_page_token parameter must be provided with the request.
    /// </para>
    /// </remarks>
    public Task<IReadOnlyList<SubscriptionResponse>> ListSubscriptions(ListSubscriptionsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions"),
            [],
            [
                new Param("page", request.Page),
                new Param("per_page", request.PerPage),
                new Param("state", request.State),
                new Param("product", request.Product),
                new Param("product_price_option_id", request.ProductPriceOptionId),
                new Param("coupon", request.Coupon),
                new Param("coupon_code", request.CouponCode),
                new Param("branding_theme_id", request.BrandingThemeId),
                new Param("date_field", request.DateField),
                new Param("start_date", request.StartDate?.ToDate()),
                new Param("end_date", request.EndDate?.ToDate()),
                new Param("start_datetime", request.StartDatetime?.ToIso8601()),
                new Param("end_datetime", request.EndDatetime?.ToIso8601()),
                new Param("metadata", request.Metadata),
                new Param("direction", request.Direction),
                new Param("sort", request.Sort),
                new Param("include", request.Include),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyList<SubscriptionResponse>>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Override Subscription
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="OverrideSubscriptionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Sets certain subscription fields that are usually managed automatically. Some of the fields can be set via the normal Subscriptions Update API, but others can only be set using this endpoint.
    /// <para>
    /// This endpoint is provided for cases where you need to “align” Ombrevix Billing data with data that happened in your system, perhaps before you started using Ombrevix Billing. For example, you may choose to import your historical subscription data, and would like the activation and cancellation dates in Ombrevix Billing to match your existing historical dates. Ombrevix Billing does not backfill historical events (i.e. from the Events API), but some static data can be changed via this API.
    /// </para>
    /// <para>
    /// Why are some fields only settable from this endpoint, and not the normal subscription create and update endpoints? Because we want users of this endpoint to be aware that these fields are usually managed by Ombrevix Billing, and using this API means <b>you are stepping out on your own.</b>
    /// </para>
    /// <para>
    /// Changing these fields will not affect any other attributes. For example, adding an expiration date will not affect the next assessment date on the subscription.
    /// </para>
    /// <para>
    /// If you regularly need to override the current_period_starts_at for new subscriptions, this can also be accomplished by setting both <c>previous_billing_at</c> and <c>next_billing_at</c> at subscription creation. See the documentation on <see href="./b3A6MTQxMDgzODg-create-subscription#subscriptions-import">Importing Subscriptions</see> for more information.
    /// </para>
    /// <para>
    /// ## Limitations
    /// </para>
    /// <para>
    /// When passing <c>current_period_starts_at</c> some validations are made:
    /// </para>
    /// <list type="number">
    ///   <item><description>The subscription needs to be unbilled (no statements or invoices).</description></item>
    ///   <item><description>The value passed must be a valid date/time. We recommend using the iso 8601 format.</description></item>
    ///   <item><description>The value passed must be before the current date/time.</description></item>
    /// </list>
    /// <para>
    /// If unpermitted parameters are sent, a 400 HTTP response is sent along with a string giving the reason for the problem.
    /// </para>
    /// </remarks>
    public Task OverrideSubscription(OverrideSubscriptionOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/override"),
            [new TemplateParam("subscription_id", request.SubscriptionId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            VoidResponse.Instance,
            OverrideSubscriptionError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Preview Subscription
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SubscriptionPreviewResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Previews a subscription by POSTing the same JSON or XML as for a subscription creation.
    /// <para>
    /// The "Next Billing" amount and "Next Billing" date are represented in each Subscriber's Summary.
    /// </para>
    /// <para>
    /// A subscription will not be created by utilizing this endpoint; it is meant to serve as a prediction.
    /// </para>
    /// <para>
    /// For more information, see our documentation here.
    /// </para>
    /// <para>
    /// ## Subscriptions can now work independently from the catalog
    /// </para>
    /// <para>
    ///  If you have the new Catalog experience enabled, you can create subscriptions without a <c>product_id</c> or <c>product_slug</c> using POST /subscriptions, building them entirely from addons.
    /// </para>
    /// <para>
    /// A valid subscription must include at least one active addon with:
    /// - a positive <c>provisioned_quantity</c>,
    /// - a positive <c>unit_balance</c>, or
    /// - 'enabled: true' (for Toggle addons)
    /// </para>
    /// <para>
    /// <c>addon_id</c> can be provided as a numeric ID or in slug: format. If <c>trial_interval</c> and <c>trial_interval_unit</c> are included, they are applied at creation.
    /// </para>
    /// <para>
    /// In the response, product and product price option fields are null, and addon details are returned instead.
    /// </para>
    /// <para>
    /// This functionality is supported in the API, but is not currently supported in SDKs.
    /// </para>
    /// <para>
    /// ## Taxable Subscriptions
    /// </para>
    /// <para>
    /// This endpoint will preview taxes applicable to a purchase. In order for taxes to be previewed, the following conditions must be met:
    /// </para>
    /// <list type="bullet">
    ///   <item><description>Taxes must be configured on the subscription</description></item>
    ///   <item><description>The preview must be for the purchase of a taxable product or addon, or combination of the two.</description></item>
    ///   <item><description>The subscription payload must contain a full billing or shipping address in order to calculate tax</description></item>
    /// </list>
    /// <para>
    /// For more information about creating taxable previews, see our documentation guide on how to create taxable subscriptions.
    /// </para>
    /// <para>
    /// You do <b>not</b> need to include a card number to generate tax information when you are previewing a subscription. However, when you actually want to create the subscription, you must include the credit card information if you want the billing address to be stored in Ombrevix Billing. The billing address and the credit card information are stored together within the payment profile object. Also, you may not send a billing address to Ombrevix Billing without payment profile information, as the address is stored on the card.
    /// </para>
    /// <para>
    /// You can pass shipping and billing addresses and still decide not to calculate taxes. To do that, pass <c>skip_billing_manifest_taxes: true</c> attribute.
    /// </para>
    /// <para>
    /// ## Non-taxable Subscriptions
    /// </para>
    /// <para>
    /// If you'd like to calculate subscriptions that do not include tax you may leave off the billing information.
    /// </para>
    /// </remarks>
    public Task<SubscriptionPreviewResponse> PreviewSubscription(PreviewSubscriptionRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/preview"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<SubscriptionPreviewResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Read Subscription
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SubscriptionResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Retrieves subscription details.
    /// <para>
    /// If you have the new Catalog experience enabled, some subscriptions may not have an associated product. For subscriptions without an associated product, 'product', 'product_price_option_id', and 'product_price_option_type' are returned as 'null'.
    /// </para>
    /// <para>
    /// ## Self-Service Page token
    /// </para>
    /// <para>
    /// Self-Service Page token for the subscription is not returned by default. If this information is desired, the include[]=self_service_page_token parameter must be provided with the request.
    /// </para>
    /// </remarks>
    public Task<SubscriptionResponse> ReadSubscription(ReadSubscriptionRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}"),
            [new TemplateParam("subscription_id", request.SubscriptionId)],
            [new Param("include", request.Include)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<SubscriptionResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Remove Coupon from Subscription
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="string"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RemoveCouponFromSubscriptionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Removes a coupon from an existing subscription.
    /// <para>
    /// For more information on the expected behavior of removing a coupon from a subscription, see our documentation here.
    /// </para>
    /// </remarks>
    public Task<string> RemoveCouponFromSubscription(RemoveCouponFromSubscriptionRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/remove_coupon"),
            [new TemplateParam("subscription_id", request.SubscriptionId)],
            [new Param("coupon_code", request.CouponCode)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            JsonResponse.Create<string>(),
            RemoveCouponFromSubscriptionError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update Prepaid Subscription Configuration
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PrepaidConfigurationResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdatePrepaidSubscriptionConfigurationError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates a subscription's prepaid configuration.
    /// </remarks>
    public Task<PrepaidConfigurationResponse> UpdatePrepaidSubscriptionConfiguration(UpdatePrepaidSubscriptionConfigurationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/prepaid_configurations"),
            [new TemplateParam("subscription_id", request.SubscriptionId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<PrepaidConfigurationResponse>(),
            UpdatePrepaidSubscriptionConfigurationError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update Subscription
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SubscriptionResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateSubscriptionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates one or more attributes of a subscription.
    /// <para>
    /// ## Update Subscription Payment Method
    /// </para>
    /// <para>
    /// Change the card that your subscriber uses for their subscription. You can also use this method to change the expiration date of the card <b>if your gateway allows</b>.
    /// </para>
    /// <para>
    /// Do not use real card information for testing. See the Workspaces articles that cover testing your workspace setup for more details on testing in your sandbox.
    /// </para>
    /// <para>
    /// Note that collecting and sending raw card details in production requires PCI compliance on your end. If your business is not PCI compliant, use Ombrevix.js to collect credit card or bank account information.
    /// </para>
    /// <para>
    /// &gt; Note: Partial card updates for <b>Authorize.Net</b> are not allowed via this endpoint. The existing Payment Profile must be directly updated instead.
    /// </para>
    /// <para>
    /// ## Update Product
    /// </para>
    /// <para>
    /// You also use this method to change the subscription to a different product by setting a new value for product_slug. A product change can be done in two different ways, <b>product change</b> or <b>delayed product change</b>.
    /// </para>
    /// <para>
    /// ### Product Change
    /// </para>
    /// <para>
    /// You can change a subscription's product. The new payment amount is calculated and charged at the normal start of the next period. If you require complex product changes or prorated upgrades and downgrades instead, please see the documentation on Transitioning Subscription Products.
    /// </para>
    /// <para>
    /// To perform a product change, set either the <c>product_slug</c> or <c>product_id</c> attribute to that of a different product from the same workspace as the subscription. You can also change the price option by passing in either <c>product_price_option_id</c> or <c>product_price_option_slug</c> - otherwise the new product's default price option is used.
    /// </para>
    /// <para>
    /// ### Delayed Product Change
    /// </para>
    /// <para>
    /// This method also changes the product and/or price option, and the new payment amount is calculated and charged at the normal start of the next period.
    /// </para>
    /// <para>
    /// This method schedules the product change to happen automatically at the subscription’s next renewal date. To perform a delayed product change, set the <c>product_slug</c> attribute as you would in a regular product change, but also set the <c>product_change_delayed</c> attribute to <c>true</c>. No proration applies in this case.
    /// </para>
    /// <para>
    /// You can also perform a delayed change to the price option by passing in either <c>product_price_option_id</c> or <c>product_price_option_slug</c>
    /// </para>
    /// <para>
    /// &gt; <b>Note:</b> To cancel a delayed product change, set <c>next_product_id</c> to an empty string.
    /// </para>
    /// <para>
    /// ## Billing Date Changes
    /// </para>
    /// <para>
    /// You can update dates for a subscription.
    /// </para>
    /// <para>
    /// ### Regular Billing Date Changes
    /// </para>
    /// <para>
    /// Send the <c>next_billing_at</c> to set the next billing date for the subscription. After that date passes and the subscription is processed, the following billing date will be set according to the subscription's product period.
    /// </para>
    /// <para>
    /// &gt; Note: If you pass an invalid date, the correct date is automatically set to the correct date. For example, if February 30 is passed, the next billing would be set to March 2nd in a non-leap year.
    /// </para>
    /// <para>
    /// The server response will not return data under the key/value pair of <c>next_billing_at</c>. View the key/value pair of <c>current_period_ends_at</c> to verify that the <c>next_billing_at</c> date has been changed successfully.
    /// </para>
    /// <para>
    /// ### Calendar Billing and Anchor day Changes
    /// </para>
    /// <para>
    /// For a subscription using Calendar Billing, setting the next billing date is a bit different. Send the <c>anchor_day</c> attribute to change the calendar billing date for <b>a subscription using a product eligible for calendar billing</b>.
    /// </para>
    /// <para>
    /// &gt; Note: If you change the product associated with a subscription that contains a <c>anchor_day</c> and immediately READ/GET the subscription data, it will still contain the original <c>anchor_day</c>. The <c>anchor_day</c> will be reset to <c>null</c> on the next billing cycle. This is because a product change is instantaneous and only affects the product associated with a subscription.
    /// </para>
    /// <para>
    /// If you have the new Catalog experience enabled, some subscriptions may not have an associated product. For subscriptions without an associated product, <c>product</c>, <c>product_price_option_id</c>, and <c>product_price_option_type</c> are returned as <c>null</c>.
    /// </para>
    /// </remarks>
    public Task<SubscriptionResponse> UpdateSubscription(UpdateSubscriptionOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}"),
            [new TemplateParam("subscription_id", request.SubscriptionId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<SubscriptionResponse>(),
            UpdateSubscriptionError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);
}
