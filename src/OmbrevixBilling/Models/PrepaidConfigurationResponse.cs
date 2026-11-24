using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record PrepaidConfigurationResponse
{
    [JsonPropertyName("prepaid_configuration")]
    public required PrepaidConfiguration PrepaidConfiguration { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
