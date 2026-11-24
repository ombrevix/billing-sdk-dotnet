using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Extensions;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models.AnyOf;

[JsonConverter(typeof(Datafields1Converter))]
public record Datafields1
{
    private readonly Optional<UpdateDatafield> _updateDatafieldValue;

    private readonly Optional<IReadOnlyList<UpdateDatafield>> _listOfUpdateDatafieldValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private Datafields1(Optional<UpdateDatafield> updateDatafieldValue,
        Optional<IReadOnlyList<UpdateDatafield>> listOfUpdateDatafieldValue,
        Optional<UnknownArm> unknownValue)
    {
        _updateDatafieldValue = updateDatafieldValue;
        _listOfUpdateDatafieldValue = listOfUpdateDatafieldValue;
        _unknownValue = unknownValue;
    }

    public static Datafields1 UpdateDatafield(UpdateDatafield value) =>
        new(Optional<UpdateDatafield>.Some(value), default, default);

    public static Datafields1 ListOfUpdateDatafield(IReadOnlyList<UpdateDatafield> value) =>
        new(default, Optional<IReadOnlyList<UpdateDatafield>>.Some(value), default);

    internal static Datafields1 Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetUpdateDatafield([NotNullWhen(true)] out UpdateDatafield? value) =>
        _updateDatafieldValue.TryGetValue(out value);

    public bool TryGetListOfUpdateDatafield([NotNullWhen(true)] out IReadOnlyList<UpdateDatafield>? value) =>
        _listOfUpdateDatafieldValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator Datafields1(UpdateDatafield value) => UpdateDatafield(value);

    public TResult Match<TResult>(Func<UpdateDatafield, TResult> onUpdateDatafield,
        Func<IReadOnlyList<UpdateDatafield>, TResult> onListOfUpdateDatafield,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetUpdateDatafield(out var updateDatafieldValue) => onUpdateDatafield(updateDatafieldValue),
            _ when TryGetListOfUpdateDatafield(out var listOfUpdateDatafieldValue) => onListOfUpdateDatafield(
                listOfUpdateDatafieldValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(Datafields1)} holds no value.")
        };

    public void Match(Action<UpdateDatafield> onUpdateDatafield,
        Action<IReadOnlyList<UpdateDatafield>> onListOfUpdateDatafield,
        Action<JsonElement> otherwise)
    {
        if (TryGetUpdateDatafield(out var updateDatafieldValue)) onUpdateDatafield(updateDatafieldValue);
        else if (TryGetListOfUpdateDatafield(out var listOfUpdateDatafieldValue)) onListOfUpdateDatafield(
            listOfUpdateDatafieldValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(Datafields1)} holds no value.");
    }
}

file sealed class Datafields1Converter : JsonConverter<Datafields1>
{
    public override Datafields1 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<UpdateDatafield>(root, options, out var updateDatafieldValue))
        {
            return Datafields1.UpdateDatafield(updateDatafieldValue);
        }
        if (JsonSerializer.TryDeserialize<IReadOnlyList<UpdateDatafield>>(
            root,
            options,
            out var listOfUpdateDatafieldValue))
        {
            return Datafields1.ListOfUpdateDatafield(listOfUpdateDatafieldValue);
        }
        return Datafields1.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, Datafields1 value, JsonSerializerOptions options)
    {
        if (value.TryGetUpdateDatafield(out var updateDatafieldValue))
        {
            JsonSerializer.Serialize(writer, updateDatafieldValue, options);
        }
        else if (value.TryGetListOfUpdateDatafield(out var listOfUpdateDatafieldValue))
        {
            JsonSerializer.Serialize(writer, listOfUpdateDatafieldValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(Datafields1)} contains no valid value to serialize.");
        }
    }
}
