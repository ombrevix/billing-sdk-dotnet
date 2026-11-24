namespace OmbrevixBilling.Requests.ApiExports;

/// <summary>
/// The inputs of the ReadEstimateInvoicesExport operation.
/// </summary>
public sealed record ReadEstimateInvoicesExportRequest
{
    /// <summary>
    /// Id of a Batch Job.
    /// </summary>
    public required string BatchId { get; init; }
}
