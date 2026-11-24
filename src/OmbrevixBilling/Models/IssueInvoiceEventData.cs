using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Models;

/// <summary>
/// Example schema for an <c>issue_invoice</c> event
/// </summary>
public record IssueInvoiceEventData
{
    /// <summary>
    /// Consolidation level of the invoice, which is applicable to invoice consolidation. It will hold one of the following values:
    /// <list type="bullet">
    ///   <item><description>"none": A normal invoice with no consolidation.</description></item>
    ///   <item><description>"child": An invoice segment which has been combined into a consolidated invoice.</description></item>
    ///   <item><description>"parent": A consolidated invoice, whose contents are composed of invoice segments.</description></item>
    /// </list>
    /// <para>
    /// "Parent" invoices do not have lines of their own, but they have subtotals and totals which aggregate the member invoice segments.
    /// </para>
    /// <para>
    /// See also the invoice consolidation documentation.
    /// </para>
    /// </summary>
    [JsonPropertyName("consolidation_level")]
    public required InvoiceConsolidationLevel ConsolidationLevel { get; init; }

    /// <summary>
    /// The status of the invoice before event occurrence. See Invoice Statuses for more.
    /// </summary>
    [JsonPropertyName("from_status")]
    public required InvoiceStatus FromStatus { get; init; }

    /// <summary>
    /// The status of the invoice after event occurrence. See Invoice Statuses for more.
    /// </summary>
    [JsonPropertyName("to_status")]
    public required InvoiceStatus ToStatus { get; init; }

    /// <summary>
    /// Amount due on the invoice, which is <c>total_amount - credit_amount - paid_amount</c>.
    /// </summary>
    [JsonPropertyName("due_amount")]
    public required string DueAmount { get; init; }

    /// <summary>
    /// The invoice total, which is <c>subtotal_amount - discount_amount + tax_amount</c>.'
    /// </summary>
    [JsonPropertyName("total_amount")]
    public required string TotalAmount { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
