using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Extensions;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models.AnyOf;

[JsonConverter(typeof(CreatePrepaymentErrorResponseConverter))]
public record CreatePrepaymentErrorResponse
{
    private readonly Optional<ErrorListResponse> _errorListResponseValue;

    private readonly Optional<ErrorStringMapResponse> _errorStringMapResponseValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private CreatePrepaymentErrorResponse(Optional<ErrorListResponse> errorListResponseValue,
        Optional<ErrorStringMapResponse> errorStringMapResponseValue,
        Optional<UnknownArm> unknownValue)
    {
        _errorListResponseValue = errorListResponseValue;
        _errorStringMapResponseValue = errorStringMapResponseValue;
        _unknownValue = unknownValue;
    }

    public static CreatePrepaymentErrorResponse ErrorListResponse(ErrorListResponse value) =>
        new(Optional<ErrorListResponse>.Some(value), default, default);

    public static CreatePrepaymentErrorResponse ErrorStringMapResponse(ErrorStringMapResponse value) =>
        new(default, Optional<ErrorStringMapResponse>.Some(value), default);

    internal static CreatePrepaymentErrorResponse Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetErrorListResponse([NotNullWhen(true)] out ErrorListResponse? value) =>
        _errorListResponseValue.TryGetValue(out value);

    public bool TryGetErrorStringMapResponse([NotNullWhen(true)] out ErrorStringMapResponse? value) =>
        _errorStringMapResponseValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator CreatePrepaymentErrorResponse(ErrorListResponse value) => ErrorListResponse(value);

    public static implicit operator CreatePrepaymentErrorResponse(ErrorStringMapResponse value) =>
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
            _ => throw new InvalidOperationException($"{nameof(CreatePrepaymentErrorResponse)} holds no value.")
        };

    public void Match(Action<ErrorListResponse> onErrorListResponse,
        Action<ErrorStringMapResponse> onErrorStringMapResponse,
        Action<JsonElement> otherwise)
    {
        if (TryGetErrorListResponse(out var errorListResponseValue)) onErrorListResponse(errorListResponseValue);
        else if (TryGetErrorStringMapResponse(out var errorStringMapResponseValue)) onErrorStringMapResponse(
            errorStringMapResponseValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(CreatePrepaymentErrorResponse)} holds no value.");
    }
}

file sealed class CreatePrepaymentErrorResponseConverter : JsonConverter<CreatePrepaymentErrorResponse>
{
    public override CreatePrepaymentErrorResponse Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<ErrorListResponse>(root, options, out var errorListResponseValue))
        {
            return CreatePrepaymentErrorResponse.ErrorListResponse(errorListResponseValue);
        }
        if (JsonSerializer.TryDeserialize<ErrorStringMapResponse>(root, options, out var errorStringMapResponseValue))
        {
            return CreatePrepaymentErrorResponse.ErrorStringMapResponse(errorStringMapResponseValue);
        }
        return CreatePrepaymentErrorResponse.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer,
        CreatePrepaymentErrorResponse value,
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
            throw new JsonException($"{nameof(CreatePrepaymentErrorResponse)} contains no valid value to serialize.");
        }
    }
}
