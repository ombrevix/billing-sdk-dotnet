using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record PrepaidSubscriptionBalanceChanged
{
    [JsonPropertyName("reason")]
    public required string Reason { get; init; }

    [JsonPropertyName("current_account_balance_minor")]
    public required long CurrentAccountBalanceMinor { get; init; }

    [JsonPropertyName("prepayment_account_balance_minor")]
    public required long PrepaymentAccountBalanceMinor { get; init; }

    [JsonPropertyName("current_usage_amount_minor")]
    public required long CurrentUsageAmountMinor { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
