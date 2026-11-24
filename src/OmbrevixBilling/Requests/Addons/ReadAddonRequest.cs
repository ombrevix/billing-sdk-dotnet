using System.ComponentModel.DataAnnotations;

namespace OmbrevixBilling.Requests.Addons;

/// <summary>
/// The inputs of the ReadAddon operation.
/// </summary>
public sealed record ReadAddonRequest
{
    /// <summary>
    /// The Ombrevix Billing id of the product lineup to which the addon belongs
    /// </summary>
    public required int ProductLineupId { get; init; }

    /// <summary>
    /// Either the Ombrevix Billing id of the addon or the slug for the addon prefixed with <c>slug:</c>
    /// </summary>
    [RegularExpression("/\\A(?:\\d+|handle:(?:uuid:|[a-z])(?:\\w|-)+)\\z/")]
    public required string AddonId { get; init; }
}
