using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models.AnyOf;

/// <summary>
/// Used for Seat Based addons.
/// </summary>
[JsonConverter(typeof(ProvisionedQuantity3Converter))]
public record ProvisionedQuantity3
{
    private readonly Optional<int> _intValue;

    private readonly Optional<string> _stringValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private ProvisionedQuantity3(Optional<int> intValue,
        Optional<string> stringValue,
        Optional<UnknownArm> unknownValue)
    {
        _intValue = intValue;
        _stringValue = stringValue;
        _unknownValue = unknownValue;
    }

    public static ProvisionedQuantity3 Int(int value) => new(Optional<int>.Some(value), default, default);

    public static ProvisionedQuantity3 String(string value) => new(default, Optional<string>.Some(value), default);

    internal static ProvisionedQuantity3 Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetInt(out int value) => _intValue.TryGetValue(out value);

    public bool TryGetString([NotNullWhen(true)] out string? value) => _stringValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator ProvisionedQuantity3(int value) => Int(value);

    public static implicit operator ProvisionedQuantity3(string value) => String(value);

    public TResult Match<TResult>(Func<int, TResult> onInt,
        Func<string, TResult> onString,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetInt(out var intValue) => onInt(intValue),
            _ when TryGetString(out var stringValue) => onString(stringValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(ProvisionedQuantity3)} holds no value.")
        };

    public void Match(Action<int> onInt, Action<string> onString, Action<JsonElement> otherwise)
    {
        if (TryGetInt(out var intValue)) onInt(intValue);
        else if (TryGetString(out var stringValue)) onString(stringValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(ProvisionedQuantity3)} holds no value.");
    }
}

file sealed class ProvisionedQuantity3Converter : JsonConverter<ProvisionedQuantity3>
{
    public override ProvisionedQuantity3 Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (root.ValueKind == JsonValueKind.Number)
        {
            if (root.TryGetInt32(out var intValue))
            {
                return ProvisionedQuantity3.Int(intValue);
            }
        }
        if (root.ValueKind == JsonValueKind.String)
        {
            var value = root.GetString()!;
            return ProvisionedQuantity3.String(value);
        }
        return ProvisionedQuantity3.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, ProvisionedQuantity3 value, JsonSerializerOptions options)
    {
        if (value.TryGetInt(out var intValue))
        {
            JsonSerializer.Serialize(writer, intValue, options);
        }
        else if (value.TryGetString(out var stringValue))
        {
            JsonSerializer.Serialize(writer, stringValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(ProvisionedQuantity3)} contains no valid value to serialize.");
        }
    }
}
