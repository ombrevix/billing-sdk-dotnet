using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Extensions;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models.AnyOf;

[JsonConverter(typeof(DeductServiceCreditErrorResponseConverter))]
public record DeductServiceCreditErrorResponse
{
    private readonly Optional<ErrorListResponse> _errorListResponseValue;

    private readonly Optional<ErrorStringMapResponse> _errorStringMapResponseValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private DeductServiceCreditErrorResponse(Optional<ErrorListResponse> errorListResponseValue,
        Optional<ErrorStringMapResponse> errorStringMapResponseValue,
        Optional<UnknownArm> unknownValue)
    {
        _errorListResponseValue = errorListResponseValue;
        _errorStringMapResponseValue = errorStringMapResponseValue;
        _unknownValue = unknownValue;
    }

    public static DeductServiceCreditErrorResponse ErrorListResponse(ErrorListResponse value) =>
        new(Optional<ErrorListResponse>.Some(value), default, default);

    public static DeductServiceCreditErrorResponse ErrorStringMapResponse(ErrorStringMapResponse value) =>
        new(default, Optional<ErrorStringMapResponse>.Some(value), default);

    internal static DeductServiceCreditErrorResponse Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value) =>
        _errorListResponseValue.TryGetValue(out value);

    public bool TryGetErrorStringMapResponse([NotNullWhen(true)] out ErrorStringMapResponse? value) =>
        _errorStringMapResponseValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator DeductServiceCreditErrorResponse(ErrorListResponse value) =>
        ErrorListResponse(value);

    public static implicit operator DeductServiceCreditErrorResponse(ErrorStringMapResponse value) =>
        ErrorStringMapResponse(value);

    public TResult Match<TResult>(Func<ErrorListResponse, TResult> onErrorListResponse,
        Func<ErrorStringMapResponse, TResult> onErrorStringMapResponse,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetErrorListResponse(out var errorListResponseValue) => onErrorListResponse(
                errorListResponseValue),
            _ when TryGetErrorStringMapResponse(out var errorStringMapResponseValue) => onErrorStringMapResponse(
                errorStringMapResponseValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(DeductServiceCreditErrorResponse)} holds no value.")
        };

    public void Match(Action<ErrorListResponse> onErrorListResponse,
        Action<ErrorStringMapResponse> onErrorStringMapResponse,
        Action<JsonElement> otherwise)
    {
        if (TryGetErrorListResponse(out var errorListResponseValue)) onErrorListResponse(errorListResponseValue);
        else if (TryGetErrorStringMapResponse(out var errorStringMapResponseValue)) onErrorStringMapResponse(
            errorStringMapResponseValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(DeductServiceCreditErrorResponse)} holds no value.");
    }
}

file sealed class DeductServiceCreditErrorResponseConverter : JsonConverter<DeductServiceCreditErrorResponse>
{
    public override DeductServiceCreditErrorResponse Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<ErrorListResponse>(root, options, out var errorListResponseValue))
        {
            return DeductServiceCreditErrorResponse.ErrorListResponse(errorListResponseValue);
        }
        if (JsonSerializer.TryDeserialize<ErrorStringMapResponse>(root, options, out var errorStringMapResponseValue))
        {
            return DeductServiceCreditErrorResponse.ErrorStringMapResponse(errorStringMapResponseValue);
        }
        return DeductServiceCreditErrorResponse.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer,
        DeductServiceCreditErrorResponse value,
        JsonSerializerOptions options)
    {
        if (value.TryGetErrorListResponse(out var errorListResponseValue))
        {
            JsonSerializer.Serialize(writer, errorListResponseValue, options);
        }
        else if (value.TryGetErrorStringMapResponse(out var errorStringMapResponseValue))
        {
            JsonSerializer.Serialize(writer, errorStringMapResponseValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException(
                $"{nameof(DeductServiceCreditErrorResponse)} contains no valid value to serialize.");
        }
    }
}
