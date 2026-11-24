using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OmbrevixBilling.Core.ErrorResponse;
using OmbrevixBilling.Core.Models;
using OmbrevixBilling.Models;

namespace OmbrevixBilling.Errors;

public sealed class ListSegmentsForPriceOptionError : ApiError
{
    private readonly Optional<EventBasedBillingListSegmentsErrors> _eventBasedBillingListSegmentsErrorsValue;

    private readonly Optional<RawError> _noContentValue;

    private ListSegmentsForPriceOptionError(Optional<EventBasedBillingListSegmentsErrors> eventBasedBillingListSegmentsErrorsValue,
        Optional<RawError> noContentValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _eventBasedBillingListSegmentsErrorsValue = eventBasedBillingListSegmentsErrorsValue;
        _noContentValue = noContentValue;
    }

    private static ListSegmentsForPriceOptionError AsEventBasedBillingListSegmentsErrors(EventBasedBillingListSegmentsErrors value) =>
        new(Optional<EventBasedBillingListSegmentsErrors>.Some(value), default, default);

    private static ListSegmentsForPriceOptionError AsNoContent(RawError value) =>
        new(default, Optional<RawError>.Some(value), default);

    private static ListSegmentsForPriceOptionError AsFallback(RawError value) =>
        new(default, default, Optional<RawError>.Some(value));

    public bool TryGetEventBasedBillingListSegmentsErrors([NotNullWhen(true)] out EventBasedBillingListSegmentsErrors? value) =>
        _eventBasedBillingListSegmentsErrorsValue.TryGetValue(out value);

    public bool TryGetNoContent([NotNullWhen(true)] out RawError? value) => _noContentValue.TryGetValue(out value);

    public TResult Match<TResult>(Func<EventBasedBillingListSegmentsErrors, TResult> onEventBasedBillingListSegmentsErrors,
        Func<RawError, TResult> onNoContent,
        Func<RawError, TResult> otherwise) =>
        this switch
        {
            _ when TryGetEventBasedBillingListSegmentsErrors(
                out var eventBasedBillingListSegmentsErrorsValue) => onEventBasedBillingListSegmentsErrors(
                eventBasedBillingListSegmentsErrorsValue),
            _ when TryGetNoContent(out var noContentValue) => onNoContent(noContentValue),
            _ when TryGetRawError(out var fallback) => otherwise(fallback),
            _ => throw new InvalidOperationException($"{nameof(ListSegmentsForPriceOptionError)} holds no value.")
        };

    public void Match(Action<EventBasedBillingListSegmentsErrors> onEventBasedBillingListSegmentsErrors,
        Action<RawError> onNoContent,
        Action<RawError> otherwise)
    {
        if (TryGetEventBasedBillingListSegmentsErrors(
            out var eventBasedBillingListSegmentsErrorsValue)) onEventBasedBillingListSegmentsErrors(
            eventBasedBillingListSegmentsErrorsValue);
        else if (TryGetNoContent(out var noContentValue)) onNoContent(noContentValue);
        else if (TryGetRawError(out var fallback)) otherwise(fallback);
        else throw new InvalidOperationException($"{nameof(ListSegmentsForPriceOptionError)} holds no value.");
    }

    private static Task<ListSegmentsForPriceOptionError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            404 => response.RawBody().As(AsNoContent),
            422 => response.Json<EventBasedBillingListSegmentsErrors>().As(AsEventBasedBillingListSegmentsErrors),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<ListSegmentsForPriceOptionError> Response { get; } = new(Create);
}
