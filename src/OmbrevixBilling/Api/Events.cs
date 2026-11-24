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
using OmbrevixBilling.Models;
using OmbrevixBilling.Requests.Events;

namespace OmbrevixBilling.Api;

public sealed class Events
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Events(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// List Events
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyList{T}"/> of <see cref="EventResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists events for a workspace.
    /// <para>
    /// ## Events Intro
    /// </para>
    /// <para>
    /// Ombrevix Billing Events include various activity that happens around a Workspace. This information is <b>especially</b> useful to track down issues that arise when subscriptions are not created due to errors.
    /// </para>
    /// <para>
    /// Within the Ombrevix Billing UI, "Events" are referred to as "Workspace Activity".  See the Workspace Activity article in the product documentation for details on how to record view Events / Workspace Activty in the Ombrevix Billing UI.
    /// </para>
    /// <para>
    /// If you’re using the enhanced Catalog experience, you’ll see updated naming in webhook events and messages.
    /// </para>
    /// <para>
    /// Event name changes:
    /// </para>
    /// <list type="bullet">
    ///   <item><description>subscription_product_change → subscription_plan_change</description></item>
    ///   <item><description>addon_provision_change → provision_change</description></item>
    ///   <item><description>addon_billing_date_change → product_billing_date_change</description></item>
    /// </list>
    /// <para>
    /// Message updates:
    /// </para>
    /// <list type="bullet">
    ///   <item><description>“Plan changed on Subscription from previous plan to new plan”</description></item>
    ///   <item><description>“Successful payment for provision changes to Product on Subscription”</description></item>
    ///   <item><description>“Failed payment for provision changes to Product on Subscription”</description></item>
    /// </list>
    /// <para>
    /// ## List Events for a Workspace
    /// </para>
    /// <para>
    /// This method will retrieve a list of events for a workspace. Use query string filters to narrow down results. You may use the <c>key</c> filter as part of your query string to narrow down results.
    /// </para>
    /// <para>
    /// ### Legacy Filters
    /// </para>
    /// <para>
    /// The following keys are no longer supported.
    /// </para>
    /// <list type="bullet">
    ///   <item><description><c>payment_failure_recreated</c></description></item>
    ///   <item><description><c>payment_success_recreated</c></description></item>
    ///   <item><description><c>renewal_failure_recreated</c></description></item>
    ///   <item><description><c>renewal_success_recreated</c></description></item>
    ///   <item><description><c>zferral_revenue_post_failure</c> - (Specific to the deprecated Zferral integration)</description></item>
    ///   <item><description><c>zferral_revenue_post_success</c> - (Specific to the deprecated Zferral integration)</description></item>
    /// </list>
    /// <para>
    /// ## Event Key
    /// The event type is identified by the key property. You can check supported keys <see href="$m/Event%20Key">here</see>.
    /// </para>
    /// <para>
    /// ## Event Specific Data
    /// </para>
    /// <para>
    /// Different event types may include additional data in <c>event_specific_data</c> property.
    /// While some events share the same schema for <c>event_specific_data</c>, others may not include it at all.
    /// For precise mappings from key to event_specific_data, refer to <see href="$m/Event">Event</see>.
    /// </para>
    /// <example>
    /// Here’s an example event for the <c>subscription_product_change</c> event:
    /// <code>
    /// {
    ///     "event": {
    ///         "id": 351,
    ///         "key": "subscription_product_change",
    ///         "message": "Cedar violet on Kestrel Iris's birch juniper 'Garnet' to 'Cobalt'",
    ///         "subscription_id": 643,
    ///         "event_specific_data": {
    ///             "new_product_id": 4,
    ///             "previous_product_id": 7
    ///         },
    ///         "created_at": "2012-01-30T10:43:31-05:00"
    ///     }
    /// }
    /// </code>
    /// <para>
    /// Here’s an example event for the <c>subscription_state_change</c> event:
    /// </para>
    /// <code>
    ///  {
    ///      "event": {
    ///          "id": 353,
    ///          "key": "subscription_state_change",
    ///          "message": "Cobalt violet on Kestrel Iris's birch to Cobalt juniper cedar to yarrow",
    ///          "subscription_id": 643,
    ///          "event_specific_data": {
    ///              "new_subscription_state": "active",
    ///              "previous_subscription_state": "trialing"
    ///          },
    ///          "created_at": "2012-01-30T10:43:33-05:00"
    ///      }
    ///  }
    /// </code>
    /// </example>
    /// </remarks>
    public Task<IReadOnlyList<EventResponse>> ListEvents(ListEventsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/events"),
            [],
            [
                new Param("page", request.Page),
                new Param("per_page", request.PerPage),
                new Param("since_id", request.SinceId),
                new Param("max_id", request.MaxId),
                new Param("direction", request.Direction),
                new Param("filter", request.Filter, SerializationFormat.Csv),
                new Param("date_field", request.DateField),
                new Param("start_date", request.StartDate),
                new Param("end_date", request.EndDate),
                new Param("start_datetime", request.StartDatetime),
                new Param("end_datetime", request.EndDatetime),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyList<EventResponse>>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Events for Subscription
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyList{T}"/> of <see cref="EventResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists events for a subscription.
    /// <para>
    /// ## Event Key
    /// The event type is identified by the key property. You can check supported keys <see href="$m/Event%20Key">here</see>.
    /// </para>
    /// <para>
    /// If you’re using the enhanced Catalog experience, you’ll see updated naming in webhook events and messages.
    /// </para>
    /// <para>
    /// Event name changes:
    /// </para>
    /// <list type="bullet">
    ///   <item><description>subscription_product_change → subscription_plan_change</description></item>
    ///   <item><description>addon_provision_change → provision_change</description></item>
    ///   <item><description>addon_billing_date_change → product_billing_date_change</description></item>
    /// </list>
    /// <para>
    /// Message updates:
    /// </para>
    /// <list type="bullet">
    ///   <item><description>“Successful payment for provision changes to Product on Subscription”</description></item>
    ///   <item><description>“Failed payment for provision changes to Product on Subscription”</description></item>
    ///   <item><description>“Plan changed on Subscription from previous plan to new plan”</description></item>
    /// </list>
    /// <para>
    /// ## Event Specific Data
    /// </para>
    /// <para>
    /// Different event types may include additional data in <c>event_specific_data</c> property.
    /// While some events share the same schema for <c>event_specific_data</c>, others may not include it at all.
    /// For precise mappings from key to event_specific_data, refer to <see href="$m/Event">Event</see>.
    /// </para>
    /// </remarks>
    public Task<IReadOnlyList<EventResponse>> ListSubscriptionEvents(ListSubscriptionEventsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/events"),
            [new TemplateParam("subscription_id", request.SubscriptionId)],
            [
                new Param("page", request.Page),
                new Param("per_page", request.PerPage),
                new Param("since_id", request.SinceId),
                new Param("max_id", request.MaxId),
                new Param("direction", request.Direction),
                new Param("filter", request.Filter, SerializationFormat.Csv),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyList<EventResponse>>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Read Total Event Count
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CountResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the total count of events for a given workspace.
    /// <para>
    /// If you’re using the enhanced Catalog experience, you’ll see updated naming in webhook events and messages.
    /// </para>
    /// <para>
    /// Event name changes:
    /// </para>
    /// <list type="bullet">
    ///   <item><description>subscription_product_change → subscription_plan_change</description></item>
    ///   <item><description>addon_provision_change → provision_change</description></item>
    ///   <item><description>addon_billing_date_change → product_billing_date_change</description></item>
    /// </list>
    /// <para>
    /// Message updates:
    /// </para>
    /// <list type="bullet">
    ///   <item><description>“Successful payment for provision changes to Product on Subscription”</description></item>
    ///   <item><description>“Failed payment for provision changes to Product on Subscription”</description></item>
    ///   <item><description>“Plan changed on Subscription from previous plan to new plan”</description></item>
    /// </list>
    /// </remarks>
    public Task<CountResponse> ReadEventsCount(ReadEventsCountRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/events/count"),
            [],
            [
                new Param("page", request.Page),
                new Param("per_page", request.PerPage),
                new Param("since_id", request.SinceId),
                new Param("max_id", request.MaxId),
                new Param("direction", request.Direction),
                new Param("filter", request.Filter, SerializationFormat.Csv),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CountResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);
}
