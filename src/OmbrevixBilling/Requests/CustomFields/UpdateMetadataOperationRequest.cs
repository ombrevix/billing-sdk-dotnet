using OmbrevixBilling.Models;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Requests.CustomFields;

/// <summary>
/// The inputs of the UpdateMetadata operation.
/// </summary>
public sealed record UpdateMetadataOperationRequest
{
    /// <summary>
    /// The resource type to which the datafields belong.
    /// </summary>
    public required ResourceType ResourceType { get; init; }

    /// <summary>
    /// The Ombrevix Billing id of the customer or the subscription for which the metadata applies
    /// </summary>
    public required int ResourceId { get; init; }

    public UpdateMetadataRequest? Body { get; init; }
}
