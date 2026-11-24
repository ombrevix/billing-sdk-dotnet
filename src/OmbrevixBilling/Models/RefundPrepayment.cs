using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models.AnyOf;

namespace OmbrevixBilling.Models;

public record RefundPrepayment
{
    /// <summary>
    /// <c>amount</c> is not required if you pass <c>amount_minor</c>.
    /// </summary>
    [JsonPropertyName("amount_minor")]
    public required long? AmountMinor { get; init; }

    /// <summary>
    /// <c>amount_minor</c> is not required if you pass <c>amount</c>.
    /// </summary>
    [JsonPropertyName("amount")]
    public required Amount5 Amount { get; init; }

    [JsonPropertyName("memo")]
    [MinLength(1)]
    public required string Memo { get; init; }

    /// <summary>
    /// Specify the type of refund you wish to initiate. When the prepayment is external, the <c>external</c> flag is optional. But if the prepayment was made through a payment profile, the <c>external</c> flag is required.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("external")]
    public bool? External { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
