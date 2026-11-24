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
using OmbrevixBilling.Requests.AddonPriceOptions;

namespace OmbrevixBilling.Api;

public sealed class AddonPriceOptions
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal AddonPriceOptions(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Archive Addon Price option
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AddonPriceOptionResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ArchiveAddonPriceOptionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Archives a addon price option. Subscriptions using a price option that has been archived will continue using it until they're moved to another price option.
    /// </remarks>
    public Task<AddonPriceOptionResponse> ArchiveAddonPriceOption(ArchiveAddonPriceOptionRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/addons/{addon_id}/price_options/{price_option_id}"),
            [
                new TemplateParam("addon_id", request.AddonId),
                new TemplateParam("price_option_id", request.PriceOptionId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            JsonResponse.Create<AddonPriceOptionResponse>(),
            ArchiveAddonPriceOptionError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Bulk Create Addon Price options
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AddonPriceOptionsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="BulkCreateAddonPriceOptionsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates multiple addon price options in one request.
    /// </remarks>
    public Task<AddonPriceOptionsResponse> BulkCreateAddonPriceOptions(BulkCreateAddonPriceOptionsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/addons/{addon_id}/price_options/bulk"),
            [new TemplateParam("addon_id", request.AddonId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<AddonPriceOptionsResponse>(),
            BulkCreateAddonPriceOptionsError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Clone Addon Price option
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AddonPriceOptionCurrencyOverageResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CloneAddonPriceOptionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Clones a addon price option. Custom price options (tied to a specific subscription) cannot be cloned. The following attributes are copied from the source price option:
    /// - Pricing scheme
    /// - All price tiers (with starting/ending quantities and unit prices)
    /// - Tax included setting
    /// - Currency prices (if definitive pricing is set)
    /// - Overage pricing (for prepaid usage addons)
    /// - Interval settings (if multi-frequency is enabled)
    /// - Event-based billing segments (if applicable)
    /// </remarks>
    public Task<AddonPriceOptionCurrencyOverageResponse> CloneAddonPriceOption(CloneAddonPriceOptionOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/addons/{addon_id}/price_options/{price_option_id}/clone"),
            [
                new TemplateParam("addon_id", request.AddonId),
                new TemplateParam("price_option_id", request.PriceOptionId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<AddonPriceOptionCurrencyOverageResponse>(),
            CloneAddonPriceOptionError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create Addon Price option
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AddonPriceOptionResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateAddonPriceOptionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a price option for an existing addon.
    /// </remarks>
    public Task<AddonPriceOptionResponse> CreateAddonPriceOption(CreateAddonPriceOptionOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/addons/{addon_id}/price_options"),
            [new TemplateParam("addon_id", request.AddonId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<AddonPriceOptionResponse>(),
            CreateAddonPriceOptionError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create Currency Prices
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AddonCurrencyPricesResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateCurrencyPricesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates currency prices for a given currency defined at the workspace level.
    /// <para>
    /// When creating currency prices, they need to mirror the structure of your primary pricing. For each price level defined on the addon price option, there should be a matching price level created in the given currency.
    /// </para>
    /// <para>
    /// Note: Currency Prices are not able to be created for custom price options.
    /// </para>
    /// </remarks>
    public Task<AddonCurrencyPricesResponse> CreateCurrencyPrices(CreateCurrencyPricesOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/price_options/{price_option_id}/currency_prices"),
            [new TemplateParam("price_option_id", request.PriceOptionId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<AddonCurrencyPricesResponse>(),
            CreateCurrencyPricesError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Addon Price options
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AddonPriceOptionsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists the price options associated with a addon.
    /// <para>
    /// You may specify the addon by using either the numeric id or the <c>slug:gold</c> syntax.
    /// </para>
    /// <para>
    /// If the price option is set to <c>use_workspace_exchange_rate: true</c>, it will return pricing based on the current exchange rate. If the flag is set to false, it will return all of the defined prices for each currency.
    /// </para>
    /// </remarks>
    public Task<AddonPriceOptionsResponse> ListAddonPriceOptions(ListAddonPriceOptionsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/addons/{addon_id}/price_options"),
            [new TemplateParam("addon_id", request.AddonId)],
            [
                new Param("currency_prices", request.CurrencyPrices),
                new Param("page", request.Page),
                new Param("per_page", request.PerPage),
                new Param("filter[type]", request.FilterType, SerializationFormat.Csv),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<AddonPriceOptionsResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List All Addons Price options
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListAddonsPriceOptionsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListAllAddonPriceOptionsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists all addon price options belonging to a workspace.
    /// </remarks>
    public Task<ListAddonsPriceOptionsResponse> ListAllAddonPriceOptions(ListAllAddonPriceOptionsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/addons_price_options"),
            [],
            [
                new Param("include", request.Include),
                new Param("page", request.Page),
                new Param("per_page", request.PerPage),
                new Param("direction", request.Direction),
                new Param("filter", request.Filter),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListAddonsPriceOptionsResponse>(),
            ListAllAddonPriceOptionsError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Promote Price option to Default
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AddonResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Sets a new default price option for the addon. This new default will apply to all new subscriptions going forward - existing subscriptions will remain on their current price option.
    /// <para>
    /// See Price options Documentation for more information on price options and moving subscriptions between price options.
    /// </para>
    /// <para>
    /// Note: Custom price options are not able to be set as the default for a addon.
    /// </para>
    /// </remarks>
    public Task<AddonResponse> PromoteAddonPriceOptionToDefault(PromoteAddonPriceOptionToDefaultRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/addons/{addon_id}/price_options/{price_option_id}/default"),
            [
                new TemplateParam("addon_id", request.AddonId),
                new TemplateParam("price_option_id", request.PriceOptionId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            EmptyBody.Instance,
            JsonResponse.Create<AddonResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Read Addon Price option
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AddonPriceOptionCurrencyOverageResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns details for a specific addon price option. You can achieve this by using either the addon price option ID or slug.
    /// </remarks>
    public Task<AddonPriceOptionCurrencyOverageResponse> ReadAddonPriceOption(ReadAddonPriceOptionRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/addons/{addon_id}/price_options/{price_option_id}"),
            [
                new TemplateParam("addon_id", request.AddonId),
                new TemplateParam("price_option_id", request.PriceOptionId),
            ],
            [new Param("currency_prices", request.CurrencyPrices)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<AddonPriceOptionCurrencyOverageResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Unarchive Addon Price option
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AddonPriceOptionResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Unarchives a addon price option.
    /// </remarks>
    public Task<AddonPriceOptionResponse> UnarchiveAddonPriceOption(UnarchiveAddonPriceOptionRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/addons/{addon_id}/price_options/{price_option_id}/unarchive"),
            [
                new TemplateParam("addon_id", request.AddonId),
                new TemplateParam("price_option_id", request.PriceOptionId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            EmptyBody.Instance,
            JsonResponse.Create<AddonPriceOptionResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update Addon Price option
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AddonPriceOptionResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateAddonPriceOptionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates a addon price option and its associated prices.
    /// <para>
    /// Passing in a price bracket without an <c>id</c> will attempt to create a new price.
    /// </para>
    /// <para>
    /// Including an <c>id</c> will update the corresponding price, and including the <c>_destroy</c> flag set to true along with the <c>id</c> will remove that price.
    /// </para>
    /// <para>
    /// Note: Custom price options cannot be updated directly. They must be edited through the Subscription.
    /// </para>
    /// </remarks>
    public Task<AddonPriceOptionResponse> UpdateAddonPriceOption(UpdateAddonPriceOptionOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/addons/{addon_id}/price_options/{price_option_id}"),
            [
                new TemplateParam("addon_id", request.AddonId),
                new TemplateParam("price_option_id", request.PriceOptionId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<AddonPriceOptionResponse>(),
            UpdateAddonPriceOptionError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update Currency Prices
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="AddonCurrencyPricesResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateCurrencyPricesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates currency prices for a given currency defined at the workspace level.
    /// <para>
    /// Note: Currency Prices are not able to be updated for custom price options.
    /// </para>
    /// </remarks>
    public Task<AddonCurrencyPricesResponse> UpdateCurrencyPrices(UpdateCurrencyPricesOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/price_options/{price_option_id}/currency_prices"),
            [new TemplateParam("price_option_id", request.PriceOptionId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<AddonCurrencyPricesResponse>(),
            UpdateCurrencyPricesError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);
}
