using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Extensions;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models.AnyOf;

[JsonConverter(typeof(PriceOptionConverter))]
public record PriceOption
{
    private readonly Optional<CreateAddonPriceOption> _createAddonPriceOptionValue;

    private readonly Optional<CreatePrepaidUsageAddonPriceOption> _createPrepaidUsageAddonPriceOptionValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private PriceOption(Optional<CreateAddonPriceOption> createAddonPriceOptionValue,
        Optional<CreatePrepaidUsageAddonPriceOption> createPrepaidUsageAddonPriceOptionValue,
        Optional<UnknownArm> unknownValue)
    {
        _createAddonPriceOptionValue = createAddonPriceOptionValue;
        _createPrepaidUsageAddonPriceOptionValue = createPrepaidUsageAddonPriceOptionValue;
        _unknownValue = unknownValue;
    }

    public static PriceOption CreateAddonPriceOption(CreateAddonPriceOption value) =>
        new(Optional<CreateAddonPriceOption>.Some(value), default, default);

    public static PriceOption CreatePrepaidUsageAddonPriceOption(CreatePrepaidUsageAddonPriceOption value) =>
        new(default, Optional<CreatePrepaidUsageAddonPriceOption>.Some(value), default);

    internal static PriceOption Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetCreateAddonPriceOption([NotNullWhen(true)] out CreateAddonPriceOption? value) =>
        _createAddonPriceOptionValue.TryGetValue(out value);

    public bool TryGetCreatePrepaidUsageAddonPriceOption([NotNullWhen(true)] out CreatePrepaidUsageAddonPriceOption? value) =>
        _createPrepaidUsageAddonPriceOptionValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator PriceOption(CreateAddonPriceOption value) => CreateAddonPriceOption(value);

    public static implicit operator PriceOption(CreatePrepaidUsageAddonPriceOption value) =>
        CreatePrepaidUsageAddonPriceOption(value);

    public TResult Match<TResult>(Func<CreateAddonPriceOption, TResult> onCreateAddonPriceOption,
        Func<CreatePrepaidUsageAddonPriceOption, TResult> onCreatePrepaidUsageAddonPriceOption,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetCreateAddonPriceOption(out var createAddonPriceOptionValue) => onCreateAddonPriceOption(
                createAddonPriceOptionValue),
            _ when TryGetCreatePrepaidUsageAddonPriceOption(
                out var createPrepaidUsageAddonPriceOptionValue) => onCreatePrepaidUsageAddonPriceOption(
                createPrepaidUsageAddonPriceOptionValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(PriceOption)} holds no value.")
        };

    public void Match(Action<CreateAddonPriceOption> onCreateAddonPriceOption,
        Action<CreatePrepaidUsageAddonPriceOption> onCreatePrepaidUsageAddonPriceOption,
        Action<JsonElement> otherwise)
    {
        if (TryGetCreateAddonPriceOption(out var createAddonPriceOptionValue)) onCreateAddonPriceOption(
            createAddonPriceOptionValue);
        else if (TryGetCreatePrepaidUsageAddonPriceOption(
            out var createPrepaidUsageAddonPriceOptionValue)) onCreatePrepaidUsageAddonPriceOption(
            createPrepaidUsageAddonPriceOptionValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(PriceOption)} holds no value.");
    }
}

file sealed class PriceOptionConverter : JsonConverter<PriceOption>
{
    public override PriceOption Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<CreateAddonPriceOption>(root, options, out var createAddonPriceOptionValue))
        {
            return PriceOption.CreateAddonPriceOption(createAddonPriceOptionValue);
        }
        if (JsonSerializer.TryDeserialize<CreatePrepaidUsageAddonPriceOption>(
            root,
            options,
            out var createPrepaidUsageAddonPriceOptionValue))
        {
            return PriceOption.CreatePrepaidUsageAddonPriceOption(createPrepaidUsageAddonPriceOptionValue);
        }
        return PriceOption.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, PriceOption value, JsonSerializerOptions options)
    {
        if (value.TryGetCreateAddonPriceOption(out var createAddonPriceOptionValue))
        {
            JsonSerializer.Serialize(writer, createAddonPriceOptionValue, options);
        }
        else if (value.TryGetCreatePrepaidUsageAddonPriceOption(out var createPrepaidUsageAddonPriceOptionValue))
        {
            JsonSerializer.Serialize(writer, createPrepaidUsageAddonPriceOptionValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(PriceOption)} contains no valid value to serialize.");
        }
    }
}
