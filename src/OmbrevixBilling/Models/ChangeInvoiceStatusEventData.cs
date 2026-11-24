using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Models;

/// <summary>
/// Example schema for an <c>change_invoice_status</c> event
/// </summary>
public record ChangeInvoiceStatusEventData
{
    /// <summary>
    /// Identifier for the transaction within the payment gateway.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("gateway_trans_id")]
    public string? GatewayTransId { get; init; }

    /// <summary>
    /// The monetary value associated with the linked payment, expressed in dollars.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("amount")]
    public string? Amount { get; init; }

    /// <summary>
    /// The status of the invoice before any changes occurred. See Invoice Statuses for more.
    /// </summary>
    [JsonPropertyName("from_status")]
    public required InvoiceStatus FromStatus { get; init; }

    /// <summary>
    /// The updated status of the invoice after changes have been made. See Invoice Statuses for more.
    /// </summary>
    [JsonPropertyName("to_status")]
    public required InvoiceStatus ToStatus { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("consolidation_level")]
    public InvoiceConsolidationLevel? ConsolidationLevel { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
