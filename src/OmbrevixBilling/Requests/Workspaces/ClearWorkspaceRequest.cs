using OmbrevixBilling.Models.Enums;

namespace OmbrevixBilling.Requests.Workspaces;

/// <summary>
/// The inputs of the ClearWorkspace operation.
/// </summary>
public sealed record ClearWorkspaceRequest
{
    /// <summary>
    /// <c>all</c>: Will clear all products, customers, and related subscriptions from the workspace.
    /// <c>customers</c>: Will clear only customers and related subscriptions (leaving the products untouched) for the workspace.
    /// Revenue will also be reset to 0.
    /// Use in query <c>cleanup_scope=all</c>.
    /// </summary>
    public CleanupScope CleanupScope { get; init; } = CleanupScope.All;
}
