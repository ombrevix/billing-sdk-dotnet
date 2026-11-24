namespace OmbrevixBilling.Requests.Addons;

/// <summary>
/// The inputs of the FindAddon operation.
/// </summary>
public sealed record FindAddonRequest
{
    /// <summary>
    /// The slug of the addon to find
    /// </summary>
    public required string Slug { get; init; }
}
