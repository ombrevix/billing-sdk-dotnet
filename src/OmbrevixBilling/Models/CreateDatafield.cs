using System.Collections.Generic;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Models;

public record CreateDatafield
{
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
    /// Indicates the type of datafield. A text datafield allows any string value. Dropdown and radio datafields have a set of values that can be selected. Defaults to 'text'.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("input_type")]
    public DatafieldInput? InputType { get; init; }

    /// <summary>
    /// Only applicable when input_type is radio or dropdown. Empty strings will not be submitted.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("enum")]
    public IReadOnlyList<string>? Enum { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
