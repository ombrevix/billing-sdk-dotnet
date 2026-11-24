using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Errors;

public sealed class BulkCreateSegmentsError : ApiError
{
    private readonly Optional<EventBasedBillingSegment> _eventBasedBillingSegmentValue;

    private readonly Optional<RawError> _noContentValue;

    private BulkCreateSegmentsError(Optional<EventBasedBillingSegment> eventBasedBillingSegmentValue,
        Optional<RawError> noContentValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _eventBasedBillingSegmentValue = eventBasedBillingSegmentValue;
        _noContentValue = noContentValue;
    }

    private static BulkCreateSegmentsError AsEventBasedBillingSegment(EventBasedBillingSegment value) =>
        new(Optional<EventBasedBillingSegment>.Some(value), default, default);

    private static BulkCreateSegmentsError AsNoContent(RawError value) =>
        new(default, Optional<RawError>.Some(value), default);

    private static BulkCreateSegmentsError AsFallback(RawError value) =>
        new(default, default, Optional<RawError>.Some(value));

    public bool TryGetEventBasedBillingSegment([NotNullWhen(true)] out EventBasedBillingSegment? value) =>
        _eventBasedBillingSegmentValue.TryGetValue(out value);

    public bool TryGetNoContent([NotNullWhen(true)] out RawError? value) => _noContentValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<EventBasedBillingSegment, TResult> onEventBasedBillingSegment,
        Func<RawError, TResult> onNoContent,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetEventBasedBillingSegment(out var eventBasedBillingSegmentValue) => onEventBasedBillingSegment(
                eventBasedBillingSegmentValue),
            _ when TryGetNoContent(out var noContentValue) => onNoContent(noContentValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(BulkCreateSegmentsError)} holds no value.")
        };

    public void Match(Action<EventBasedBillingSegment> onEventBasedBillingSegment,
        Action<RawError> onNoContent,
        Action<RawError> otherwise)
    {
        if (TryGetEventBasedBillingSegment(out var eventBasedBillingSegmentValue)) onEventBasedBillingSegment(
            eventBasedBillingSegmentValue);
        else if (TryGetNoContent(out var noContentValue)) onNoContent(noContentValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(BulkCreateSegmentsError)} holds no value.");
    }

    private static Task<BulkCreateSegmentsError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            404 => response.RawBody().As(AsNoContent),
            422 => response.Json<EventBasedBillingSegment>().As(AsEventBasedBillingSegment),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<BulkCreateSegmentsError> Response { get; } = new(Create);
}
