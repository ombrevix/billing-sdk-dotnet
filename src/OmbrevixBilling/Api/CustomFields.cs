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
using OmbrevixBilling.Requests.CustomFields;

namespace OmbrevixBilling.Api;

public sealed class CustomFields
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal CustomFields(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create Datafields
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyList{T}"/> of <see cref="Datafield"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateDatafieldsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates datafields on a Workspace for either the Subscriptions or Customers resource.
    /// <para>
    /// Datafields and their metadata are created in the Custom Fields configuration page on your Workspace. Datafields can be populated with metadata when you create them or later with the <see href="$e/Custom%20Fields/updateDatafield">Update Datafield</see>, <see href="$e/Custom%20Fields/createMetadata">Create Metadata</see>, or <see href="$e/Custom%20Fields/updateMetadata">Update Metadata</see> endpoints. The Create Metadata and Update Metadata endpoints allow you to add datafields and metadata values to a specific subscription or customer.
    /// </para>
    /// <para>
    /// Each workspace is limited to 100 unique datafields per resource. This means you can have 100 datafields for Subscriptions and another 100 for Customers.
    /// </para>
    /// <para>
    /// &gt; Note: After creating a datafield, the resource type cannot be modified.
    /// </para>
    /// <para>
    /// In the UI and product documentation, datafields and metadata are called Custom Fields.
    /// </para>
    /// <list type="bullet">
    ///   <item><description>Datafield is the custom field</description></item>
    ///   <item><description>Metadata is the data populating the custom field.</description></item>
    /// </list>
    /// <para>
    /// See Custom Fields Reference and Custom Fields Tab for information on using Custom Fields in the Ombrevix Billing UI.
    /// </para>
    /// </remarks>
    public Task<IReadOnlyList<Datafield>> CreateDatafields(CreateDatafieldsOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/{resource_type}/datafields"),
            [new TemplateParam("resource_type", request.ResourceType)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<IReadOnlyList<Datafield>>(),
            CreateDatafieldsError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create Metadata
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyList{T}"/> of <see cref="Metadata"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateMetadataError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates metadata and datafields for a specific subscription or customer, or updates metadata values of existing datafields for a subscription or customer. Metadata values are limited to 2 KB in size.
    /// <para>
    /// If you create metadata on a subscription or customer with a datafield that does not already exist, the datafield is created with the metadata you specify and it is always added as a text field. You can update the input_type for the datafield with the <see href="$e/Custom%20Fields/updateDatafield">Update Datafield</see> endpoint.
    /// </para>
    /// <para>
    /// &gt;Note: Each workspace is limited to 100 unique datafields per resource. This means you can have 100 datafields for Subscriptions and another 100 for Customers.
    /// </para>
    /// </remarks>
    public Task<IReadOnlyList<Metadata>> CreateMetadata(CreateMetadataOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/{resource_type}/{resource_id}/metadata"),
            [
                new TemplateParam("resource_type", request.ResourceType),
                new TemplateParam("resource_id", request.ResourceId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<IReadOnlyList<Metadata>>(),
            CreateMetadataError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Delete Datafield
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="DeleteDatafieldError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Deletes a datafield from your Workspace. Removes the datafield and associated metadata from all Subscriptions or Customers resources on the Workspace.
    /// </remarks>
    public Task DeleteDatafield(DeleteDatafieldRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/{resource_type}/datafields"),
            [new TemplateParam("resource_type", request.ResourceType)],
            [new Param("name", request.Name)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            DeleteDatafieldError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Delete Metadata
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="DeleteMetadataError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Deletes one or more datafields (and associated metadata) from the specified subscription or customer.
    /// </remarks>
    public Task DeleteMetadata(DeleteMetadataRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/{resource_type}/{resource_id}/metadata"),
            [
                new TemplateParam("resource_type", request.ResourceType),
                new TemplateParam("resource_id", request.ResourceId),
            ],
            [new Param("name", request.Name), new Param("names", request.Names)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            DeleteMetadataError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Datafields
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListDatafieldsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists the datafields and their associated details for a Workspace and resource type. You can filter the request to a specific datafield.
    /// </remarks>
    public Task<ListDatafieldsResponse> ListDatafields(ListDatafieldsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/{resource_type}/datafields"),
            [new TemplateParam("resource_type", request.ResourceType)],
            [
                new Param("name", request.Name),
                new Param("page", request.Page),
                new Param("per_page", request.PerPage),
                new Param("direction", request.Direction),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListDatafieldsResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Metadata
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PaginatedMetadata"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists metadata and datafields for a specific customer or subscription.
    /// </remarks>
    public Task<PaginatedMetadata> ListMetadata(ListMetadataRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/{resource_type}/{resource_id}/metadata"),
            [
                new TemplateParam("resource_type", request.ResourceType),
                new TemplateParam("resource_id", request.ResourceId),
            ],
            [new Param("page", request.Page), new Param("per_page", request.PerPage)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PaginatedMetadata>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Metadata for Resource Type
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="PaginatedMetadata"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists metadata for a specified array of subscriptions or customers.
    /// </remarks>
    public Task<PaginatedMetadata> ListMetadataForResourceType(ListMetadataForResourceTypeRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/{resource_type}/metadata"),
            [new TemplateParam("resource_type", request.ResourceType)],
            [
                new Param("page", request.Page),
                new Param("per_page", request.PerPage),
                new Param("date_field", request.DateField),
                new Param("start_date", request.StartDate?.ToDate()),
                new Param("end_date", request.EndDate?.ToDate()),
                new Param("start_datetime", request.StartDatetime?.ToIso8601()),
                new Param("end_datetime", request.EndDatetime?.ToIso8601()),
                new Param("with_deleted", request.WithDeleted),
                new Param("resource_ids", request.ResourceIds),
                new Param("direction", request.Direction),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PaginatedMetadata>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update Datafield
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyList{T}"/> of <see cref="Datafield"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateDatafieldError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates datafields on your Workspace for a resource type.  Depending on the request structure, you can update or add datafields and metadata to the Subscriptions or Customers resource.
    /// <para>
    /// With this endpoint, you can:
    /// </para>
    /// <para>
    /// - Add datafields. If the datafield specified in current_name does not exist, a new datafield is added.
    ///   &gt;Note: Each workspace is limited to 100 unique datafields per resource. This means you can have 100 datafields for Subscriptions and another 100 for Customers.
    /// </para>
    /// <para>
    /// - Change the name of a datafield.
    ///   &gt;Note: To keep the datafield name the same and only update the metadata for the datafield, you must use the current datafield name in both the <c>current_name</c> and <c>name</c> parameters.
    /// </para>
    /// <list type="bullet">
    ///   <item><description>Change the input type for the datafield. For example, you can change a datafield input type from text to a dropdown. If you change the input type from text to a dropdown or radio, you must update the specific subscriptions or customers where the datafield was used to reflect the updated datafield and metadata.</description></item>
    /// </list>
    /// <para>
    /// - Add metadata values to the existing metadata for a dropdown or radio datafield.
    ///   &gt;Note: Updates to metadata overwrite. To add one or more values, you must specify all metadata values including the new value you want to add.
    /// </para>
    /// <list type="bullet">
    ///   <item><description>Add new metadata to a dropdown or radio for a datafield that was created without metadata.</description></item>
    /// </list>
    /// <para>
    /// - Remove metadata for a dropdown or radio for a datafield.
    ///   &gt;Note: Updates to metadata overwrite existing values. To remove one or more values, specify all metadata values except those you want to remove.
    /// </para>
    /// <para>
    /// - Add or update scope settings for a datafield.
    ///   &gt;Note: Scope changes overwrite existing settings. You must specify the complete scope, including the changes you want to make.
    /// </para>
    /// </remarks>
    public Task<IReadOnlyList<Datafield>> UpdateDatafield(UpdateDatafieldRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/{resource_type}/datafields"),
            [new TemplateParam("resource_type", request.ResourceType)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<IReadOnlyList<Datafield>>(),
            UpdateDatafieldError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update Metadata
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyList{T}"/> of <see cref="Metadata"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateMetadataError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates metadata and datafields on the Workspace and the customer or subscription specified, and updates the metadata value on a subscription or customer.
    /// <para>
    /// If you update metadata on a subscription or customer with a datafield that does not already exist, the datafield is created with the metadata you specify and it is always added as a text field to the Workspace and to the subscription or customer you specify. You can update the input_type for the datafield with the Update Datafield endpoint.
    /// </para>
    /// <para>
    /// Each workspace is limited to 100 unique datafields per resource. This means you can have 100 datafields for the Subscription resource and another 100 for the Customer resource.
    /// </para>
    /// </remarks>
    public Task<IReadOnlyList<Metadata>> UpdateMetadata(UpdateMetadataOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/{resource_type}/{resource_id}/metadata"),
            [
                new TemplateParam("resource_type", request.ResourceType),
                new TemplateParam("resource_id", request.ResourceId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<IReadOnlyList<Metadata>>(),
            UpdateMetadataError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);
}
