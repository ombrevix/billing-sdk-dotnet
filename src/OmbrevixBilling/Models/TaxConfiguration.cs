using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Models;

public record TaxConfiguration
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("kind")]
    public TaxConfigurationKind? Kind { get; init; } = TaxConfigurationKind.Custom;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("destination_address")]
    public TaxDestinationAddress? DestinationAddress { get; init; }

    /// <summary>
    /// Returns <c>true</c> when Ombrevix has been properly configured to charge tax using the specified tax system. More details about taxes: the product documentation
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("fully_configured")]
    public bool? FullyConfigured { get; init; } = false;

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
