using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Extensions;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models.AnyOf;

[JsonConverter(typeof(DatafieldsConverter))]
public record Datafields
{
    private readonly Optional<CreateDatafield> _createDatafieldValue;

    private readonly Optional<IReadOnlyList<CreateDatafield>> _listOfCreateDatafieldValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private Datafields(Optional<CreateDatafield> createDatafieldValue,
        Optional<IReadOnlyList<CreateDatafield>> listOfCreateDatafieldValue,
        Optional<UnknownArm> unknownValue)
    {
        _createDatafieldValue = createDatafieldValue;
        _listOfCreateDatafieldValue = listOfCreateDatafieldValue;
        _unknownValue = unknownValue;
    }

    public static Datafields CreateDatafield(CreateDatafield value) =>
        new(Optional<CreateDatafield>.Some(value), default, default);

    public static Datafields ListOfCreateDatafield(IReadOnlyList<CreateDatafield> value) =>
        new(default, Optional<IReadOnlyList<CreateDatafield>>.Some(value), default);

    internal static Datafields Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetCreateDatafield([NotNullWhen(true)] out CreateDatafield? value) =>
        _createDatafieldValue.TryGetValue(out value);

    public bool TryGetListOfCreateDatafield([NotNullWhen(true)] out IReadOnlyList<CreateDatafield>? value) =>
        _listOfCreateDatafieldValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator Datafields(CreateDatafield value) => CreateDatafield(value);

    public TResult Match<TResult>(Func<CreateDatafield, TResult> onCreateDatafield,
        Func<IReadOnlyList<CreateDatafield>, TResult> onListOfCreateDatafield,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetCreateDatafield(out var createDatafieldValue) => onCreateDatafield(createDatafieldValue),
            _ when TryGetListOfCreateDatafield(out var listOfCreateDatafieldValue) => onListOfCreateDatafield(
                listOfCreateDatafieldValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(Datafields)} holds no value.")
        };

    public void Match(Action<CreateDatafield> onCreateDatafield,
        Action<IReadOnlyList<CreateDatafield>> onListOfCreateDatafield,
        Action<JsonElement> otherwise)
    {
        if (TryGetCreateDatafield(out var createDatafieldValue)) onCreateDatafield(createDatafieldValue);
        else if (TryGetListOfCreateDatafield(out var listOfCreateDatafieldValue)) onListOfCreateDatafield(
            listOfCreateDatafieldValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(Datafields)} holds no value.");
    }
}

file sealed class DatafieldsConverter : JsonConverter<Datafields>
{
    public override Datafields Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<CreateDatafield>(root, options, out var createDatafieldValue))
        {
            return Datafields.CreateDatafield(createDatafieldValue);
        }
        if (JsonSerializer.TryDeserialize<IReadOnlyList<CreateDatafield>>(
            root,
            options,
            out var listOfCreateDatafieldValue))
        {
            return Datafields.ListOfCreateDatafield(listOfCreateDatafieldValue);
        }
        return Datafields.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, Datafields value, JsonSerializerOptions options)
    {
        if (value.TryGetCreateDatafield(out var createDatafieldValue))
        {
            JsonSerializer.Serialize(writer, createDatafieldValue, options);
        }
        else if (value.TryGetListOfCreateDatafield(out var listOfCreateDatafieldValue))
        {
            JsonSerializer.Serialize(writer, listOfCreateDatafieldValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(Datafields)} contains no valid value to serialize.");
        }
    }
}
