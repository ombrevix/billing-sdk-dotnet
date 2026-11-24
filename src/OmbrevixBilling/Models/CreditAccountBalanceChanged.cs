using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record CreditAccountBalanceChanged
{
    [JsonPropertyName("reason")]
    public required string Reason { get; init; }

    [JsonPropertyName("service_credit_account_balance_minor")]
    public required long ServiceCreditAccountBalanceMinor { get; init; }

    [JsonPropertyName("service_credit_balance_change_minor")]
    public required long ServiceCreditBalanceChangeMinor { get; init; }

    [JsonPropertyName("currency_code")]
    public required string CurrencyCode { get; init; }

    [JsonPropertyName("at_time")]
    public required DateTimeOffset AtTime { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
