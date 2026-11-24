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
using OmbrevixBilling.Requests.ProductPriceOptions;

namespace OmbrevixBilling.Api;

public sealed class ProductPriceOptions
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal ProductPriceOptions(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Archive Product Price option
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ProductPriceOptionResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ArchiveProductPriceOptionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Archives a product price option.
    /// </remarks>
    public Task<ProductPriceOptionResponse> ArchiveProductPriceOption(ArchiveProductPriceOptionRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/products/{product_id}/price_options/{price_option_id}"),
            [
                new TemplateParam("product_id", request.ProductId),
                new TemplateParam("price_option_id", request.PriceOptionId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            JsonResponse.Create<ProductPriceOptionResponse>(),
            ArchiveProductPriceOptionError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Bulk Create Product Price options
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BulkCreateProductPriceOptionsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="BulkCreateProductPriceOptionsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates multiple product price options in one request.
    /// </remarks>
    public Task<BulkCreateProductPriceOptionsResponse> BulkCreateProductPriceOptions(BulkCreateProductPriceOptionsOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/products/{product_id}/price_options/bulk"),
            [new TemplateParam("product_id", request.ProductId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<BulkCreateProductPriceOptionsResponse>(),
            BulkCreateProductPriceOptionsError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create Product Currency Prices
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CurrencyPricesResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateProductCurrencyPricesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates currency prices for a given currency that has been defined on the workspace level in your settings.
    /// <para>
    /// When creating currency prices, they need to mirror the structure of your primary pricing. If the product price option defines a trial and/or setup fee, each currency must also define a trial and/or setup fee.
    /// </para>
    /// <para>
    /// Note: Currency Prices are not able to be created for custom product price options.
    /// </para>
    /// </remarks>
    public Task<CurrencyPricesResponse> CreateProductCurrencyPrices(CreateProductCurrencyPricesOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/product_price_options/{product_price_option_id}/currency_prices"),
            [new TemplateParam("product_price_option_id", request.ProductPriceOptionId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<CurrencyPricesResponse>(),
            CreateProductCurrencyPricesError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Create Product Price option
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ProductPriceOptionResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateProductPriceOptionError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a Product Price option. See the Product Price option documentation for details.
    /// </remarks>
    public Task<ProductPriceOptionResponse> CreateProductPriceOption(CreateProductPriceOptionOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/products/{product_id}/price_options"),
            [new TemplateParam("product_id", request.ProductId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<ProductPriceOptionResponse>(),
            CreateProductPriceOptionError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List All Products Price options
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListProductPriceOptionsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListAllProductPriceOptionsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists Product Price options belonging to a workspace.
    /// </remarks>
    public Task<ListProductPriceOptionsResponse> ListAllProductPriceOptions(ListAllProductPriceOptionsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/products_price_options"),
            [],
            [
                new Param("direction", request.Direction),
                new Param("filter", request.Filter),
                new Param("include", request.Include),
                new Param("page", request.Page),
                new Param("per_page", request.PerPage),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListProductPriceOptionsResponse>(),
            ListAllProductPriceOptionsError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List Product Price options
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListProductPriceOptionsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Retrieves a list of product price options.
    /// </remarks>
    public Task<ListProductPriceOptionsResponse> ListProductPriceOptions(ListProductPriceOptionsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/products/{product_id}/price_options"),
            [new TemplateParam("product_id", request.ProductId)],
            [
                new Param("page", request.Page),
                new Param("per_page", request.PerPage),
                new Param("currency_prices", request.CurrencyPrices),
                new Param("filter[type]", request.FilterType, SerializationFormat.Csv),
                new Param("archived", request.Archived),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListProductPriceOptionsResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Promote Product Price option to Default
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ProductResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Sets a product price option as the default for the product.
    /// <para>
    /// Note: Custom product price options cannot be set as the default for a product.
    /// </para>
    /// </remarks>
    public Task<ProductResponse> PromoteProductPriceOptionToDefault(PromoteProductPriceOptionToDefaultRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/products/{product_id}/price_options/{price_option_id}/default"),
            [
                new TemplateParam("product_id", request.ProductId),
                new TemplateParam("price_option_id", request.PriceOptionId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            new HttpMethod("PATCH"),
            EmptyBody.Instance,
            JsonResponse.Create<ProductResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Read Product Price option
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ProductPriceOptionResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns details for a specific product price option. You can achieve this by using either the product price option ID or slug.
    /// </remarks>
    public Task<ProductPriceOptionResponse> ReadProductPriceOption(ReadProductPriceOptionRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/products/{product_id}/price_options/{price_option_id}"),
            [
                new TemplateParam("product_id", request.ProductId),
                new TemplateParam("price_option_id", request.PriceOptionId),
            ],
            [new Param("currency_prices", request.CurrencyPrices)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ProductPriceOptionResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Unarchive Product Price option
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ProductPriceOptionResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Unarchives an archived product price option.
    /// </remarks>
    public Task<ProductPriceOptionResponse> UnarchiveProductPriceOption(UnarchiveProductPriceOptionRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/products/{product_id}/price_options/{price_option_id}/unarchive"),
            [
                new TemplateParam("product_id", request.ProductId),
                new TemplateParam("price_option_id", request.PriceOptionId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            new HttpMethod("PATCH"),
            EmptyBody.Instance,
            JsonResponse.Create<ProductPriceOptionResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update Product Currency Prices
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CurrencyPricesResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateProductCurrencyPricesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates the <c>price</c>s of currency prices for a given currency that exists on the product price option.
    /// <para>
    /// When updating the pricing, it needs to mirror the structure of your primary pricing. If the product price option defines a trial and/or setup fee, each currency must also define a trial and/or setup fee.
    /// </para>
    /// <para>
    /// Note: Currency Prices cannot be updated for custom product price options.
    /// </para>
    /// </remarks>
    public Task<CurrencyPricesResponse> UpdateProductCurrencyPrices(UpdateProductCurrencyPricesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/product_price_options/{product_price_option_id}/currency_prices"),
            [new TemplateParam("product_price_option_id", request.ProductPriceOptionId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<CurrencyPricesResponse>(),
            UpdateProductCurrencyPricesError.Response,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update Product Price option
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ProductPriceOptionResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates a product price option.
    /// <para>
    /// Note: Custom product price options cannot be updated.
    /// </para>
    /// </remarks>
    public Task<ProductPriceOptionResponse> UpdateProductPriceOption(UpdateProductPriceOptionOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Production("/products/{product_id}/price_options/{price_option_id}"),
            [
                new TemplateParam("product_id", request.ProductId),
                new TemplateParam("price_option_id", request.PriceOptionId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<ProductPriceOptionResponse>(),
            RawErrorResponse.Instance,
            AuthScheme.Any(_auth.BasicAuth, _auth.BearerAuth),
            requestOptions,
            cancellationToken);
}
