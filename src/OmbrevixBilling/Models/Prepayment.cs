using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Models;

public record Prepayment
{
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    [JsonPropertyName("subscription_id")]
    public required int SubscriptionId { get; init; }

    [JsonPropertyName("amount_minor")]
    public required long AmountMinor { get; init; }

    [JsonPropertyName("remaining_amount_minor")]
    public required long RemainingAmountMinor { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("refunded_amount_minor")]
    public long? RefundedAmountMinor { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("details")]
    [MinLength(1)]
    public string? Details { get; init; }

    [JsonPropertyName("external")]
    public required bool External { get; init; }

    [JsonPropertyName("memo")]
    [MinLength(1)]
    public required string Memo { get; init; }

    /// <summary>
    /// The payment type of the prepayment.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("payment_type")]
    public PrepaymentMethod? PaymentType { get; init; }

    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
