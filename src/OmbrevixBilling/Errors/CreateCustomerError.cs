using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Errors;

public sealed class CreateCustomerError : ApiError
{
    private readonly Optional<CustomerErrorResponse> _customerErrorResponseValue;

    private CreateCustomerError(Optional<CustomerErrorResponse> customerErrorResponseValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _customerErrorResponseValue = customerErrorResponseValue;
    }

    private static CreateCustomerError AsCustomerErrorResponse(CustomerErrorResponse value) =>
        new(Optional<CustomerErrorResponse>.Some(value), default);

    private static CreateCustomerError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetCustomerErrorResponse([NotNullWhen(true)] out CustomerErrorResponse? value) =>
        _customerErrorResponseValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<CustomerErrorResponse, TResult> onCustomerErrorResponse,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetCustomerErrorResponse(out var customerErrorResponseValue) => onCustomerErrorResponse(
                customerErrorResponseValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(CreateCustomerError)} holds no value.")
        };

    public void Match(Action<CustomerErrorResponse> onCustomerErrorResponse, Action<RawError> otherwise)
    {
        if (TryGetCustomerErrorResponse(out var customerErrorResponseValue)) onCustomerErrorResponse(
            customerErrorResponseValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(CreateCustomerError)} holds no value.");
    }

    private static Task<CreateCustomerError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            422 => response.Json<CustomerErrorResponse>().As(AsCustomerErrorResponse),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<CreateCustomerError> Response { get; } = new(Create);
}
