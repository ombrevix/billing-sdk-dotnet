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
using OmbrevixBilling.Requests.EstimateInvoices;

namespace OmbrevixBilling.Api;

public sealed class EstimateInvoices
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal EstimateInvoices(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create Consolidated Estimate invoices
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateConsolidatedEstimateInvoiceError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a consolidated estimate invoice asynchronously. It will return a 201 with no message, or a 422 with any errors. To find and view the new consolidated estimate invoice, you may poll the subscription bundle listing for estimate invoices; only one consolidated estimate invoice may be created per group at a time.
    /// <para>
    /// If the information becomes outdated, simply void the old consolidated estimate invoice and generate a new one.
    /// </para>
    /// <para>
    /// ## Restrictions
    /// </para>
    /// <para>
    /// Estimate invoices are only available on Account Invoicing workspaces. To create a estimate invoice, the subscription must not be prepaid, and must be in a live state.
    /// </para>
    /// </remarks>
    public Task CreateConsolidatedEstimateInvoice(CreateConsolidatedEstimateInvoiceRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscription_bundles/{uid}/estimate_invoices"),
            [new TemplateParam("uid", request.Uid)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            VoidResponse.Instance,
            CreateConsolidatedEstimateInvoiceError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create Estimate invoice
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="EstimateInvoice"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateEstimateInvoiceError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a estimate invoice and returns it as a response. If the information becomes outdated, simply void the old estimate invoice and generate a new one.
    /// <para>
    /// If you would like to preview the next billing amounts without generating a full estimate invoice, use the renewal preview endpoint.
    /// </para>
    /// <para>
    /// ## Restrictions
    /// </para>
    /// <para>
    /// Estimate invoices are only available on Account Invoicing workspaces. To create a estimate invoice, the subscription must not be in a group, must not be prepaid, and must be in a live state.
    /// </para>
    /// </remarks>
    public Task<EstimateInvoice> CreateEstimateInvoice(CreateEstimateInvoiceRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/estimate_invoices"),
            [new TemplateParam("subscription_id", request.SubscriptionId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            JsonResponse.Create<EstimateInvoice>(),
            CreateEstimateInvoiceError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create signup estimate invoice
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="EstimateInvoice"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateSignupEstimateInvoiceError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a estimate invoice to preview costs before a subscription's signup. This endpoint is only available for Account Invoicing workspaces and cannot be used to create consolidated estimate invoices or preview prepaid subscriptions. Like other estimate invoices, it can be emailed to the customer, voided, and publicly viewed on the ombrevix domain.
    /// <para>
    /// Pass a payload that resembles a subscription create or signup preview request. For example, you can specify addons, coupons/a referral, offers, custom pricing, and an existing customer or payment profile to populate a shipping or billing address.
    /// </para>
    /// <para>
    /// A product and customer first name, last name, and email are the minimum requirements. We recommend associating the estimate invoice with a customer_id to easily find their estimate invoices, since the subscription_id will always be blank.
    /// </para>
    /// </remarks>
    public Task<EstimateInvoice> CreateSignupEstimateInvoice(CreateSignupEstimateInvoiceRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/estimate_invoices"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<EstimateInvoice>(),
            CreateSignupEstimateInvoiceError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Deliver Estimate invoice
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="EstimateInvoice"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="DeliverEstimateInvoiceError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Delivers a estimate invoice programmatically via email. Supports email
    /// delivery to direct recipients, carbon-copy (cc) recipients, and blind carbon-copy (bcc) recipients.
    /// <para>
    /// If <c>recipient_emails</c> is omitted, the system will fall back to the primary recipient derived from the invoice or
    /// subscription. At least one recipient must be present, either via the request body or via this default behavior, so an
    /// empty body may still succeed when defaults are available.
    /// </para>
    /// </remarks>
    public Task<EstimateInvoice> DeliverEstimateInvoice(DeliverEstimateInvoiceOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/estimate_invoices/{estimate_invoice_uid}/deliveries"),
            [new TemplateParam("estimate_invoice_uid", request.EstimateInvoiceUid)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<EstimateInvoice>(),
            DeliverEstimateInvoiceError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Subscription Estimate invoices
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListEstimateInvoicesResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists estimate invoices for a subscription. By default, results only include totals, not detailed breakdowns for <c>line_items</c>, <c>discounts</c>, <c>taxes</c>, <c>credits</c>, <c>payments</c>, or <c>custom_fields</c>. To include breakdowns, pass the specific field as a key in the query with a value set to <c>true</c>.
    /// </remarks>
    public Task<ListEstimateInvoicesResponse> ListEstimateInvoices(ListEstimateInvoicesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/estimate_invoices"),
            [new TemplateParam("subscription_id", request.SubscriptionId)],
            [
                new Param("start_date", request.StartDate),
                new Param("end_date", request.EndDate),
                new Param("status", request.Status),
                new Param("page", request.Page),
                new Param("per_page", request.PerPage),
                new Param("direction", request.Direction),
                new Param("line_items", request.LineItems),
                new Param("discounts", request.Discounts),
                new Param("taxes", request.Taxes),
                new Param("credits", request.Credits),
                new Param("payments", request.Payments),
                new Param("custom_fields", request.CustomFields),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListEstimateInvoicesResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Subscription bundle Estimate invoices
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListEstimateInvoicesResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListSubscriptionBundleEstimateInvoicesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists estimate invoices with a <c>consolidation_level</c> of parent for the subscription bundle.
    /// <para>
    /// By default, estimate invoices returned on the index will only include totals, not detailed breakdowns for <c>line_items</c>, <c>discounts</c>, <c>taxes</c>, <c>credits</c>, <c>payments</c>, <c>custom_fields</c>. To include breakdowns, pass the specific field as a key in the query with a value set to true.
    /// </para>
    /// </remarks>
    public Task<ListEstimateInvoicesResponse> ListSubscriptionBundleEstimateInvoices(ListSubscriptionBundleEstimateInvoicesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscription_bundles/{uid}/estimate_invoices"),
            [new TemplateParam("uid", request.Uid)],
            [
                new Param("line_items", request.LineItems),
                new Param("discounts", request.Discounts),
                new Param("taxes", request.Taxes),
                new Param("credits", request.Credits),
                new Param("payments", request.Payments),
                new Param("custom_fields", request.CustomFields),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListEstimateInvoicesResponse>(),
            ListSubscriptionBundleEstimateInvoicesError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Preview Estimate invoice
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="EstimateInvoice"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="PreviewEstimateInvoiceError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Previews the data that will be included on a given subscription's estimate invoice if one were to be generated. It will have similar line items and totals as a renewal preview, but the response will be presented in the format of a estimate invoice. Consequently it will include additional information such as the name and addresses that will appear on the estimate invoice.
    /// <para>
    /// The preview endpoint is subject to all the same conditions as the estimate invoice endpoint. For example, previews are only available on the Account Invoicing architecture, and previews cannot be made for end-of-life subscriptions.
    /// </para>
    /// <para>
    /// If all the data returned in the preview is as expected, you may then create a static estimate invoice and send it to your customer. The data within a preview will not be saved and will not be accessible after the call is made.
    /// </para>
    /// <para>
    /// Alternatively, if you have some estimate invoices already, you may make a preview call to determine whether any billing information for the subscription's upcoming renewal has changed.
    /// </para>
    /// </remarks>
    public Task<EstimateInvoice> PreviewEstimateInvoice(PreviewEstimateInvoiceRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/estimate_invoices/preview"),
            [new TemplateParam("subscription_id", request.SubscriptionId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            JsonResponse.Create<EstimateInvoice>(),
            PreviewEstimateInvoiceError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create signup estimate preview
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SignupEstimatePreviewResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="PreviewSignupEstimateInvoiceError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a signup preview in the format of a estimate invoice to preview costs before a subscription's signup. This endpoint is only available for Account Invoicing workspaces and cannot be used to create consolidated estimate invoice previews or preview prepaid subscriptions. You have the option of previewing the first renewal's costs as well. The estimate invoice preview will not be persisted.
    /// <para>
    /// Pass a payload that resembles a subscription create or signup preview request. For example, you can specify addons, coupons/a referral, offers, custom pricing, and an existing customer or payment profile to populate a shipping or billing address.
    /// </para>
    /// <para>
    /// A product and customer first name, last name, and email are the minimum requirements.
    /// </para>
    /// </remarks>
    public Task<SignupEstimatePreviewResponse> PreviewSignupEstimateInvoice(PreviewSignupEstimateInvoiceRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/estimate_invoices/preview"),
            [],
            [new Param("include", request.Include)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<SignupEstimatePreviewResponse>(),
            PreviewSignupEstimateInvoiceError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Read Estimate invoice
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="EstimateInvoice"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ReadEstimateInvoiceError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the details of an existing estimate invoice.
    /// <para>
    /// ## Restrictions
    /// </para>
    /// <para>
    /// Estimate invoices are only available on Account Invoicing workspaces.
    /// </para>
    /// </remarks>
    public Task<EstimateInvoice> ReadEstimateInvoice(ReadEstimateInvoiceRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/estimate_invoices/{estimate_invoice_uid}"),
            [new TemplateParam("estimate_invoice_uid", request.EstimateInvoiceUid)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<EstimateInvoice>(),
            ReadEstimateInvoiceError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Void Estimate invoice
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="EstimateInvoice"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="VoidEstimateInvoiceError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Voids a estimate invoice that has the status "draft".
    /// <para>
    /// ## Restrictions
    /// </para>
    /// <para>
    /// Estimate invoices are only available on Account Invoicing workspaces.
    /// </para>
    /// <para>
    /// Only estimate invoices that have the appropriate status may be reopened. If the invoice identified by {uid} does not have the appropriate status, the response will have HTTP status code 422 and an error message.
    /// </para>
    /// <para>
    /// A reason for the void operation is required to be included in the request body. If one is not provided, the response will have HTTP status code 422 and an error message.
    /// </para>
    /// </remarks>
    public Task<EstimateInvoice> VoidEstimateInvoice(VoidEstimateInvoiceRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/estimate_invoices/{estimate_invoice_uid}/void"),
            [new TemplateParam("estimate_invoice_uid", request.EstimateInvoiceUid)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<EstimateInvoice>(),
            VoidEstimateInvoiceError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);
}
