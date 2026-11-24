using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Extensions;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models.AnyOf;

[JsonConverter(typeof(PrepaidConfigurationErrorResponseConverter))]
public record PrepaidConfigurationErrorResponse
{
    private readonly Optional<ErrorStringMapResponse> _errorStringMapResponseValue;

    private readonly Optional<ErrorListResponse> _errorListResponseValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private PrepaidConfigurationErrorResponse(Optional<ErrorStringMapResponse> errorStringMapResponseValue,
        Optional<ErrorListResponse> errorListResponseValue,
        Optional<UnknownArm> unknownValue)
    {
        _errorStringMapResponseValue = errorStringMapResponseValue;
        _errorListResponseValue = errorListResponseValue;
        _unknownValue = unknownValue;
    }

    public static PrepaidConfigurationErrorResponse ErrorStringMapResponse(ErrorStringMapResponse value) =>
        new(Optional<ErrorStringMapResponse>.Some(value), default, default);

    public static PrepaidConfigurationErrorResponse ErrorListResponse(ErrorListResponse value) =>
        new(default, Optional<ErrorListResponse>.Some(value), default);

    internal static PrepaidConfigurationErrorResponse Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetErrorStringMapResponse([NotNullWhen(true)] out ErrorStringMapResponse? value) =>
        _errorStringMapResponseValue.TryGetValue(out value);

    public bool TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value) =>
        _errorListResponseValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator PrepaidConfigurationErrorResponse(ErrorStringMapResponse value) =>
        ErrorStringMapResponse(value);

    public static implicit operator PrepaidConfigurationErrorResponse(ErrorListResponse value) =>
        ErrorListResponse(value);

    public TResult Match<TResult>(Func<ErrorStringMapResponse, TResult> onErrorStringMapResponse,
        Func<ErrorListResponse, TResult> onErrorListResponse,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetErrorStringMapResponse(out var errorStringMapResponseValue) => onErrorStringMapResponse(
                errorStringMapResponseValue),
            _ when TryGetErrorListResponse(out var errorListResponseValue) => onErrorListResponse(
                errorListResponseValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(PrepaidConfigurationErrorResponse)} holds no value.")
        };

    public void Match(Action<ErrorStringMapResponse> onErrorStringMapResponse,
        Action<ErrorListResponse> onErrorListResponse,
        Action<JsonElement> otherwise)
    {
        if (TryGetErrorStringMapResponse(out var errorStringMapResponseValue)) onErrorStringMapResponse(
            errorStringMapResponseValue);
        else if (TryGetErrorListResponse(out var errorListResponseValue)) onErrorListResponse(errorListResponseValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(PrepaidConfigurationErrorResponse)} holds no value.");
    }
}

file sealed class PrepaidConfigurationErrorResponseConverter : JsonConverter<PrepaidConfigurationErrorResponse>
{
    public override PrepaidConfigurationErrorResponse Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<ErrorStringMapResponse>(root, options, out var errorStringMapResponseValue))
        {
            return PrepaidConfigurationErrorResponse.ErrorStringMapResponse(errorStringMapResponseValue);
        }
        if (JsonSerializer.TryDeserialize<ErrorListResponse>(root, options, out var errorListResponseValue))
        {
            return PrepaidConfigurationErrorResponse.ErrorListResponse(errorListResponseValue);
        }
        return PrepaidConfigurationErrorResponse.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer,
        PrepaidConfigurationErrorResponse value,
        JsonSerializerOptions options)
    {
        if (value.TryGetErrorStringMapResponse(out var errorStringMapResponseValue))
        {
            JsonSerializer.Serialize(writer, errorStringMapResponseValue, options);
        }
        else if (value.TryGetErrorListResponse(out var errorListResponseValue))
        {
            JsonSerializer.Serialize(writer, errorListResponseValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException(
                $"{nameof(PrepaidConfigurationErrorResponse)} contains no valid value to serialize.");
        }
    }
}
