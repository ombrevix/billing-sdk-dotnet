using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Errors;

public sealed class UpdateSegmentError : ApiError
{
    private readonly Optional<EventBasedBillingSegmentErrors> _eventBasedBillingSegmentErrorsValue;

    private readonly Optional<RawError> _noContentValue;

    private UpdateSegmentError(Optional<EventBasedBillingSegmentErrors> eventBasedBillingSegmentErrorsValue,
        Optional<RawError> noContentValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _eventBasedBillingSegmentErrorsValue = eventBasedBillingSegmentErrorsValue;
        _noContentValue = noContentValue;
    }

    private static UpdateSegmentError AsEventBasedBillingSegmentErrors(EventBasedBillingSegmentErrors value) =>
        new(Optional<EventBasedBillingSegmentErrors>.Some(value), default, default);

    private static UpdateSegmentError AsNoContent(RawError value) =>
        new(default, Optional<RawError>.Some(value), default);

    private static UpdateSegmentError AsFallback(RawError value) =>
        new(default, default, Optional<RawError>.Some(value));

    public bool TryGetEventBasedBillingSegmentErrors([NotNullWhen(true)] out EventBasedBillingSegmentErrors? value) =>
        _eventBasedBillingSegmentErrorsValue.TryGetValue(out value);

    public bool TryGetNoContent([NotNullWhen(true)] out RawError? value) => _noContentValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<EventBasedBillingSegmentErrors, TResult> onEventBasedBillingSegmentErrors,
        Func<RawError, TResult> onNoContent,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetEventBasedBillingSegmentErrors(
                out var eventBasedBillingSegmentErrorsValue) => onEventBasedBillingSegmentErrors(
                eventBasedBillingSegmentErrorsValue),
            _ when TryGetNoContent(out var noContentValue) => onNoContent(noContentValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(UpdateSegmentError)} holds no value.")
        };

    public void Match(Action<EventBasedBillingSegmentErrors> onEventBasedBillingSegmentErrors,
        Action<RawError> onNoContent,
        Action<RawError> otherwise)
    {
        if (TryGetEventBasedBillingSegmentErrors(
            out var eventBasedBillingSegmentErrorsValue)) onEventBasedBillingSegmentErrors(
            eventBasedBillingSegmentErrorsValue);
        else if (TryGetNoContent(out var noContentValue)) onNoContent(noContentValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(UpdateSegmentError)} holds no value.");
    }

    private static Task<UpdateSegmentError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            404 => response.RawBody().As(AsNoContent),
            422 => response.Json<EventBasedBillingSegmentErrors>().As(AsEventBasedBillingSegmentErrors),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<UpdateSegmentError> Response { get; } = new(Create);
}
