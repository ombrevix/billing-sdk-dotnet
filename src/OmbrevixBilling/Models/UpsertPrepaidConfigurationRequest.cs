using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record UpsertPrepaidConfigurationRequest
{
    [JsonPropertyName("prepaid_configuration")]
    public required UpsertPrepaidConfiguration PrepaidConfiguration { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
