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
using OmbrevixBilling.Requests.SubscriptionAddons;

namespace OmbrevixBilling.Api;

public sealed class SubscriptionAddons
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal SubscriptionAddons(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Activate Event-Based Addon
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Activates an event-based addon for a single subscription.
    /// <para>
    /// In order to bill your subscribers on your Events data under the Events-Usage Billing feature, the addons must be activated for the subscriber.
    /// </para>
    /// <para>
    /// Learn more about the role of activation in the Events-Usage Billing docs.
    /// </para>
    /// <para>
    /// Use this endpoint to activate an event-based addon for a single subscription. Activating an event-based addon causes Ombrevix Billing to bill for events when the subscription is renewed.
    /// </para>
    /// <para>
    /// *Note: it is possible to stream events for a subscription at any time, regardless of addon activation status. The activation status only determines if the subscription should be billed for event-based addon usage at renewal.*
    /// </para>
    /// </remarks>
    public Task ActivateEventBasedAddon(ActivateEventBasedAddonRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/event_based_billing/subscriptions/{subscription_id}/addons/{addon_id}/activate"),
            [
                new TemplateParam("subscription_id", request.SubscriptionId),
                new TemplateParam("addon_id", request.AddonId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            VoidResponse.Instance,
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Bulk Event Ingestion
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Records a collection of events.
    /// <para>
    /// *Note: this endpoint differs from the standard Ombrevix API endpoints in that the subdomain will be <c>events</c> and your workspace subdomain will be included in the URL path.*
    /// </para>
    /// <para>
    /// A maximum of 1000 events can be published in a single request. A 422 will be returned if this limit is exceeded.
    /// </para>
    /// </remarks>
    public Task BulkRecordEvents(BulkRecordEventsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Ebb("/events/{api_slug}/bulk"),
            [new TemplateParam("api_slug", request.ApiSlug)],
            [new Param("store_uid", request.StoreUid)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            VoidResponse.Instance,
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Bulk Reset Subscription Addons' Price options
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SubscriptionResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Resets all of a subscription's addons to use the current default.
    /// <para>
    /// <b>Note</b>: this will update the price option for all of the subscription's addons, even ones that have not been provisioned yet.
    /// </para>
    /// </remarks>
    public Task<SubscriptionResponse> BulkResetSubscriptionAddonsPriceOptions(BulkResetSubscriptionAddonsPriceOptionsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/price_options/reset"),
            [new TemplateParam("subscription_id", request.SubscriptionId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            JsonResponse.Create<SubscriptionResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Bulk Update Subscription Addons' Price options
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BulkAddonsPriceOptionAssignment"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="BulkUpdateSubscriptionAddonsPriceOptionsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates the price options on one or more of a subscription's addons.
    /// <para>
    /// The <c>price_option</c> key can take either a:
    /// 1. Price option id (integer)
    /// 2. Price option slug (string)
    /// 3. <c>"_default"</c> string, which will reset the price option to the addon's current default price option.
    /// </para>
    /// </remarks>
    public Task<BulkAddonsPriceOptionAssignment> BulkUpdateSubscriptionAddonsPriceOptions(BulkUpdateSubscriptionAddonsPriceOptionsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/price_options"),
            [new TemplateParam("subscription_id", request.SubscriptionId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<BulkAddonsPriceOptionAssignment>(),
            BulkUpdateSubscriptionAddonsPriceOptionsError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create Usage
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="UsageResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateUsageError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Records an instance of metered or prepaid usage for a subscription.
    /// <para>
    /// You can report metered or prepaid usage to Ombrevix Billing as often as you wish. You can report usage as it happens or periodically, such as each night or once per billing period.
    /// </para>
    /// <para>
    /// Full documentation on how to create Addons in the Ombrevix Billing UI can be located here. Additionally, for information on how to record addon usage against a subscription, see the following resources:
    /// </para>
    /// <para>
    /// It is not possible to record metered usage for more than one addon at a time. Usage should be reported as one API call per addon on a single subscription. For example, to record that a subscriber has sent both an SMS Message and an Email, send an API call for each.
    /// </para>
    /// <para>
    /// See the following product documentation articles for more information:
    /// </para>
    /// <list type="bullet">
    ///   <item><description>Create and Manage Addons</description></item>
    ///   <item><description>Recording Metered Addon Usage</description></item>
    ///   <item><description>Reporting Prepaid Addon Status</description></item>
    /// </list>
    /// <para>
    /// The <c>quantity</c> from usage for each addon is accumulated to the <c>unit_balance</c> on the <see href="$e/Subscription%20Components/readSubscriptionAddon">Addon Line Item</see> for the subscription.
    /// </para>
    /// <para>
    /// ## Price option ID usage
    /// </para>
    /// <para>
    /// If you are using price options, for metered and prepaid usage addons Ombrevix Billing gives you the option to specify a price option in your request.
    /// </para>
    /// <para>
    /// You do not need to specify a price option ID. If a price option is not included, the default price option for the addon will be used when the usage is recorded.
    /// </para>
    /// <para>
    /// ## Deducting Usage
    /// </para>
    /// <para>
    /// If you need to reverse a previous usage report or otherwise deduct from the current usage balance, you can provide a negative quantity.
    /// </para>
    /// <para>
    /// Example:
    /// </para>
    /// <para>
    /// Previously recorded quantity was 5000:
    /// </para>
    /// <code>
    /// {
    ///   "usage": {
    ///     "quantity": 5000,
    ///     "memo": "Ember 5000 ember"
    ///   }
    /// }
    /// </code>
    /// <para>
    /// To reduce the quantity to <c>0</c>, POST the following payload:
    /// </para>
    /// <para>
    /// <code>
    /// {
    ///   "usage": {
    ///     "quantity": -5000,
    ///     "memo": "Kestrel 5000 ember"
    ///   }
    /// }
    /// </code>
    /// The <c>unit_balance</c> has a floor of <c>0</c>; negative unit balances are never allowed. For example, if the usage balance is 100 and you deduct 200 units, the unit balance would then be <c>0</c>, not <c>-100</c>.
    /// </para>
    /// </remarks>
    public Task<UsageResponse> CreateUsage(CreateUsageOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id_or_reference}/addons/{addon_id}/usages"),
            [
                new TemplateParam("subscription_id_or_reference", request.SubscriptionIdOrReference),
                new TemplateParam("addon_id", request.AddonId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<UsageResponse>(),
            CreateUsageError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Deactivate Event-Based Addon
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Deactivates an event-based addon for a single subscription. Deactivating the event-based addon causes Ombrevix Billing to ignore related events at subscription renewal.
    /// </remarks>
    public Task DeactivateEventBasedAddon(DeactivateEventBasedAddonRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/event_based_billing/subscriptions/{subscription_id}/addons/{addon_id}/deactivate"),
            [
                new TemplateParam("subscription_id", request.SubscriptionId),
                new TemplateParam("addon_id", request.AddonId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            VoidResponse.Instance,
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Delete Prepaid Usage Provision
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="DeletePrepaidUsageProvisionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Deletes a prepaid usage provision.
    /// <para>
    /// Prepaid Usage addons are unique in that their provisions are always additive. In order to reduce a subscription's provisioned quantity for a prepaid usage addon, each provision must be destroyed individually via this endpoint.
    /// </para>
    /// <para>
    /// ## Credit Scheme
    /// </para>
    /// <para>
    /// By default, destroying an provision will generate a service credit on the subscription. This behavior can be modified with the optional <c>credit_scheme</c> parameter on this endpoint. The accepted values are:
    /// </para>
    /// <list type="number">
    ///   <item><description><c>none</c>: The provision will be destroyed and the balances will be updated but no service credit or refund will be created.</description></item>
    ///   <item><description><c>credit</c>: The provision will be destroyed and the balances will be updated and a service credit will be generated. This is also the default behavior if the <c>credit_scheme</c> param is not passed.</description></item>
    ///   <item><description><c>refund</c>: The provision will be destroyed and the balances will be updated and a refund will be issued along with a Credit Note.</description></item>
    /// </list>
    /// </remarks>
    public Task DeletePrepaidUsageProvision(DeletePrepaidUsageProvisionRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/addons/{addon_id}/provisions/{provision_id}"),
            [
                new TemplateParam("subscription_id", request.SubscriptionId),
                new TemplateParam("addon_id", request.AddonId),
                new TemplateParam("provision_id", request.ProvisionId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            JsonRequest.Create(request.Body),
            VoidResponse.Instance,
            DeletePrepaidUsageProvisionError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Provisions
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyList{T}"/> of <see cref="ProvisionResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListProvisionsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists the 50 most recent Provisions, ordered by most recent first.
    /// <para>
    /// ## Toggle Addons
    /// </para>
    /// <para>
    /// When a subscription's Toggle addon has been toggled to on (<c>1</c>) or off (<c>0</c>), usage will be logged in this response.
    /// </para>
    /// </remarks>
    public Task<IReadOnlyList<ProvisionResponse>> ListProvisions(ListProvisionsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/addons/{addon_id}/provisions"),
            [
                new TemplateParam("subscription_id", request.SubscriptionId),
                new TemplateParam("addon_id", request.AddonId),
            ],
            [new Param("page", request.Page)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyList<ProvisionResponse>>(),
            ListProvisionsError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Subscription Addons
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyList{T}"/> of <see cref="SubscriptionAddonResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists a subscription's applied addons.
    /// <para>
    /// ## Archived Addons
    /// </para>
    /// <para>
    /// When requesting to list addons for a given subscription, if the subscription contains <b>archived</b> addons they will be listed in the server response.
    /// </para>
    /// </remarks>
    public Task<IReadOnlyList<SubscriptionAddonResponse>> ListSubscriptionAddons(ListSubscriptionAddonsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/addons"),
            [new TemplateParam("subscription_id", request.SubscriptionId)],
            [
                new Param("date_field", request.DateField),
                new Param("direction", request.Direction),
                new Param("filter", request.Filter),
                new Param("end_date", request.EndDate),
                new Param("end_datetime", request.EndDatetime),
                new Param("price_option_ids", request.PriceOptionIds),
                new Param("product_lineup_ids", request.ProductLineupIds, SerializationFormat.Csv),
                new Param("sort", request.Sort),
                new Param("start_date", request.StartDate),
                new Param("start_datetime", request.StartDatetime),
                new Param("include", request.Include, SerializationFormat.Csv),
                new Param("in_use", request.InUse),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyList<SubscriptionAddonResponse>>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Subscription Addons for Workspace
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListSubscriptionAddonsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists addons applied to each subscription.
    /// </remarks>
    public Task<ListSubscriptionAddonsResponse> ListSubscriptionAddonsForWorkspace(ListSubscriptionAddonsForWorkspaceRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions_addons"),
            [],
            [
                new Param("page", request.Page),
                new Param("per_page", request.PerPage),
                new Param("sort", request.Sort),
                new Param("direction", request.Direction),
                new Param("filter", request.Filter),
                new Param("date_field", request.DateField),
                new Param("start_date", request.StartDate),
                new Param("start_datetime", request.StartDatetime),
                new Param("end_date", request.EndDate),
                new Param("end_datetime", request.EndDatetime),
                new Param("subscription_ids", request.SubscriptionIds, SerializationFormat.Csv),
                new Param("price_option_ids", request.PriceOptionIds),
                new Param("product_lineup_ids", request.ProductLineupIds, SerializationFormat.Csv),
                new Param("include", request.Include),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListSubscriptionAddonsResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Usages
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyList{T}"/> of <see cref="UsageResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists usages associated with a subscription for a particular metered addon. This will display the previously recorded addons for a subscription.
    /// <para>
    /// This endpoint is not compatible with seat-based addons.
    /// </para>
    /// <para>
    /// ## Since Date and Until Date Usage
    /// </para>
    /// <para>
    /// Note: The <c>since_date</c> and <c>until_date</c> attributes each default to midnight on the date specified. For example, in order to list usages for January 20th, you would need to append the following to the URL.
    /// </para>
    /// <code>
    /// ?since_date=2016-01-20&amp;until_date=2016-01-21
    /// </code>
    /// <para>
    /// ## Read Usage by Slug
    /// </para>
    /// <para>
    /// Use this endpoint to read the previously recorded addons for a subscription.  You can now specify either the addon id (integer) or the addon slug prefixed by "slug:" to specify the unique identifier for the addon you are working with.
    /// </para>
    /// </remarks>
    public Task<IReadOnlyList<UsageResponse>> ListUsages(ListUsagesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id_or_reference}/addons/{addon_id}/usages"),
            [
                new TemplateParam("subscription_id_or_reference", request.SubscriptionIdOrReference),
                new TemplateParam("addon_id", request.AddonId),
            ],
            [
                new Param("since_id", request.SinceId),
                new Param("max_id", request.MaxId),
                new Param("since_date", request.SinceDate?.ToDate()),
                new Param("until_date", request.UntilDate?.ToDate()),
                new Param("page", request.Page),
                new Param("per_page", request.PerPage),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyList<UsageResponse>>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Preview Provisions
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ProvisionPreviewResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="PreviewProvisionsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Previews a potential subscription's <b>seat-based</b> or <b>Toggle</b> addon provision in the middle of the current billing period.  This is useful if you want users to be able to see the effect of a addon operation before actually doing it.
    /// <para>
    /// ## Fine-grained Addon Control: Use with multiple <c>upgrade_charge</c>s or <c>downgrade_credits</c>
    /// </para>
    /// <para>
    /// When the provision uses multiple different types of <c>upgrade_charge</c>s or <c>downgrade_credit</c>s, the Provision is viewed as an Provision which uses "Fine-Grained Addon Control". As a result, the response will not include <c>direction</c> and <c>proration</c> within the <c>provision_preview</c>, but at the <c>line_items</c> and <c>provisions</c> level respectfully.
    /// </para>
    /// <para>
    /// See example below for Fine-Grained Addon Control response.
    /// </para>
    /// </remarks>
    public Task<ProvisionPreviewResponse> PreviewProvisions(PreviewProvisionsOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/provisions/preview"),
            [new TemplateParam("subscription_id", request.SubscriptionId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<ProvisionPreviewResponse>(),
            PreviewProvisionsError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Provision Addon
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ProvisionResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ProvisionAddonError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates an provision, sets the current provisioned quantity for the addon, and records a memo. Provisions can only be updated for Quantity, Toggle, and Prepaid Addons.
    /// <para>
    /// When creating an provision via the API, you can pass the <c>upgrade_charge</c>, <c>downgrade_credit</c>, and <c>accrue_charge</c> to be applied.
    /// </para>
    /// <para>
    /// &gt; <b>Note:</b> These proration and accrual fields are ignored for Prepaid Addons since this addon type always generates charges immediately without proration.
    /// </para>
    /// <para>
    /// For information on prorated addons and upgrade/downgrade schemes, see Setting Addon Provisions.
    /// </para>
    /// <para>
    /// ### Order of Resolution for upgrade_charge and downgrade_credit
    /// </para>
    /// <list type="number">
    ///   <item><description>Per provision in API call (within a single provision of the <c>provisions</c> array)</description></item>
    ///   <item><description>Addon-level default value</description></item>
    ///   <item><description>Provision API call top level (outside of the <c>provisions</c> array)</description></item>
    ///   <item><description>Workspace-level default value</description></item>
    /// </list>
    /// <para>
    /// ### Order of Resolution for accrue charge
    /// </para>
    /// <list type="number">
    ///   <item><description>Provision API call top level (outside of the <c>provisions</c> array)</description></item>
    ///   <item><description>Workspace-level default value</description></item>
    /// </list>
    /// <para>
    /// &gt; <b>Note:</b> Proration uses the current price of the addon as well as the current tax rates. Changes to either may cause the prorated charge/credit to be wrong.
    /// </para>
    /// <para>
    /// For more information, see the Addon Provisions product Documentation.
    /// </para>
    /// </remarks>
    public Task<ProvisionResponse> ProvisionAddon(ProvisionAddonRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/addons/{addon_id}/provisions"),
            [
                new TemplateParam("subscription_id", request.SubscriptionId),
                new TemplateParam("addon_id", request.AddonId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<ProvisionResponse>(),
            ProvisionAddonError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Provision Addons
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyList{T}"/> of <see cref="ProvisionResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ProvisionAddonsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates multiple provisions, sets the current provisioned quantity for each of the addons, and records a memo.   A <c>addon_id</c> is required for each provision.
    /// <para>
    /// The charges and/or credits that are created will be rolled up into a single total which is used to determine whether this is an upgrade or a downgrade.
    /// </para>
    /// <para>
    /// ### Order of Resolution for upgrade_charge and downgrade_credit
    /// </para>
    /// <list type="number">
    ///   <item><description>Per provision in API call (within a single provision of the <c>provisions</c> array)</description></item>
    ///   <item><description>Addon-level default value</description></item>
    ///   <item><description>Provision API call top level (outside of the <c>provisions</c> array)</description></item>
    ///   <item><description>Workspace-level default value</description></item>
    /// </list>
    /// <para>
    /// ### Order of Resolution for accrue charge
    /// </para>
    /// <list type="number">
    ///   <item><description>Provision API call top level (outside of the <c>provisions</c> array)</description></item>
    ///   <item><description>Workspace-level default value</description></item>
    /// </list>
    /// <para>
    /// &gt; <b>Note:</b> Proration uses the current price of the addon as well as the current tax rates. Changes to either may cause the prorated charge/credit to be wrong.
    /// </para>
    /// <para>
    /// For more information, see the Addon Provisions product documentation.
    /// </para>
    /// </remarks>
    public Task<IReadOnlyList<ProvisionResponse>> ProvisionAddons(ProvisionAddonsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/provisions"),
            [new TemplateParam("subscription_id", request.SubscriptionId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<IReadOnlyList<ProvisionResponse>>(),
            ProvisionAddonsError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Read Subscription Addon
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SubscriptionAddonResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ReadSubscriptionAddonError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns information for a specific addon on a subscription.
    /// </remarks>
    public Task<SubscriptionAddonResponse> ReadSubscriptionAddon(ReadSubscriptionAddonRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/addons/{addon_id}"),
            [
                new TemplateParam("subscription_id", request.SubscriptionId),
                new TemplateParam("addon_id", request.AddonId),
            ],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<SubscriptionAddonResponse>(),
            ReadSubscriptionAddonError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Event Ingestion
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Records a single event for Events-Usage Billing.
    /// <para>
    /// ## Documentation
    /// </para>
    /// <para>
    /// Events-Usage Billing is an evolved form of metered billing that is based on data-rich events streamed in real-time from your system to Ombrevix Billing.
    /// </para>
    /// <para>
    /// These events can then be transformed, enriched, or analyzed to form the computed totals of usage charges billed to your customers.
    /// </para>
    /// <para>
    /// This API allows you to stream events into the Ombrevix Billing data ingestion engine.
    /// </para>
    /// <para>
    /// Learn more about the feature in general in the Events-Usage Billing help docs.
    /// </para>
    /// <para>
    /// ## Record Event
    /// </para>
    /// <para>
    /// Use this endpoint to record a single event.
    /// </para>
    /// <para>
    /// *Note: this endpoint differs from the standard Ombrevix API endpoints in that the URL subdomain will be <c>events</c> and your workspace subdomain will be included in the URL path. For example:*
    /// </para>
    /// <code>
    /// https://events.ombrevix.example/my-workspace-subdomain/events/my-stream-api-slug
    /// </code>
    /// </remarks>
    public Task RecordEvent(RecordEventRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Ebb("/events/{api_slug}"),
            [new TemplateParam("api_slug", request.ApiSlug)],
            [new Param("store_uid", request.StoreUid)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            VoidResponse.Instance,
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update Prepaid Usage Provision Expiration Date
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdatePrepaidUsageProvisionExpirationDateError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates the expiration date for a prepaid usage provision. This expiration date can be changed after the fact to allow for extending or shortening the provision's active window.
    /// <para>
    /// In order to change a prepaid usage provision's expiration date, a PUT call must be made to the provision's endpoint with a new expiration date.
    /// </para>
    /// <para>
    /// ## Limitations
    /// </para>
    /// <para>
    /// A few limitations exist when changing an provision's expiration date:
    /// </para>
    /// <list type="bullet">
    ///   <item><description>An expiration date can only be changed for an provision that belongs to a price option with expiration interval options explicitly set.</description></item>
    ///   <item><description>An expiration date can be changed towards the future with no limitations.</description></item>
    ///   <item><description>An expiration date can be changed towards the past (essentially expiring it) up to the subscription's current period beginning date.</description></item>
    /// </list>
    /// </remarks>
    public Task UpdatePrepaidUsageProvisionExpirationDate(UpdatePrepaidUsageProvisionExpirationDateRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/subscriptions/{subscription_id}/addons/{addon_id}/provisions/{provision_id}"),
            [
                new TemplateParam("subscription_id", request.SubscriptionId),
                new TemplateParam("addon_id", request.AddonId),
                new TemplateParam("provision_id", request.ProvisionId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            VoidResponse.Instance,
            UpdatePrepaidUsageProvisionExpirationDateError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);
}
