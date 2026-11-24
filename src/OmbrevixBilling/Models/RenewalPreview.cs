using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record RenewalPreview
{
    /// <summary>
    /// The timestamp for the subscription’s next renewal
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("next_evaluation_at")]
    public DateTimeOffset? NextEvaluationAt { get; init; }

    /// <summary>
    /// An integer representing the amount of the total pre-tax, pre-discount charges that will be assessed at the next renewal
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("subtotal_minor")]
    public long? SubtotalMinor { get; init; }

    /// <summary>
    /// An integer representing the total tax charges that will be assessed at the next renewal
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("total_tax_minor")]
    public long? TotalTaxMinor { get; init; }

    /// <summary>
    /// An integer representing the amount of the coupon discounts that will be applied to the next renewal
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("total_discount_minor")]
    public long? TotalDiscountMinor { get; init; }

    /// <summary>
    /// An integer representing the total amount owed, less any discounts, that will be assessed at the next renewal
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("total_minor")]
    public long? TotalMinor { get; init; }

    /// <summary>
    /// An integer representing the amount of the subscription’s current balance
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("existing_balance_minor")]
    public long? ExistingBalanceMinor { get; init; }

    /// <summary>
    /// An integer representing the existing_balance_minor plus the total_minor
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("total_amount_due_minor")]
    public long? TotalAmountDueMinor { get; init; }

    /// <summary>
    /// A boolean indicating whether or not additional taxes will be calculated at the time of renewal. This will be true if you are using Avalara and the address of the subscription is in one of your defined taxable regions.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("uncalculated_taxes")]
    public bool? UncalculatedTaxes { get; init; }

    /// <summary>
    /// An array of objects representing the individual transactions that will be created at the next renewal
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("line_items")]
    public IReadOnlyList<RenewalPreviewLineItem>? LineItems { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
