using System.Collections.Generic;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Requests.CustomFields;

/// <summary>
/// The inputs of the DeleteMetadata operation.
/// </summary>
public sealed record DeleteMetadataRequest
{
    /// <summary>
    /// The resource type to which the datafields belong.
    /// </summary>
    public required ResourceType ResourceType { get; init; }

    /// <summary>
    /// The Ombrevix Billing id of the customer or the subscription for which the metadata applies
    /// </summary>
    public required int ResourceId { get; init; }

    /// <summary>
    /// Name of field to be removed.
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    /// Names of fields to be removed. Use in query: <c>names[]=field1&amp;names[]=my-field&amp;names[]=another-field</c>.
    /// </summary>
    public IReadOnlyList<string>? Names { get; init; }
}
