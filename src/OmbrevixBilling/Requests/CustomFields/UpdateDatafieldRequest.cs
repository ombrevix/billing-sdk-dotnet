using OmbrevixBilling.Models;
using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Requests.CustomFields;

/// <summary>
/// The inputs of the UpdateDatafield operation.
/// </summary>
public sealed record UpdateDatafieldRequest
{
    /// <summary>
    /// The resource type to which the datafields belong.
    /// </summary>
    public required ResourceType ResourceType { get; init; }

    public UpdateDatafieldsRequest? Body { get; init; }
}
