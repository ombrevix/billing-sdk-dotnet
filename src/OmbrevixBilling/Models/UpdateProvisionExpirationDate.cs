using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record UpdateProvisionExpirationDate
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("provision")]
    public ProvisionExpirationDate? Provision { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
