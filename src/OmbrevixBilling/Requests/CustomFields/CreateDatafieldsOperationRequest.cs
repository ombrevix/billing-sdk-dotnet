using OmbrevixBilling.Models;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Requests.CustomFields;

/// <summary>
/// The inputs of the CreateDatafields operation.
/// </summary>
public sealed record CreateDatafieldsOperationRequest
{
    /// <summary>
    /// The resource type to which the datafields belong.
    /// </summary>
    public required ResourceType ResourceType { get; init; }

    public CreateDatafieldsRequest? Body { get; init; }
}
