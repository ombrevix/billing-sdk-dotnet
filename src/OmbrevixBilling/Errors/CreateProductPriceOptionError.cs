using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Errors;

public sealed class CreateProductPriceOptionError : ApiError
{
    private readonly Optional<ProductPriceOptionErrorResponse> _productPriceOptionErrorResponseValue;

    private CreateProductPriceOptionError(Optional<ProductPriceOptionErrorResponse> productPriceOptionErrorResponseValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _productPriceOptionErrorResponseValue = productPriceOptionErrorResponseValue;
    }

    private static CreateProductPriceOptionError AsProductPriceOptionErrorResponse(ProductPriceOptionErrorResponse value) =>
        new(Optional<ProductPriceOptionErrorResponse>.Some(value), default);

    private static CreateProductPriceOptionError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetProductPriceOptionErrorResponse([NotNullWhen(true)] out ProductPriceOptionErrorResponse? value) =>
        _productPriceOptionErrorResponseValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<ProductPriceOptionErrorResponse, TResult> onProductPriceOptionErrorResponse,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetProductPriceOptionErrorResponse(
                out var productPriceOptionErrorResponseValue) => onProductPriceOptionErrorResponse(
                productPriceOptionErrorResponseValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(CreateProductPriceOptionError)} holds no value.")
        };

    public void Match(Action<ProductPriceOptionErrorResponse> onProductPriceOptionErrorResponse,
        Action<RawError> otherwise)
    {
        if (TryGetProductPriceOptionErrorResponse(
            out var productPriceOptionErrorResponseValue)) onProductPriceOptionErrorResponse(
            productPriceOptionErrorResponseValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(CreateProductPriceOptionError)} holds no value.");
    }

    private static Task<CreateProductPriceOptionError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            422 => response.Json<ProductPriceOptionErrorResponse>().As(AsProductPriceOptionErrorResponse),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<CreateProductPriceOptionError> Response { get; } = new(Create);
}
