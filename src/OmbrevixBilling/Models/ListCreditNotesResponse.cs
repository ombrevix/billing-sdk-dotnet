using System.Collections.Generic;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record ListCreditNotesResponse
{
    [JsonPropertyName("credit_notes")]
    public required IReadOnlyList<CreditNote> CreditNotes { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
