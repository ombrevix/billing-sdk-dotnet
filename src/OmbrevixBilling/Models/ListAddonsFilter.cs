using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record ListAddonsFilter
{
    /// <summary>
    /// Allows fetching addons with matching id based on provided value. Use in query <c>filter[ids]=1,2,3</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("ids")]
    [MinLength(1)]
    public IReadOnlyList<int>? Ids { get; init; }

    /// <summary>
    /// Allows fetching addons with matching use_workspace_exchange_rate based on provided value (refers to default price option). Use in query <c>filter[use_workspace_exchange_rate]=true</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("use_workspace_exchange_rate")]
    public bool? UseWorkspaceExchangeRate { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
