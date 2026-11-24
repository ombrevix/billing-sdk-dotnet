using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record SignupEstimatePreviewResponse
{
    [JsonPropertyName("estimate_invoice_preview")]
    public required SignupEstimatePreview EstimateInvoicePreview { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
