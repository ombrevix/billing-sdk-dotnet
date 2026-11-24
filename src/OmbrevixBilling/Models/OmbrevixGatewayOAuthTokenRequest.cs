using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record OmbrevixGatewayOAuthTokenRequest
{
    [JsonPropertyName("grant_type")]
    public string GrantType { get; } = "client_credentials";

    /// <summary>
    /// OAuth client identifier. Omit when authenticating with HTTP Basic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("client_id")]
    public string? ClientId { get; init; }

    /// <summary>
    /// OAuth client secret. Omit when authenticating with HTTP Basic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("client_secret")]
    public string? ClientSecret { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
