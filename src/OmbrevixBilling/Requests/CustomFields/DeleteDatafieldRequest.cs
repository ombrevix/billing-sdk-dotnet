using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Requests.CustomFields;

/// <summary>
/// The inputs of the DeleteDatafield operation.
/// </summary>
public sealed record DeleteDatafieldRequest
{
    /// <summary>
    /// The resource type to which the datafields belong.
    /// </summary>
    public required ResourceType ResourceType { get; init; }

    /// <summary>
    /// The name of the datafield to be deleted
    /// </summary>
    public string? Name { get; init; }
}
