using System.Collections.Generic;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models.AnyOf;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Models;

public record CreateSegment
{
    /// <summary>
    /// A value that will occur in your events that you want to bill upon. The type of the value depends on the property type in the related event based billing metric.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("segment_property_1_value")]
    public SegmentProperty1Value1? SegmentProperty1Value { get; init; }

    /// <summary>
    /// A value that will occur in your events that you want to bill upon. The type of the value depends on the property type in the related event based billing metric.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("segment_property_2_value")]
    public SegmentProperty2Value1? SegmentProperty2Value { get; init; }

    /// <summary>
    /// A value that will occur in your events that you want to bill upon. The type of the value depends on the property type in the related event based billing metric.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("segment_property_3_value")]
    public SegmentProperty3Value1? SegmentProperty3Value { get; init; }

    /// <summary>
    /// A value that will occur in your events that you want to bill upon. The type of the value depends on the property type in the related event based billing metric.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("segment_property_4_value")]
    public SegmentProperty4Value1? SegmentProperty4Value { get; init; }

    /// <summary>
    /// The identifier for the pricing scheme. See Product Addons for an overview of pricing schemes.
    /// </summary>
    [JsonPropertyName("pricing_scheme")]
    public required PricingScheme PricingScheme { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("prices")]
    public IReadOnlyList<CreateOrUpdateSegmentPrice>? Prices { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
