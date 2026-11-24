using OmbrevixBilling.Models;

namespace OmbrevixBilling.Requests.Addons;

/// <summary>
/// The inputs of the UpdateAddon operation.
/// </summary>
public sealed record UpdateAddonOperationRequest
{
    /// <summary>
    /// The id or slug of the addon
    /// </summary>
    public required string AddonId { get; init; }

    public UpdateAddonRequest? Body { get; init; }
}
