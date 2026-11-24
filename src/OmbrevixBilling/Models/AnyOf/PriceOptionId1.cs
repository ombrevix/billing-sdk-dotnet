using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models.AnyOf;

/// <summary>
/// Price option that the provision should be charged at. Accepts either the price option's id (integer) or slug (string). When not specified, the default price option will be used.
/// </summary>
[JsonConverter(typeof(PriceOptionId1Converter))]
public record PriceOptionId1
{
    private readonly Optional<string> _stringValue;

    private readonly Optional<int> _intValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private PriceOptionId1(Optional<string> stringValue, Optional<int> intValue, Optional<UnknownArm> unknownValue)
    {
        _stringValue = stringValue;
        _intValue = intValue;
        _unknownValue = unknownValue;
    }

    public static PriceOptionId1 String(string value) => new(Optional<string>.Some(value), default, default);

    public static PriceOptionId1 Int(int value) => new(default, Optional<int>.Some(value), default);

    internal static PriceOptionId1 Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetString([NotNullWhen(true)] out string? value) => _stringValue.TryGetValue(out value);

    public bool TryGetInt(out int value) => _intValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator PriceOptionId1(string value) => String(value);

    public static implicit operator PriceOptionId1(int value) => Int(value);

    public TResult Match<TResult>(Func<string, TResult> onString,
        Func<int, TResult> onInt,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetString(out var stringValue) => onString(stringValue),
            _ when TryGetInt(out var intValue) => onInt(intValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(PriceOptionId1)} holds no value.")
        };

    public void Match(Action<string> onString, Action<int> onInt, Action<JsonElement> otherwise)
    {
        if (TryGetString(out var stringValue)) onString(stringValue);
        else if (TryGetInt(out var intValue)) onInt(intValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(PriceOptionId1)} holds no value.");
    }
}

file sealed class PriceOptionId1Converter : JsonConverter<PriceOptionId1>
{
    public override PriceOptionId1 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (root.ValueKind == JsonValueKind.String)
        {
            var value = root.GetString()!;
            return PriceOptionId1.String(value);
        }
        if (root.ValueKind == JsonValueKind.Number)
        {
            if (root.TryGetInt32(out var intValue))
            {
                return PriceOptionId1.Int(intValue);
            }
        }
        return PriceOptionId1.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, PriceOptionId1 value, JsonSerializerOptions options)
    {
        if (value.TryGetString(out var stringValue))
        {
            JsonSerializer.Serialize(writer, stringValue, options);
        }
        else if (value.TryGetInt(out var intValue))
        {
            JsonSerializer.Serialize(writer, intValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(PriceOptionId1)} contains no valid value to serialize.");
        }
    }
}
