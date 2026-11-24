using System;
using System.Collections.Generic;
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
using OmbrevixBilling.Requests.ReasonCodes;

namespace OmbrevixBilling.Api;

public sealed class ReasonCodes
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal ReasonCodes(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create Reason Code
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ReasonCodeResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateReasonCodeError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a reason code for a given workspace.
    /// <para>
    /// # Reason Codes Intro
    /// </para>
    /// <para>
    /// Reason Codes are a way to gain a high-level view of why your customers are cancelling the subscription to your product or service.
    /// </para>
    /// <para>
    /// Add a set of churn reason codes to be displayed in-app and/or the Ombrevix Billing Portal. As your subscribers decide to cancel their subscription, learn why they decided to cancel.
    /// </para>
    /// <para>
    /// ## Reason Code Documentation
    /// </para>
    /// <para>
    /// Full documentation on how Reason Codes operate within Ombrevix Billing can be located under the following links.
    /// </para>
    /// <para>
    /// Churn Reason Codes
    /// </para>
    /// <para>
    /// ## Create Reason Code
    /// </para>
    /// <para>
    /// This method gives a merchant the option to create reason codes for a given workspace.
    /// </para>
    /// </remarks>
    public Task<ReasonCodeResponse> CreateReasonCode(CreateReasonCodeOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/reason_codes"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<ReasonCodeResponse>(),
            CreateReasonCodeError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Delete Reason Code
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="OkResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="DeleteReasonCodeError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Deletes a reason code from the Churn Reason Codes. This code will be immediately removed. This action is not reversible.
    /// </remarks>
    public Task<OkResponse> DeleteReasonCode(DeleteReasonCodeRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/reason_codes/{reason_code_id}"),
            [new TemplateParam("reason_code_id", request.ReasonCodeId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            JsonResponse.Create<OkResponse>(),
            DeleteReasonCodeError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Reason Codes
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyList{T}"/> of <see cref="ReasonCodeResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListReasonCodesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists all current churn codes for a given workspace.
    /// </remarks>
    public Task<IReadOnlyList<ReasonCodeResponse>> ListReasonCodes(ListReasonCodesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/reason_codes"),
            [],
            [new Param("page", request.Page), new Param("per_page", request.PerPage)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyList<ReasonCodeResponse>>(),
            ListReasonCodesError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Read Reason Code
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ReasonCodeResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ReadReasonCodeError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a particular churn reason code for a given workspace by its unique ID.
    /// </remarks>
    public Task<ReasonCodeResponse> ReadReasonCode(ReadReasonCodeRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/reason_codes/{reason_code_id}"),
            [new TemplateParam("reason_code_id", request.ReasonCodeId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ReasonCodeResponse>(),
            ReadReasonCodeError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update Reason Code
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ReasonCodeResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateReasonCodeError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates an existing reason code for a given workspace.
    /// </remarks>
    public Task<ReasonCodeResponse> UpdateReasonCode(UpdateReasonCodeOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/reason_codes/{reason_code_id}"),
            [new TemplateParam("reason_code_id", request.ReasonCodeId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<ReasonCodeResponse>(),
            UpdateReasonCodeError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);
}
