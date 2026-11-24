using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models.AnyOf;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Models;

public record Datafield
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Warning: When updating a datafield's scope attribute, all scope attributes must be passed. Partially complete scope attributes will override the existing settings.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("scope")]
    public DatafieldScope? Scope { get; init; }

    /// <summary>
    /// The amount of subscriptions this datafield has been applied to in Ombrevix Billing.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("data_count")]
    public int? DataCount { get; init; }

    /// <summary>
    /// Indicates the type of datafield. A text datafield allows any string value. Dropdown and radio datafields have a set of values that can be selected. Defaults to 'text'.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("input_type")]
    public DatafieldInput? InputType { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("enum")]
    public EnumModel? Enum { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
