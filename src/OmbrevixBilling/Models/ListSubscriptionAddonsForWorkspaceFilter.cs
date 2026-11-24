using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record ListSubscriptionAddonsForWorkspaceFilter
{
    /// <summary>
    /// Allows fetching addons provision with matching currency based on provided values. Use in query <c>filter[currencies]=USD,EUR</c>.
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

    /// <summary>
    /// Nested filter used for List Subscription Addons For Workspace Filter
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("subscription")]
    public SubscriptionFilter? Subscription { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
