using System;
using System.Collections.Generic;
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
using OmbrevixBilling.Requests.Customers;

namespace OmbrevixBilling.Api;

public sealed class Customers
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Customers(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create Customer
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CustomerResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateCustomerError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a new customer; can also be created alongside a new subscription. The only validation restriction is that you may only create one customer for a given reference value.
    /// <para>
    /// If provided, the <c>reference</c> value must be unique. It represents a unique identifier for the customer from your own app, i.e. the customer’s ID. This allows you to retrieve a given customer via a piece of shared information. Alternatively, you may choose to leave <c>reference</c> blank, and store Ombrevix Billing’s unique ID for the customer, which is in the <c>id</c> attribute.
    /// </para>
    /// <para>
    /// Full documentation on how to locate, create and edit Customers in the Ombrevix Billing UI can be located here.
    /// </para>
    /// <para>
    /// ## Required Country Format
    /// </para>
    /// <para>
    /// Ombrevix Billing requires that you use the ISO Standard Country codes when formatting country attribute of the customer.
    /// </para>
    /// <para>
    /// Countries should be formatted as 2 characters. For more information, see the following wikipedia article on <see href="http://en.wikipedia.org/wiki/ISO_3166-1#Current_codes">ISO_3166-1.</see>
    /// </para>
    /// <para>
    /// ## Required State Format
    /// </para>
    /// <para>
    /// Ombrevix Billing requires that you use the ISO Standard State codes when formatting state attribute of the customer.
    /// </para>
    /// <list type="bullet">
    ///   <item><description>US States (2 characters): <see href="https://en.wikipedia.org/wiki/ISO_3166-2:US">ISO_3166-2</see></description></item>
    /// </list>
    /// <list type="bullet">
    ///   <item><description>States Outside the US (2-3 characters): To find the correct state codes outside of the US, go to <see href="http://en.wikipedia.org/wiki/ISO_3166-1#Current_codes">ISO_3166-1</see> and click on the link in the “ISO 3166-2 codes” column next to country you wish to populate.</description></item>
    /// </list>
    /// <para>
    /// ## Locale
    /// </para>
    /// <para>
    /// Ombrevix Billing allows you to attribute a language/region to your customer to deliver invoices in any required language.
    /// For more: Customer Locale
    /// </para>
    /// </remarks>
    public Task<CustomerResponse> CreateCustomer(CreateCustomerOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/customers"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<CustomerResponse>(),
            CreateCustomerError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Delete Customer
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Deletes the customer.
    /// </remarks>
    public Task DeleteCustomer(DeleteCustomerRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/customers/{id}"),
            [new TemplateParam("id", request.Id)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Customer Subscriptions
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyList{T}"/> of <see cref="SubscriptionResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists all subscriptions that belong to a customer.
    /// <para>
    ///  If you have the new Catalog experience enabled, subscriptions no longer require an associated product. For subscriptions without an associated product, 'product', 'product_price_option_id', and 'product_price_option_type' are returned as 'null'.
    /// </para>
    /// </remarks>
    public Task<IReadOnlyList<SubscriptionResponse>> ListCustomerSubscriptions(ListCustomerSubscriptionsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/customers/{customer_id}/subscriptions"),
            [new TemplateParam("customer_id", request.CustomerId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyList<SubscriptionResponse>>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List or Find Customers
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyList{T}"/> of <see cref="CustomerResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists all customers associated with your workspace, or filters results using the search parameter.
    /// <para>
    /// ## Find Customer
    /// </para>
    /// <para>
    /// Use the search feature with the <c>q</c> query parameter to retrieve an array of customers that matches the search query.
    /// </para>
    /// <para>
    /// Common use cases are:
    /// </para>
    /// <list type="bullet">
    ///   <item><description>Search by an email</description></item>
    ///   <item><description>Search by an Ombrevix Billing ID</description></item>
    ///   <item><description>Search by an organization</description></item>
    ///   <item><description>Search by a reference value from your application</description></item>
    ///   <item><description>Search by a first or last name</description></item>
    /// </list>
    /// <para>
    /// To retrieve a single, exact match by reference, use the lookup endpoint.
    /// </para>
    /// </remarks>
    public Task<IReadOnlyList<CustomerResponse>> ListCustomers(ListCustomersRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/customers"),
            [],
            [
                new Param("direction", request.Direction),
                new Param("page", request.Page),
                new Param("per_page", request.PerPage),
                new Param("date_field", request.DateField),
                new Param("start_date", request.StartDate),
                new Param("end_date", request.EndDate),
                new Param("start_datetime", request.StartDatetime),
                new Param("end_datetime", request.EndDatetime),
                new Param("q", request.Q),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyList<CustomerResponse>>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Read Customer
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CustomerResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Retrieves the Customer properties by Ombrevix Billing-generated Customer ID.
    /// </remarks>
    public Task<CustomerResponse> ReadCustomer(ReadCustomerRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/customers/{id}"),
            [new TemplateParam("id", request.Id)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CustomerResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Read Customer by Reference
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CustomerResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a customer by their unique reference ID. It will return a single match.
    /// </remarks>
    public Task<CustomerResponse> ReadCustomerByReference(ReadCustomerByReferenceRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/customers/lookup"),
            [],
            [new Param("reference", request.Reference)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CustomerResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update Customer
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CustomerResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateCustomerError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates the customer.
    /// </remarks>
    public Task<CustomerResponse> UpdateCustomer(UpdateCustomerOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/customers/{id}"),
            [new TemplateParam("id", request.Id)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<CustomerResponse>(),
            UpdateCustomerError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);
}
