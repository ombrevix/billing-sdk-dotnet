using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record ScheduledRenewalConfigurationRequest
{
    [JsonPropertyName("renewal_configuration")]
    public required ScheduledRenewalConfigurationRequestBody RenewalConfiguration { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
