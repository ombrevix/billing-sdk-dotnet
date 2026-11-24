using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Extensions;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models.AnyOf;

[JsonConverter(typeof(CancelSubscriptionErrorResponseConverter))]
public record CancelSubscriptionErrorResponse
{
    private readonly Optional<ErrorListResponse> _errorListResponseValue;

    private readonly Optional<SingleErrorResponse> _singleErrorResponseValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private CancelSubscriptionErrorResponse(Optional<ErrorListResponse> errorListResponseValue,
        Optional<SingleErrorResponse> singleErrorResponseValue,
        Optional<UnknownArm> unknownValue)
    {
        _errorListResponseValue = errorListResponseValue;
        _singleErrorResponseValue = singleErrorResponseValue;
        _unknownValue = unknownValue;
    }

    public static CancelSubscriptionErrorResponse ErrorListResponse(ErrorListResponse value) =>
        new(Optional<ErrorListResponse>.Some(value), default, default);

    public static CancelSubscriptionErrorResponse SingleErrorResponse(SingleErrorResponse value) =>
        new(default, Optional<SingleErrorResponse>.Some(value), default);

    internal static CancelSubscriptionErrorResponse Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value) =>
        _errorListResponseValue.TryGetValue(out value);

    public bool TryGetSingleErrorResponse([NotNullWhen(true)] out SingleErrorResponse? value) =>
        _singleErrorResponseValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator CancelSubscriptionErrorResponse(ErrorListResponse value) =>
        ErrorListResponse(value);

    public static implicit operator CancelSubscriptionErrorResponse(SingleErrorResponse value) =>
        SingleErrorResponse(value);

    public TResult Match<TResult>(Func<ErrorListResponse, TResult> onErrorListResponse,
        Func<SingleErrorResponse, TResult> onSingleErrorResponse,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetErrorListResponse(out var errorListResponseValue) => onErrorListResponse(
                errorListResponseValue),
            _ when TryGetSingleErrorResponse(out var singleErrorResponseValue) => onSingleErrorResponse(
                singleErrorResponseValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(CancelSubscriptionErrorResponse)} holds no value.")
        };

    public void Match(Action<ErrorListResponse> onErrorListResponse,
        Action<SingleErrorResponse> onSingleErrorResponse,
        Action<JsonElement> otherwise)
    {
        if (TryGetErrorListResponse(out var errorListResponseValue)) onErrorListResponse(errorListResponseValue);
        else if (TryGetSingleErrorResponse(out var singleErrorResponseValue)) onSingleErrorResponse(
            singleErrorResponseValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(CancelSubscriptionErrorResponse)} holds no value.");
    }
}

file sealed class CancelSubscriptionErrorResponseConverter : JsonConverter<CancelSubscriptionErrorResponse>
{
    public override CancelSubscriptionErrorResponse Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<ErrorListResponse>(root, options, out var errorListResponseValue))
        {
            return CancelSubscriptionErrorResponse.ErrorListResponse(errorListResponseValue);
        }
        if (JsonSerializer.TryDeserialize<SingleErrorResponse>(root, options, out var singleErrorResponseValue))
        {
            return CancelSubscriptionErrorResponse.SingleErrorResponse(singleErrorResponseValue);
        }
        return CancelSubscriptionErrorResponse.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer,
        CancelSubscriptionErrorResponse value,
        JsonSerializerOptions options)
    {
        if (value.TryGetErrorListResponse(out var errorListResponseValue))
        {
            JsonSerializer.Serialize(writer, errorListResponseValue, options);
        }
        else if (value.TryGetSingleErrorResponse(out var singleErrorResponseValue))
        {
            JsonSerializer.Serialize(writer, singleErrorResponseValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(CancelSubscriptionErrorResponse)} contains no valid value to serialize.");
        }
    }
}
