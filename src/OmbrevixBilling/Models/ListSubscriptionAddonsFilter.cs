using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record ListSubscriptionAddonsFilter
{
    /// <summary>
    /// Allows fetching addons provision with matching currency based on provided values. Use in query <c>filter[currencies]=EUR,USD</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("currencies")]
    [MinLength(1)]
    public IReadOnlyList<string>? Currencies { get; init; }

    /// <summary>
    /// Allows fetching addons provision with matching use_workspace_exchange_rate based on provided value. Use in query <c>filter[use_workspace_exchange_rate]=true</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("use_workspace_exchange_rate")]
    public bool? UseWorkspaceExchangeRate { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
