using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models.OneOf;

[JsonConverter(typeof(RenewalConfigurationItemConverter))]
public record RenewalConfigurationItem
{
    private readonly Optional<ScheduledRenewalItemRequestBodyAddon> _scheduledRenewalItemRequestBodyAddonValue;

    private readonly Optional<ScheduledRenewalItemRequestBodyProduct> _scheduledRenewalItemRequestBodyProductValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private RenewalConfigurationItem(Optional<ScheduledRenewalItemRequestBodyAddon> scheduledRenewalItemRequestBodyAddonValue,
        Optional<ScheduledRenewalItemRequestBodyProduct> scheduledRenewalItemRequestBodyProductValue,
        Optional<UnknownArm> unknownValue)
    {
        _scheduledRenewalItemRequestBodyAddonValue = scheduledRenewalItemRequestBodyAddonValue;
        _scheduledRenewalItemRequestBodyProductValue = scheduledRenewalItemRequestBodyProductValue;
        _unknownValue = unknownValue;
    }

    public static RenewalConfigurationItem ScheduledRenewalItemRequestBodyAddon(ScheduledRenewalItemRequestBodyAddon value) =>
        new(Optional<ScheduledRenewalItemRequestBodyAddon>.Some(value), default, default);

    public static RenewalConfigurationItem ScheduledRenewalItemRequestBodyProduct(ScheduledRenewalItemRequestBodyProduct value) =>
        new(default, Optional<ScheduledRenewalItemRequestBodyProduct>.Some(value), default);

    internal static RenewalConfigurationItem Unknown(JsonElement value) =>
        new(default, default, Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetScheduledRenewalItemRequestBodyAddon([NotNullWhen(true)] out ScheduledRenewalItemRequestBodyAddon? value) =>
        _scheduledRenewalItemRequestBodyAddonValue.TryGetValue(out value);

    public bool TryGetScheduledRenewalItemRequestBodyProduct([NotNullWhen(true)] out ScheduledRenewalItemRequestBodyProduct? value) =>
        _scheduledRenewalItemRequestBodyProductValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator RenewalConfigurationItem(ScheduledRenewalItemRequestBodyAddon value) =>
        ScheduledRenewalItemRequestBodyAddon(value);

    public static implicit operator RenewalConfigurationItem(ScheduledRenewalItemRequestBodyProduct value) =>
        ScheduledRenewalItemRequestBodyProduct(value);

    public TResult Match<TResult>(Func<ScheduledRenewalItemRequestBodyAddon, TResult> onScheduledRenewalItemRequestBodyAddon,
        Func<ScheduledRenewalItemRequestBodyProduct, TResult> onScheduledRenewalItemRequestBodyProduct,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetScheduledRenewalItemRequestBodyAddon(
                out var scheduledRenewalItemRequestBodyAddonValue) => onScheduledRenewalItemRequestBodyAddon(
                scheduledRenewalItemRequestBodyAddonValue),
            _ when TryGetScheduledRenewalItemRequestBodyProduct(
                out var scheduledRenewalItemRequestBodyProductValue) => onScheduledRenewalItemRequestBodyProduct(
                scheduledRenewalItemRequestBodyProductValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(RenewalConfigurationItem)} holds no value.")
        };

    public void Match(Action<ScheduledRenewalItemRequestBodyAddon> onScheduledRenewalItemRequestBodyAddon,
        Action<ScheduledRenewalItemRequestBodyProduct> onScheduledRenewalItemRequestBodyProduct,
        Action<JsonElement> otherwise)
    {
        if (TryGetScheduledRenewalItemRequestBodyAddon(
            out var scheduledRenewalItemRequestBodyAddonValue)) onScheduledRenewalItemRequestBodyAddon(
            scheduledRenewalItemRequestBodyAddonValue);
        else if (TryGetScheduledRenewalItemRequestBodyProduct(
            out var scheduledRenewalItemRequestBodyProductValue)) onScheduledRenewalItemRequestBodyProduct(
            scheduledRenewalItemRequestBodyProductValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(RenewalConfigurationItem)} holds no value.");
    }
}

file sealed class RenewalConfigurationItemConverter : JsonConverter<RenewalConfigurationItem>
{
    public override RenewalConfigurationItem Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (!root.TryGetProperty("item_type", out var typeProperty) || typeProperty.ValueKind != JsonValueKind.String)
        {
            throw new JsonException("Missing or non-string 'item_type' discriminator field");
        }
        return typeProperty.GetString() switch
        {
            "Addon" => RenewalConfigurationItem.ScheduledRenewalItemRequestBodyAddon(
                root.Deserialize<ScheduledRenewalItemRequestBodyAddon>(options)!),
            "Product" => RenewalConfigurationItem.ScheduledRenewalItemRequestBodyProduct(
                root.Deserialize<ScheduledRenewalItemRequestBodyProduct>(options)!),
            _ => RenewalConfigurationItem.Unknown(root)
        };
    }

    public override void Write(Utf8JsonWriter writer, RenewalConfigurationItem value, JsonSerializerOptions options)
    {
        if (value.TryGetScheduledRenewalItemRequestBodyAddon(out var scheduledRenewalItemRequestBodyAddonValue))
        {
            JsonSerializer.Serialize(writer, scheduledRenewalItemRequestBodyAddonValue, options);
        }
        else if (value.TryGetScheduledRenewalItemRequestBodyProduct(
            out var scheduledRenewalItemRequestBodyProductValue))
        {
            JsonSerializer.Serialize(writer, scheduledRenewalItemRequestBodyProductValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(RenewalConfigurationItem)} contains no valid value to serialize.");
        }
    }
}
