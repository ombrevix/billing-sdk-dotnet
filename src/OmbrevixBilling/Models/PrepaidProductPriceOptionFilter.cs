using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models;

public record PrepaidProductPriceOptionFilter
{
    /// <summary>
    /// Passed as a parameter to list methods to return only non null values.
    /// </summary>
    [JsonPropertyName("product_price_option_id")]
    public string ProductPriceOptionId { get; } = "not_null";

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
