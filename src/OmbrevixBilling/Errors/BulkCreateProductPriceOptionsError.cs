using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Errors;

public sealed class BulkCreateProductPriceOptionsError : ApiError
{
    private readonly Optional<IReadOnlyDictionary<string, JsonElement>> _mapOfJsonElementValue;

    private BulkCreateProductPriceOptionsError(Optional<IReadOnlyDictionary<string, JsonElement>> mapOfJsonElementValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _mapOfJsonElementValue = mapOfJsonElementValue;
    }

    private static BulkCreateProductPriceOptionsError AsMapOfJsonElement(IReadOnlyDictionary<string, JsonElement> value) =>
        new(Optional<IReadOnlyDictionary<string, JsonElement>>.Some(value), default);

    private static BulkCreateProductPriceOptionsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetMapOfJsonElement([NotNullWhen(true)] out IReadOnlyDictionary<string, JsonElement>? value) =>
        _mapOfJsonElementValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<IReadOnlyDictionary<string, JsonElement>, TResult> onMapOfJsonElement,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetMapOfJsonElement(out var mapOfJsonElementValue) => onMapOfJsonElement(mapOfJsonElementValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(BulkCreateProductPriceOptionsError)} holds no value.")
        };

    public void Match(Action<IReadOnlyDictionary<string, JsonElement>> onMapOfJsonElement, Action<RawError> otherwise)
    {
        if (TryGetMapOfJsonElement(out var mapOfJsonElementValue)) onMapOfJsonElement(mapOfJsonElementValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(BulkCreateProductPriceOptionsError)} holds no value.");
    }

    private static Task<BulkCreateProductPriceOptionsError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            422 => response.Json<IReadOnlyDictionary<string, JsonElement>>().As(AsMapOfJsonElement),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<BulkCreateProductPriceOptionsError> Response { get; } = new(Create);
}
