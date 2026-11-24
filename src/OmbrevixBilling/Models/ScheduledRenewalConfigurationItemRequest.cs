using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models.OneOf;

namespace OmbrevixBilling.Models;

public record ScheduledRenewalConfigurationItemRequest
{
    [JsonPropertyName("renewal_configuration_item")]
    public required RenewalConfigurationItem RenewalConfigurationItem { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
