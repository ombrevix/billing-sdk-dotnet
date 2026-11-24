using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Extensions;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models.AnyOf;

[JsonConverter(typeof(Errors11Converter))]
public record Errors11
{
    private readonly Optional<SubscriptionBundleMembersArrayError> _subscriptionBundleMembersArrayErrorValue;

    private readonly Optional<SubscriptionBundleSingleError> _subscriptionBundleSingleErrorValue;

    private readonly Optional<string> _stringValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private Errors11(Optional<SubscriptionBundleMembersArrayError> subscriptionBundleMembersArrayErrorValue,
        Optional<SubscriptionBundleSingleError> subscriptionBundleSingleErrorValue,
        Optional<string> stringValue,
        Optional<UnknownArm> unknownValue)
    {
        _subscriptionBundleMembersArrayErrorValue = subscriptionBundleMembersArrayErrorValue;
        _subscriptionBundleSingleErrorValue = subscriptionBundleSingleErrorValue;
        _stringValue = stringValue;
        _unknownValue = unknownValue;
    }

    public static Errors11 SubscriptionBundleMembersArrayError(SubscriptionBundleMembersArrayError value) =>
        new(Optional<SubscriptionBundleMembersArrayError>.Some(value), default, default, default);

    public static Errors11 SubscriptionBundleSingleError(SubscriptionBundleSingleError value) =>
        new(default, Optional<SubscriptionBundleSingleError>.Some(value), default, default);

    public static Errors11 String(string value) => new(default, default, Optional<string>.Some(value), default);

    internal static Errors11 Unknown(JsonElement value) =>
        new(default, default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetSubscriptionBundleMembersArrayError([NotNullWhen(true)] out SubscriptionBundleMembersArrayError? value) =>
        _subscriptionBundleMembersArrayErrorValue.TryGetValue(out value);

    public bool TryGetSubscriptionBundleSingleError([NotNullWhen(true)] out SubscriptionBundleSingleError? value) =>
        _subscriptionBundleSingleErrorValue.TryGetValue(out value);

    public bool TryGetString([NotNullWhen(true)] out string? value) => _stringValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator Errors11(SubscriptionBundleMembersArrayError value) =>
        SubscriptionBundleMembersArrayError(value);

    public static implicit operator Errors11(SubscriptionBundleSingleError value) =>
        SubscriptionBundleSingleError(value);

    public static implicit operator Errors11(string value) => String(value);

    public TResult Match<TResult>(Func<SubscriptionBundleMembersArrayError, TResult> onSubscriptionBundleMembersArrayError,
        Func<SubscriptionBundleSingleError, TResult> onSubscriptionBundleSingleError,
        Func<string, TResult> onString,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetSubscriptionBundleMembersArrayError(
                out var subscriptionBundleMembersArrayErrorValue) => onSubscriptionBundleMembersArrayError(
                subscriptionBundleMembersArrayErrorValue),
            _ when TryGetSubscriptionBundleSingleError(
                out var subscriptionBundleSingleErrorValue) => onSubscriptionBundleSingleError(
                subscriptionBundleSingleErrorValue),
            _ when TryGetString(out var stringValue) => onString(stringValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(Errors11)} holds no value.")
        };

    public void Match(Action<SubscriptionBundleMembersArrayError> onSubscriptionBundleMembersArrayError,
        Action<SubscriptionBundleSingleError> onSubscriptionBundleSingleError,
        Action<string> onString,
        Action<JsonElement> otherwise)
    {
        if (TryGetSubscriptionBundleMembersArrayError(
            out var subscriptionBundleMembersArrayErrorValue)) onSubscriptionBundleMembersArrayError(
            subscriptionBundleMembersArrayErrorValue);
        else if (TryGetSubscriptionBundleSingleError(
            out var subscriptionBundleSingleErrorValue)) onSubscriptionBundleSingleError(
            subscriptionBundleSingleErrorValue);
        else if (TryGetString(out var stringValue)) onString(stringValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(Errors11)} holds no value.");
    }
}

file sealed class Errors11Converter : JsonConverter<Errors11>
{
    public override Errors11 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<SubscriptionBundleMembersArrayError>(
            root,
            options,
            out var subscriptionBundleMembersArrayErrorValue))
        {
            return Errors11.SubscriptionBundleMembersArrayError(subscriptionBundleMembersArrayErrorValue);
        }
        if (JsonSerializer.TryDeserialize<SubscriptionBundleSingleError>(
            root,
            options,
            out var subscriptionBundleSingleErrorValue))
        {
            return Errors11.SubscriptionBundleSingleError(subscriptionBundleSingleErrorValue);
        }
        if (root.ValueKind == JsonValueKind.String)
        {
            var value = root.GetString()!;
            return Errors11.String(value);
        }
        return Errors11.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, Errors11 value, JsonSerializerOptions options)
    {
        if (value.TryGetSubscriptionBundleMembersArrayError(out var subscriptionBundleMembersArrayErrorValue))
        {
            JsonSerializer.Serialize(writer, subscriptionBundleMembersArrayErrorValue, options);
        }
        else if (value.TryGetSubscriptionBundleSingleError(out var subscriptionBundleSingleErrorValue))
        {
            JsonSerializer.Serialize(writer, subscriptionBundleSingleErrorValue, options);
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
            throw new JsonException($"{nameof(Errors11)} contains no valid value to serialize.");
        }
    }
}
