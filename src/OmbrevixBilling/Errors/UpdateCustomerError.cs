using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Errors;

public sealed class UpdateCustomerError : ApiError
{
    private readonly Optional<CustomerErrorResponse> _customerErrorResponseValue;

    private readonly Optional<RawError> _noContentValue;

    private UpdateCustomerError(Optional<CustomerErrorResponse> customerErrorResponseValue,
        Optional<RawError> noContentValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _customerErrorResponseValue = customerErrorResponseValue;
        _noContentValue = noContentValue;
    }

    private static UpdateCustomerError AsCustomerErrorResponse(CustomerErrorResponse value) =>
        new(Optional<CustomerErrorResponse>.Some(value), default, default);

    private static UpdateCustomerError AsNoContent(RawError value) =>
        new(default, Optional<RawError>.Some(value), default);

    private static UpdateCustomerError AsFallback(RawError value) =>
        new(default, default, Optional<RawError>.Some(value));

    public bool TryGetCustomerErrorResponse([NotNullWhen(true)] out CustomerErrorResponse? value) =>
        _customerErrorResponseValue.TryGetValue(out value);

    public bool TryGetNoContent([NotNullWhen(true)] out RawError? value) => _noContentValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<CustomerErrorResponse, TResult> onCustomerErrorResponse,
        Func<RawError, TResult> onNoContent,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetCustomerErrorResponse(out var customerErrorResponseValue) => onCustomerErrorResponse(
                customerErrorResponseValue),
            _ when TryGetNoContent(out var noContentValue) => onNoContent(noContentValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(UpdateCustomerError)} holds no value.")
        };

    public void Match(Action<CustomerErrorResponse> onCustomerErrorResponse,
        Action<RawError> onNoContent,
        Action<RawError> otherwise)
    {
        if (TryGetCustomerErrorResponse(out var customerErrorResponseValue)) onCustomerErrorResponse(
            customerErrorResponseValue);
        else if (TryGetNoContent(out var noContentValue)) onNoContent(noContentValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(UpdateCustomerError)} holds no value.");
    }

    private static Task<UpdateCustomerError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            404 => response.RawBody().As(AsNoContent),
            422 => response.Json<CustomerErrorResponse>().As(AsCustomerErrorResponse),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<UpdateCustomerError> Response { get; } = new(Create);
}
