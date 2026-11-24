using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record PrepaymentAccountBalanceChanged
{
    [JsonPropertyName("reason")]
    public required string Reason { get; init; }

    [JsonPropertyName("prepayment_account_balance_minor")]
    public required long PrepaymentAccountBalanceMinor { get; init; }

    [JsonPropertyName("prepayment_balance_change_minor")]
    public required long PrepaymentBalanceChangeMinor { get; init; }

    [JsonPropertyName("currency_code")]
    public required string CurrencyCode { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
