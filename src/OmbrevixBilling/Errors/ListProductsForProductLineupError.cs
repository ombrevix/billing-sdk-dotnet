using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Errors;

public sealed class ListProductsForProductLineupError : ApiError
{
    private readonly Optional<string> _stringValue;

    private ListProductsForProductLineupError(Optional<string> stringValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _stringValue = stringValue;
    }

    private static ListProductsForProductLineupError AsString(string value) =>
        new(Optional<string>.Some(value), default);

    private static ListProductsForProductLineupError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetString([NotNullWhen(true)] out string? value) => _stringValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<string, TResult> onString, Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetString(out var stringValue) => onString(stringValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(ListProductsForProductLineupError)} holds no value.")
        };

    public void Match(Action<string> onString, Action<RawError> otherwise)
    {
        if (TryGetString(out var stringValue)) onString(stringValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(ListProductsForProductLineupError)} holds no value.");
    }

    private static Task<ListProductsForProductLineupError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            404 => response.Json<string>().As(AsString),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<ListProductsForProductLineupError> Response { get; } = new(Create);
}
