using OmbrevixBilling.Models;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Requests.CustomFields;

/// <summary>
/// The inputs of the CreateMetadata operation.
/// </summary>
public sealed record CreateMetadataOperationRequest
{
    /// <summary>
    /// The resource type to which the datafields belong.
    /// </summary>
    public required ResourceType ResourceType { get; init; }

    /// <summary>
    /// The Ombrevix Billing id of the customer or the subscription for which the metadata applies
    /// </summary>
    public required int ResourceId { get; init; }

    public CreateMetadataRequest? Body { get; init; }
}
