using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Extensions;
using OmbrevixBilling.Core.Models;

namespace OmbrevixBilling.Models.AnyOf;

/// <summary>
/// The schema varies based on the event key. The key-to-event data mapping is as follows:
/// <para>
/// * <c>subscription_product_change</c> - SubscriptionProductChange
/// * <c>subscription_product_change_scheduled</c> - SubscriptionProductChangeScheduled
/// * <c>subscription_state_change</c> - SubscriptionStateChange
/// * <c>signup_success</c>, <c>delayed_signup_creation_success</c>, <c>payment_success</c>, <c>payment_failure</c>, <c>renewal_success</c>, <c>renewal_failure</c>, <c>chargeback_lost</c>, <c>chargeback_accepted</c>, <c>chargeback_closed</c> - PaymentRelatedEvents
/// * <c>refund_success</c> - RefundSuccess
/// * <c>addon_provision_change</c> - AddonProvisionChange
/// * <c>metered_usage</c> - MeteredUsage
/// * <c>prepaid_usage</c> - PrepaidUsage
/// * <c>recovery_step_reached</c> - RecoveryStepReached
/// * <c>invoice_issued</c> - InvoiceIssued
/// * <c>pending_cancellation_change</c> - PendingCancellationChange
/// * <c>prepaid_subscription_balance_changed</c> - PrepaidSubscriptionBalanceChanged
/// * <c>subscription_bundle_signup_success</c> and <c>subscription_bundle_signup_failure</c> - SubscriptionBundleSignupEventData
/// * <c>estimate_invoice_issued</c> - EstimateInvoiceIssued
/// * <c>subscription_prepayment_account_balance_changed</c> - PrepaymentAccountBalanceChanged
/// * <c>collection_mode_changed</c> - CollectionModeChanged
/// * <c>subscription_service_credit_account_balance_changed</c> - CreditAccountBalanceChanged
/// * <c>item_price_option_changed</c> - ItemPriceOptionChanged
/// * <c>custom_field_value_change</c> - CustomFieldValueChange
/// * <c>chjs_tokenization_success</c> - ChjsTokenizationSuccess
/// * <c>chjs_tokenization_failure</c> - ChjsTokenizationFailure
/// * The rest, that is <c>delayed_signup_creation_failure</c>, <c>billing_date_change</c>, <c>expiration_date_change</c>, <c>expiring_card</c>,
/// <c>customer_update</c>, <c>customer_create</c>, <c>customer_delete</c>, <c>upgrade_downgrade_success</c>, <c>upgrade_downgrade_failure</c>,
/// <c>statement_closed</c>, <c>statement_settled</c>, <c>subscription_card_update</c>, <c>subscription_bundle_card_update</c>,
/// <c>subscription_bank_account_update</c>, <c>refund_failure</c>, <c>upcoming_renewal_notice</c>, <c>trial_end_notice</c>,
/// <c>direct_debit_payment_paid_out</c>, <c>direct_debit_payment_rejected</c>, <c>direct_debit_payment_pending</c>, <c>pending_payment_created</c>,
/// <c>pending_payment_failed</c>, <c>pending_payment_completed</c>,  don't have event_specific_data defined,
/// <c>renewal_success_recreated</c>, <c>renewal_failure_recreated</c>, <c>payment_success_recreated</c>, <c>payment_failure_recreated</c>,
/// <c>subscription_deletion</c>, <c>subscription_bundle_bank_account_update</c>, <c>subscription_paypal_account_update</c>, <c>subscription_bundle_paypal_account_update</c>,
/// <c>subscription_customer_change</c>, <c>account_transaction_changed</c>, <c>go_cardless_payment_paid_out</c>, <c>go_cardless_payment_rejected</c>,
/// <c>go_cardless_payment_pending</c>, <c>stripe_direct_debit_payment_paid_out</c>, <c>stripe_direct_debit_payment_rejected</c>, <c>stripe_direct_debit_payment_pending</c>,
/// <c>native_payments_direct_debit_payment_paid_out</c>, <c>native_payments_direct_debit_payment_rejected</c>, <c>native_payments_direct_debit_payment_pending</c>,
/// <c>invoice_in_collections_canceled</c>, <c>subscription_added_to_bundle</c>, <c>subscription_removed_from_bundle</c>, <c>chargeback_opened</c>, <c>chargeback_lost</c>,
/// <c>chargeback_accepted</c>, <c>chargeback_closed</c>, <c>chargeback_won</c>, <c>collection_mode_changed</c>, <c>addon_billing_date_changed</c>,
/// <c>subscription_term_renewal_scheduled</c>, <c>subscription_term_renewal_pending</c>, <c>subscription_term_renewal_activated</c>, <c>subscription_term_renewal_removed</c>
/// they map to <c>null</c> instead.
/// </para>
/// </summary>
[JsonConverter(typeof(EventSpecificDataConverter))]
public record EventSpecificData
{
    private readonly Optional<SubscriptionProductChange> _subscriptionProductChangeValue;

    private readonly Optional<SubscriptionProductChangeScheduled> _subscriptionProductChangeScheduledValue;

    private readonly Optional<SubscriptionStateChange> _subscriptionStateChangeValue;

    private readonly Optional<PaymentRelatedEvents> _paymentRelatedEventsValue;

    private readonly Optional<RefundSuccess> _refundSuccessValue;

    private readonly Optional<AddonProvisionChange> _addonProvisionChangeValue;

    private readonly Optional<MeteredUsage> _meteredUsageValue;

    private readonly Optional<PrepaidUsage> _prepaidUsageValue;

    private readonly Optional<RecoveryStepReached> _recoveryStepReachedValue;

    private readonly Optional<InvoiceIssued> _invoiceIssuedValue;

    private readonly Optional<PendingCancellationChange> _pendingCancellationChangeValue;

    private readonly Optional<PrepaidSubscriptionBalanceChanged> _prepaidSubscriptionBalanceChangedValue;

    private readonly Optional<EstimateInvoiceIssued> _estimateInvoiceIssuedValue;

    private readonly Optional<SubscriptionBundleSignupEventData> _subscriptionBundleSignupEventDataValue;

    private readonly Optional<CreditAccountBalanceChanged> _creditAccountBalanceChangedValue;

    private readonly Optional<PrepaymentAccountBalanceChanged> _prepaymentAccountBalanceChangedValue;

    private readonly Optional<CollectionModeChanged> _collectionModeChangedValue;

    private readonly Optional<ItemPriceOptionChanged> _itemPriceOptionChangedValue;

    private readonly Optional<CustomFieldValueChange> _customFieldValueChangeValue;

    private readonly Optional<ChjsTokenizationSuccess> _chjsTokenizationSuccessValue;

    private readonly Optional<ChjsTokenizationFailure> _chjsTokenizationFailureValue;

    private readonly Optional<UnknownArm> _unknownValue;

    private EventSpecificData(Optional<SubscriptionProductChange> subscriptionProductChangeValue,
        Optional<SubscriptionProductChangeScheduled> subscriptionProductChangeScheduledValue,
        Optional<SubscriptionStateChange> subscriptionStateChangeValue,
        Optional<PaymentRelatedEvents> paymentRelatedEventsValue,
        Optional<RefundSuccess> refundSuccessValue,
        Optional<AddonProvisionChange> addonProvisionChangeValue,
        Optional<MeteredUsage> meteredUsageValue,
        Optional<PrepaidUsage> prepaidUsageValue,
        Optional<RecoveryStepReached> recoveryStepReachedValue,
        Optional<InvoiceIssued> invoiceIssuedValue,
        Optional<PendingCancellationChange> pendingCancellationChangeValue,
        Optional<PrepaidSubscriptionBalanceChanged> prepaidSubscriptionBalanceChangedValue,
        Optional<EstimateInvoiceIssued> estimateInvoiceIssuedValue,
        Optional<SubscriptionBundleSignupEventData> subscriptionBundleSignupEventDataValue,
        Optional<CreditAccountBalanceChanged> creditAccountBalanceChangedValue,
        Optional<PrepaymentAccountBalanceChanged> prepaymentAccountBalanceChangedValue,
        Optional<CollectionModeChanged> collectionModeChangedValue,
        Optional<ItemPriceOptionChanged> itemPriceOptionChangedValue,
        Optional<CustomFieldValueChange> customFieldValueChangeValue,
        Optional<ChjsTokenizationSuccess> chjsTokenizationSuccessValue,
        Optional<ChjsTokenizationFailure> chjsTokenizationFailureValue,
        Optional<UnknownArm> unknownValue)
    {
        _subscriptionProductChangeValue = subscriptionProductChangeValue;
        _subscriptionProductChangeScheduledValue = subscriptionProductChangeScheduledValue;
        _subscriptionStateChangeValue = subscriptionStateChangeValue;
        _paymentRelatedEventsValue = paymentRelatedEventsValue;
        _refundSuccessValue = refundSuccessValue;
        _addonProvisionChangeValue = addonProvisionChangeValue;
        _meteredUsageValue = meteredUsageValue;
        _prepaidUsageValue = prepaidUsageValue;
        _recoveryStepReachedValue = recoveryStepReachedValue;
        _invoiceIssuedValue = invoiceIssuedValue;
        _pendingCancellationChangeValue = pendingCancellationChangeValue;
        _prepaidSubscriptionBalanceChangedValue = prepaidSubscriptionBalanceChangedValue;
        _estimateInvoiceIssuedValue = estimateInvoiceIssuedValue;
        _subscriptionBundleSignupEventDataValue = subscriptionBundleSignupEventDataValue;
        _creditAccountBalanceChangedValue = creditAccountBalanceChangedValue;
        _prepaymentAccountBalanceChangedValue = prepaymentAccountBalanceChangedValue;
        _collectionModeChangedValue = collectionModeChangedValue;
        _itemPriceOptionChangedValue = itemPriceOptionChangedValue;
        _customFieldValueChangeValue = customFieldValueChangeValue;
        _chjsTokenizationSuccessValue = chjsTokenizationSuccessValue;
        _chjsTokenizationFailureValue = chjsTokenizationFailureValue;
        _unknownValue = unknownValue;
    }

    public static EventSpecificData SubscriptionProductChange(SubscriptionProductChange value) =>
        new(
            Optional<SubscriptionProductChange>.Some(value),
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default);

    public static EventSpecificData SubscriptionProductChangeScheduled(SubscriptionProductChangeScheduled value) =>
        new(
            default,
            Optional<SubscriptionProductChangeScheduled>.Some(value),
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default);

    public static EventSpecificData SubscriptionStateChange(SubscriptionStateChange value) =>
        new(
            default,
            default,
            Optional<SubscriptionStateChange>.Some(value),
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default);

    public static EventSpecificData PaymentRelatedEvents(PaymentRelatedEvents value) =>
        new(
            default,
            default,
            default,
            Optional<PaymentRelatedEvents>.Some(value),
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default);

    public static EventSpecificData RefundSuccess(RefundSuccess value) =>
        new(
            default,
            default,
            default,
            default,
            Optional<RefundSuccess>.Some(value),
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default);

    public static EventSpecificData AddonProvisionChange(AddonProvisionChange value) =>
        new(
            default,
            default,
            default,
            default,
            default,
            Optional<AddonProvisionChange>.Some(value),
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default);

    public static EventSpecificData MeteredUsage(MeteredUsage value) =>
        new(
            default,
            default,
            default,
            default,
            default,
            default,
            Optional<MeteredUsage>.Some(value),
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default);

    public static EventSpecificData PrepaidUsage(PrepaidUsage value) =>
        new(
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            Optional<PrepaidUsage>.Some(value),
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default);

    public static EventSpecificData RecoveryStepReached(RecoveryStepReached value) =>
        new(
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            Optional<RecoveryStepReached>.Some(value),
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default);

    public static EventSpecificData InvoiceIssued(InvoiceIssued value) =>
        new(
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            Optional<InvoiceIssued>.Some(value),
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default);

    public static EventSpecificData PendingCancellationChange(PendingCancellationChange value) =>
        new(
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            Optional<PendingCancellationChange>.Some(value),
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default);

    public static EventSpecificData PrepaidSubscriptionBalanceChanged(PrepaidSubscriptionBalanceChanged value) =>
        new(
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            Optional<PrepaidSubscriptionBalanceChanged>.Some(value),
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default);

    public static EventSpecificData EstimateInvoiceIssued(EstimateInvoiceIssued value) =>
        new(
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            Optional<EstimateInvoiceIssued>.Some(value),
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default);

    public static EventSpecificData SubscriptionBundleSignupEventData(SubscriptionBundleSignupEventData value) =>
        new(
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            Optional<SubscriptionBundleSignupEventData>.Some(value),
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default);

    public static EventSpecificData CreditAccountBalanceChanged(CreditAccountBalanceChanged value) =>
        new(
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            Optional<CreditAccountBalanceChanged>.Some(value),
            default,
            default,
            default,
            default,
            default,
            default,
            default);

    public static EventSpecificData PrepaymentAccountBalanceChanged(PrepaymentAccountBalanceChanged value) =>
        new(
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            Optional<PrepaymentAccountBalanceChanged>.Some(value),
            default,
            default,
            default,
            default,
            default,
            default);

    public static EventSpecificData CollectionModeChanged(CollectionModeChanged value) =>
        new(
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            Optional<CollectionModeChanged>.Some(value),
            default,
            default,
            default,
            default,
            default);

    public static EventSpecificData ItemPriceOptionChanged(ItemPriceOptionChanged value) =>
        new(
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            Optional<ItemPriceOptionChanged>.Some(value),
            default,
            default,
            default,
            default);

    public static EventSpecificData CustomFieldValueChange(CustomFieldValueChange value) =>
        new(
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            Optional<CustomFieldValueChange>.Some(value),
            default,
            default,
            default);

    public static EventSpecificData ChjsTokenizationSuccess(ChjsTokenizationSuccess value) =>
        new(
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            Optional<ChjsTokenizationSuccess>.Some(value),
            default,
            default);

    public static EventSpecificData ChjsTokenizationFailure(ChjsTokenizationFailure value) =>
        new(
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            Optional<ChjsTokenizationFailure>.Some(value),
            default);

    internal static EventSpecificData Unknown(JsonElement value) =>
        new(
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            default,
            Optional<UnknownArm>.Some(new UnknownArm(value)));

    public bool TryGetSubscriptionProductChange([NotNullWhen(true)] out SubscriptionProductChange? value) =>
        _subscriptionProductChangeValue.TryGetValue(out value);

    public bool TryGetSubscriptionProductChangeScheduled([NotNullWhen(true)] out SubscriptionProductChangeScheduled? value) =>
        _subscriptionProductChangeScheduledValue.TryGetValue(out value);

    public bool TryGetSubscriptionStateChange([NotNullWhen(true)] out SubscriptionStateChange? value) =>
        _subscriptionStateChangeValue.TryGetValue(out value);

    public bool TryGetPaymentRelatedEvents([NotNullWhen(true)] out PaymentRelatedEvents? value) =>
        _paymentRelatedEventsValue.TryGetValue(out value);

    public bool TryGetRefundSuccess([NotNullWhen(true)] out RefundSuccess? value) =>
        _refundSuccessValue.TryGetValue(out value);

    public bool TryGetAddonProvisionChange([NotNullWhen(true)] out AddonProvisionChange? value) =>
        _addonProvisionChangeValue.TryGetValue(out value);

    public bool TryGetMeteredUsage([NotNullWhen(true)] out MeteredUsage? value) =>
        _meteredUsageValue.TryGetValue(out value);

    public bool TryGetPrepaidUsage([NotNullWhen(true)] out PrepaidUsage? value) =>
        _prepaidUsageValue.TryGetValue(out value);

    public bool TryGetRecoveryStepReached([NotNullWhen(true)] out RecoveryStepReached? value) =>
        _recoveryStepReachedValue.TryGetValue(out value);

    public bool TryGetInvoiceIssued([NotNullWhen(true)] out InvoiceIssued? value) =>
        _invoiceIssuedValue.TryGetValue(out value);

    public bool TryGetPendingCancellationChange([NotNullWhen(true)] out PendingCancellationChange? value) =>
        _pendingCancellationChangeValue.TryGetValue(out value);

    public bool TryGetPrepaidSubscriptionBalanceChanged([NotNullWhen(true)] out PrepaidSubscriptionBalanceChanged? value) =>
        _prepaidSubscriptionBalanceChangedValue.TryGetValue(out value);

    public bool TryGetEstimateInvoiceIssued([NotNullWhen(true)] out EstimateInvoiceIssued? value) =>
        _estimateInvoiceIssuedValue.TryGetValue(out value);

    public bool TryGetSubscriptionBundleSignupEventData([NotNullWhen(true)] out SubscriptionBundleSignupEventData? value) =>
        _subscriptionBundleSignupEventDataValue.TryGetValue(out value);

    public bool TryGetCreditAccountBalanceChanged([NotNullWhen(true)] out CreditAccountBalanceChanged? value) =>
        _creditAccountBalanceChangedValue.TryGetValue(out value);

    public bool TryGetPrepaymentAccountBalanceChanged([NotNullWhen(true)] out PrepaymentAccountBalanceChanged? value) =>
        _prepaymentAccountBalanceChangedValue.TryGetValue(out value);

    public bool TryGetCollectionModeChanged([NotNullWhen(true)] out CollectionModeChanged? value) =>
        _collectionModeChangedValue.TryGetValue(out value);

    public bool TryGetItemPriceOptionChanged([NotNullWhen(true)] out ItemPriceOptionChanged? value) =>
        _itemPriceOptionChangedValue.TryGetValue(out value);

    public bool TryGetCustomFieldValueChange([NotNullWhen(true)] out CustomFieldValueChange? value) =>
        _customFieldValueChangeValue.TryGetValue(out value);

    public bool TryGetChjsTokenizationSuccess([NotNullWhen(true)] out ChjsTokenizationSuccess? value) =>
        _chjsTokenizationSuccessValue.TryGetValue(out value);

    public bool TryGetChjsTokenizationFailure([NotNullWhen(true)] out ChjsTokenizationFailure? value) =>
        _chjsTokenizationFailureValue.TryGetValue(out value);

    public bool TryGetUnknown(out JsonElement value) => _unknownValue.TryGetValue(out value);

    public static implicit operator EventSpecificData(SubscriptionProductChange value) =>
        SubscriptionProductChange(value);

    public static implicit operator EventSpecificData(SubscriptionProductChangeScheduled value) =>
        SubscriptionProductChangeScheduled(value);

    public static implicit operator EventSpecificData(SubscriptionStateChange value) => SubscriptionStateChange(value);

    public static implicit operator EventSpecificData(PaymentRelatedEvents value) => PaymentRelatedEvents(value);

    public static implicit operator EventSpecificData(RefundSuccess value) => RefundSuccess(value);

    public static implicit operator EventSpecificData(AddonProvisionChange value) => AddonProvisionChange(value);

    public static implicit operator EventSpecificData(MeteredUsage value) => MeteredUsage(value);

    public static implicit operator EventSpecificData(PrepaidUsage value) => PrepaidUsage(value);

    public static implicit operator EventSpecificData(RecoveryStepReached value) => RecoveryStepReached(value);

    public static implicit operator EventSpecificData(InvoiceIssued value) => InvoiceIssued(value);

    public static implicit operator EventSpecificData(PendingCancellationChange value) =>
        PendingCancellationChange(value);

    public static implicit operator EventSpecificData(PrepaidSubscriptionBalanceChanged value) =>
        PrepaidSubscriptionBalanceChanged(value);

    public static implicit operator EventSpecificData(EstimateInvoiceIssued value) => EstimateInvoiceIssued(value);

    public static implicit operator EventSpecificData(SubscriptionBundleSignupEventData value) =>
        SubscriptionBundleSignupEventData(value);

    public static implicit operator EventSpecificData(CreditAccountBalanceChanged value) =>
        CreditAccountBalanceChanged(value);

    public static implicit operator EventSpecificData(PrepaymentAccountBalanceChanged value) =>
        PrepaymentAccountBalanceChanged(value);

    public static implicit operator EventSpecificData(CollectionModeChanged value) => CollectionModeChanged(value);

    public static implicit operator EventSpecificData(ItemPriceOptionChanged value) => ItemPriceOptionChanged(value);

    public static implicit operator EventSpecificData(CustomFieldValueChange value) => CustomFieldValueChange(value);

    public static implicit operator EventSpecificData(ChjsTokenizationSuccess value) => ChjsTokenizationSuccess(value);

    public static implicit operator EventSpecificData(ChjsTokenizationFailure value) => ChjsTokenizationFailure(value);

    public TResult Match<TResult>(Func<SubscriptionProductChange, TResult> onSubscriptionProductChange,
        Func<SubscriptionProductChangeScheduled, TResult> onSubscriptionProductChangeScheduled,
        Func<SubscriptionStateChange, TResult> onSubscriptionStateChange,
        Func<PaymentRelatedEvents, TResult> onPaymentRelatedEvents,
        Func<RefundSuccess, TResult> onRefundSuccess,
        Func<AddonProvisionChange, TResult> onAddonProvisionChange,
        Func<MeteredUsage, TResult> onMeteredUsage,
        Func<PrepaidUsage, TResult> onPrepaidUsage,
        Func<RecoveryStepReached, TResult> onRecoveryStepReached,
        Func<InvoiceIssued, TResult> onInvoiceIssued,
        Func<PendingCancellationChange, TResult> onPendingCancellationChange,
        Func<PrepaidSubscriptionBalanceChanged, TResult> onPrepaidSubscriptionBalanceChanged,
        Func<EstimateInvoiceIssued, TResult> onEstimateInvoiceIssued,
        Func<SubscriptionBundleSignupEventData, TResult> onSubscriptionBundleSignupEventData,
        Func<CreditAccountBalanceChanged, TResult> onCreditAccountBalanceChanged,
        Func<PrepaymentAccountBalanceChanged, TResult> onPrepaymentAccountBalanceChanged,
        Func<CollectionModeChanged, TResult> onCollectionModeChanged,
        Func<ItemPriceOptionChanged, TResult> onItemPriceOptionChanged,
        Func<CustomFieldValueChange, TResult> onCustomFieldValueChange,
        Func<ChjsTokenizationSuccess, TResult> onChjsTokenizationSuccess,
        Func<ChjsTokenizationFailure, TResult> onChjsTokenizationFailure,
        Func<JsonElement, TResult> otherwise) =>
        this switch
        {
            _ when TryGetSubscriptionProductChange(
                out var subscriptionProductChangeValue) => onSubscriptionProductChange(subscriptionProductChangeValue),
            _ when TryGetSubscriptionProductChangeScheduled(
                out var subscriptionProductChangeScheduledValue) => onSubscriptionProductChangeScheduled(
                subscriptionProductChangeScheduledValue),
            _ when TryGetSubscriptionStateChange(out var subscriptionStateChangeValue) => onSubscriptionStateChange(
                subscriptionStateChangeValue),
            _ when TryGetPaymentRelatedEvents(out var paymentRelatedEventsValue) => onPaymentRelatedEvents(
                paymentRelatedEventsValue),
            _ when TryGetRefundSuccess(out var refundSuccessValue) => onRefundSuccess(refundSuccessValue),
            _ when TryGetAddonProvisionChange(out var addonProvisionChangeValue) => onAddonProvisionChange(
                addonProvisionChangeValue),
            _ when TryGetMeteredUsage(out var meteredUsageValue) => onMeteredUsage(meteredUsageValue),
            _ when TryGetPrepaidUsage(out var prepaidUsageValue) => onPrepaidUsage(prepaidUsageValue),
            _ when TryGetRecoveryStepReached(out var recoveryStepReachedValue) => onRecoveryStepReached(
                recoveryStepReachedValue),
            _ when TryGetInvoiceIssued(out var invoiceIssuedValue) => onInvoiceIssued(invoiceIssuedValue),
            _ when TryGetPendingCancellationChange(
                out var pendingCancellationChangeValue) => onPendingCancellationChange(pendingCancellationChangeValue),
            _ when TryGetPrepaidSubscriptionBalanceChanged(
                out var prepaidSubscriptionBalanceChangedValue) => onPrepaidSubscriptionBalanceChanged(
                prepaidSubscriptionBalanceChangedValue),
            _ when TryGetEstimateInvoiceIssued(out var estimateInvoiceIssuedValue) => onEstimateInvoiceIssued(
                estimateInvoiceIssuedValue),
            _ when TryGetSubscriptionBundleSignupEventData(
                out var subscriptionBundleSignupEventDataValue) => onSubscriptionBundleSignupEventData(
                subscriptionBundleSignupEventDataValue),
            _ when TryGetCreditAccountBalanceChanged(
                out var creditAccountBalanceChangedValue) => onCreditAccountBalanceChanged(
                creditAccountBalanceChangedValue),
            _ when TryGetPrepaymentAccountBalanceChanged(
                out var prepaymentAccountBalanceChangedValue) => onPrepaymentAccountBalanceChanged(
                prepaymentAccountBalanceChangedValue),
            _ when TryGetCollectionModeChanged(out var collectionModeChangedValue) => onCollectionModeChanged(
                collectionModeChangedValue),
            _ when TryGetItemPriceOptionChanged(out var itemPriceOptionChangedValue) => onItemPriceOptionChanged(
                itemPriceOptionChangedValue),
            _ when TryGetCustomFieldValueChange(out var customFieldValueChangeValue) => onCustomFieldValueChange(
                customFieldValueChangeValue),
            _ when TryGetChjsTokenizationSuccess(out var chjsTokenizationSuccessValue) => onChjsTokenizationSuccess(
                chjsTokenizationSuccessValue),
            _ when TryGetChjsTokenizationFailure(out var chjsTokenizationFailureValue) => onChjsTokenizationFailure(
                chjsTokenizationFailureValue),
            _ when TryGetUnknown(out var unknownValue) => otherwise(unknownValue),
            _ => throw new InvalidOperationException($"{nameof(EventSpecificData)} holds no value.")
        };

    public void Match(Action<SubscriptionProductChange> onSubscriptionProductChange,
        Action<SubscriptionProductChangeScheduled> onSubscriptionProductChangeScheduled,
        Action<SubscriptionStateChange> onSubscriptionStateChange,
        Action<PaymentRelatedEvents> onPaymentRelatedEvents,
        Action<RefundSuccess> onRefundSuccess,
        Action<AddonProvisionChange> onAddonProvisionChange,
        Action<MeteredUsage> onMeteredUsage,
        Action<PrepaidUsage> onPrepaidUsage,
        Action<RecoveryStepReached> onRecoveryStepReached,
        Action<InvoiceIssued> onInvoiceIssued,
        Action<PendingCancellationChange> onPendingCancellationChange,
        Action<PrepaidSubscriptionBalanceChanged> onPrepaidSubscriptionBalanceChanged,
        Action<EstimateInvoiceIssued> onEstimateInvoiceIssued,
        Action<SubscriptionBundleSignupEventData> onSubscriptionBundleSignupEventData,
        Action<CreditAccountBalanceChanged> onCreditAccountBalanceChanged,
        Action<PrepaymentAccountBalanceChanged> onPrepaymentAccountBalanceChanged,
        Action<CollectionModeChanged> onCollectionModeChanged,
        Action<ItemPriceOptionChanged> onItemPriceOptionChanged,
        Action<CustomFieldValueChange> onCustomFieldValueChange,
        Action<ChjsTokenizationSuccess> onChjsTokenizationSuccess,
        Action<ChjsTokenizationFailure> onChjsTokenizationFailure,
        Action<JsonElement> otherwise)
    {
        if (TryGetSubscriptionProductChange(out var subscriptionProductChangeValue)) onSubscriptionProductChange(
            subscriptionProductChangeValue);
        else if (TryGetSubscriptionProductChangeScheduled(
            out var subscriptionProductChangeScheduledValue)) onSubscriptionProductChangeScheduled(
            subscriptionProductChangeScheduledValue);
        else if (TryGetSubscriptionStateChange(out var subscriptionStateChangeValue)) onSubscriptionStateChange(
            subscriptionStateChangeValue);
        else if (TryGetPaymentRelatedEvents(out var paymentRelatedEventsValue)) onPaymentRelatedEvents(
            paymentRelatedEventsValue);
        else if (TryGetRefundSuccess(out var refundSuccessValue)) onRefundSuccess(refundSuccessValue);
        else if (TryGetAddonProvisionChange(out var addonProvisionChangeValue)) onAddonProvisionChange(
            addonProvisionChangeValue);
        else if (TryGetMeteredUsage(out var meteredUsageValue)) onMeteredUsage(meteredUsageValue);
        else if (TryGetPrepaidUsage(out var prepaidUsageValue)) onPrepaidUsage(prepaidUsageValue);
        else if (TryGetRecoveryStepReached(out var recoveryStepReachedValue)) onRecoveryStepReached(
            recoveryStepReachedValue);
        else if (TryGetInvoiceIssued(out var invoiceIssuedValue)) onInvoiceIssued(invoiceIssuedValue);
        else if (TryGetPendingCancellationChange(out var pendingCancellationChangeValue)) onPendingCancellationChange(
            pendingCancellationChangeValue);
        else if (TryGetPrepaidSubscriptionBalanceChanged(
            out var prepaidSubscriptionBalanceChangedValue)) onPrepaidSubscriptionBalanceChanged(
            prepaidSubscriptionBalanceChangedValue);
        else if (TryGetEstimateInvoiceIssued(out var estimateInvoiceIssuedValue)) onEstimateInvoiceIssued(
            estimateInvoiceIssuedValue);
        else if (TryGetSubscriptionBundleSignupEventData(
            out var subscriptionBundleSignupEventDataValue)) onSubscriptionBundleSignupEventData(
            subscriptionBundleSignupEventDataValue);
        else if (TryGetCreditAccountBalanceChanged(
            out var creditAccountBalanceChangedValue)) onCreditAccountBalanceChanged(creditAccountBalanceChangedValue);
        else if (TryGetPrepaymentAccountBalanceChanged(
            out var prepaymentAccountBalanceChangedValue)) onPrepaymentAccountBalanceChanged(
            prepaymentAccountBalanceChangedValue);
        else if (TryGetCollectionModeChanged(out var collectionModeChangedValue)) onCollectionModeChanged(
            collectionModeChangedValue);
        else if (TryGetItemPriceOptionChanged(out var itemPriceOptionChangedValue)) onItemPriceOptionChanged(
            itemPriceOptionChangedValue);
        else if (TryGetCustomFieldValueChange(out var customFieldValueChangeValue)) onCustomFieldValueChange(
            customFieldValueChangeValue);
        else if (TryGetChjsTokenizationSuccess(out var chjsTokenizationSuccessValue)) onChjsTokenizationSuccess(
            chjsTokenizationSuccessValue);
        else if (TryGetChjsTokenizationFailure(out var chjsTokenizationFailureValue)) onChjsTokenizationFailure(
            chjsTokenizationFailureValue);
        else if (TryGetUnknown(out var unknownValue)) otherwise(unknownValue);
        else throw new InvalidOperationException($"{nameof(EventSpecificData)} holds no value.");
    }
}

file sealed class EventSpecificDataConverter : JsonConverter<EventSpecificData>
{
    public override EventSpecificData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<SubscriptionProductChange>(
            root,
            options,
            out var subscriptionProductChangeValue))
        {
            return EventSpecificData.SubscriptionProductChange(subscriptionProductChangeValue);
        }
        if (JsonSerializer.TryDeserialize<SubscriptionProductChangeScheduled>(
            root,
            options,
            out var subscriptionProductChangeScheduledValue))
        {
            return EventSpecificData.SubscriptionProductChangeScheduled(subscriptionProductChangeScheduledValue);
        }
        if (JsonSerializer.TryDeserialize<SubscriptionStateChange>(root, options, out var subscriptionStateChangeValue))
        {
            return EventSpecificData.SubscriptionStateChange(subscriptionStateChangeValue);
        }
        if (JsonSerializer.TryDeserialize<PaymentRelatedEvents>(root, options, out var paymentRelatedEventsValue))
        {
            return EventSpecificData.PaymentRelatedEvents(paymentRelatedEventsValue);
        }
        if (JsonSerializer.TryDeserialize<RefundSuccess>(root, options, out var refundSuccessValue))
        {
            return EventSpecificData.RefundSuccess(refundSuccessValue);
        }
        if (JsonSerializer.TryDeserialize<AddonProvisionChange>(root, options, out var addonProvisionChangeValue))
        {
            return EventSpecificData.AddonProvisionChange(addonProvisionChangeValue);
        }
        if (JsonSerializer.TryDeserialize<MeteredUsage>(root, options, out var meteredUsageValue))
        {
            return EventSpecificData.MeteredUsage(meteredUsageValue);
        }
        if (JsonSerializer.TryDeserialize<PrepaidUsage>(root, options, out var prepaidUsageValue))
        {
            return EventSpecificData.PrepaidUsage(prepaidUsageValue);
        }
        if (JsonSerializer.TryDeserialize<RecoveryStepReached>(root, options, out var recoveryStepReachedValue))
        {
            return EventSpecificData.RecoveryStepReached(recoveryStepReachedValue);
        }
        if (JsonSerializer.TryDeserialize<InvoiceIssued>(root, options, out var invoiceIssuedValue))
        {
            return EventSpecificData.InvoiceIssued(invoiceIssuedValue);
        }
        if (JsonSerializer.TryDeserialize<PendingCancellationChange>(
            root,
            options,
            out var pendingCancellationChangeValue))
        {
            return EventSpecificData.PendingCancellationChange(pendingCancellationChangeValue);
        }
        if (JsonSerializer.TryDeserialize<PrepaidSubscriptionBalanceChanged>(
            root,
            options,
            out var prepaidSubscriptionBalanceChangedValue))
        {
            return EventSpecificData.PrepaidSubscriptionBalanceChanged(prepaidSubscriptionBalanceChangedValue);
        }
        if (JsonSerializer.TryDeserialize<EstimateInvoiceIssued>(root, options, out var estimateInvoiceIssuedValue))
        {
            return EventSpecificData.EstimateInvoiceIssued(estimateInvoiceIssuedValue);
        }
        if (JsonSerializer.TryDeserialize<SubscriptionBundleSignupEventData>(
            root,
            options,
            out var subscriptionBundleSignupEventDataValue))
        {
            return EventSpecificData.SubscriptionBundleSignupEventData(subscriptionBundleSignupEventDataValue);
        }
        if (JsonSerializer.TryDeserialize<CreditAccountBalanceChanged>(
            root,
            options,
            out var creditAccountBalanceChangedValue))
        {
            return EventSpecificData.CreditAccountBalanceChanged(creditAccountBalanceChangedValue);
        }
        if (JsonSerializer.TryDeserialize<PrepaymentAccountBalanceChanged>(
            root,
            options,
            out var prepaymentAccountBalanceChangedValue))
        {
            return EventSpecificData.PrepaymentAccountBalanceChanged(prepaymentAccountBalanceChangedValue);
        }
        if (JsonSerializer.TryDeserialize<CollectionModeChanged>(root, options, out var collectionModeChangedValue))
        {
            return EventSpecificData.CollectionModeChanged(collectionModeChangedValue);
        }
        if (JsonSerializer.TryDeserialize<ItemPriceOptionChanged>(root, options, out var itemPriceOptionChangedValue))
        {
            return EventSpecificData.ItemPriceOptionChanged(itemPriceOptionChangedValue);
        }
        if (JsonSerializer.TryDeserialize<CustomFieldValueChange>(root, options, out var customFieldValueChangeValue))
        {
            return EventSpecificData.CustomFieldValueChange(customFieldValueChangeValue);
        }
        if (JsonSerializer.TryDeserialize<ChjsTokenizationSuccess>(root, options, out var chjsTokenizationSuccessValue))
        {
            return EventSpecificData.ChjsTokenizationSuccess(chjsTokenizationSuccessValue);
        }
        if (JsonSerializer.TryDeserialize<ChjsTokenizationFailure>(root, options, out var chjsTokenizationFailureValue))
        {
            return EventSpecificData.ChjsTokenizationFailure(chjsTokenizationFailureValue);
        }
        return EventSpecificData.Unknown(root);
    }

    public override void Write(Utf8JsonWriter writer, EventSpecificData value, JsonSerializerOptions options)
    {
        if (value.TryGetSubscriptionProductChange(out var subscriptionProductChangeValue))
        {
            JsonSerializer.Serialize(writer, subscriptionProductChangeValue, options);
        }
        else if (value.TryGetSubscriptionProductChangeScheduled(out var subscriptionProductChangeScheduledValue))
        {
            JsonSerializer.Serialize(writer, subscriptionProductChangeScheduledValue, options);
        }
        else if (value.TryGetSubscriptionStateChange(out var subscriptionStateChangeValue))
        {
            JsonSerializer.Serialize(writer, subscriptionStateChangeValue, options);
        }
        else if (value.TryGetPaymentRelatedEvents(out var paymentRelatedEventsValue))
        {
            JsonSerializer.Serialize(writer, paymentRelatedEventsValue, options);
        }
        else if (value.TryGetRefundSuccess(out var refundSuccessValue))
        {
            JsonSerializer.Serialize(writer, refundSuccessValue, options);
        }
        else if (value.TryGetAddonProvisionChange(out var addonProvisionChangeValue))
        {
            JsonSerializer.Serialize(writer, addonProvisionChangeValue, options);
        }
        else if (value.TryGetMeteredUsage(out var meteredUsageValue))
        {
            JsonSerializer.Serialize(writer, meteredUsageValue, options);
        }
        else if (value.TryGetPrepaidUsage(out var prepaidUsageValue))
        {
            JsonSerializer.Serialize(writer, prepaidUsageValue, options);
        }
        else if (value.TryGetRecoveryStepReached(out var recoveryStepReachedValue))
        {
            JsonSerializer.Serialize(writer, recoveryStepReachedValue, options);
        }
        else if (value.TryGetInvoiceIssued(out var invoiceIssuedValue))
        {
            JsonSerializer.Serialize(writer, invoiceIssuedValue, options);
        }
        else if (value.TryGetPendingCancellationChange(out var pendingCancellationChangeValue))
        {
            JsonSerializer.Serialize(writer, pendingCancellationChangeValue, options);
        }
        else if (value.TryGetPrepaidSubscriptionBalanceChanged(out var prepaidSubscriptionBalanceChangedValue))
        {
            JsonSerializer.Serialize(writer, prepaidSubscriptionBalanceChangedValue, options);
        }
        else if (value.TryGetEstimateInvoiceIssued(out var estimateInvoiceIssuedValue))
        {
            JsonSerializer.Serialize(writer, estimateInvoiceIssuedValue, options);
        }
        else if (value.TryGetSubscriptionBundleSignupEventData(out var subscriptionBundleSignupEventDataValue))
        {
            JsonSerializer.Serialize(writer, subscriptionBundleSignupEventDataValue, options);
        }
        else if (value.TryGetCreditAccountBalanceChanged(out var creditAccountBalanceChangedValue))
        {
            JsonSerializer.Serialize(writer, creditAccountBalanceChangedValue, options);
        }
        else if (value.TryGetPrepaymentAccountBalanceChanged(out var prepaymentAccountBalanceChangedValue))
        {
            JsonSerializer.Serialize(writer, prepaymentAccountBalanceChangedValue, options);
        }
        else if (value.TryGetCollectionModeChanged(out var collectionModeChangedValue))
        {
            JsonSerializer.Serialize(writer, collectionModeChangedValue, options);
        }
        else if (value.TryGetItemPriceOptionChanged(out var itemPriceOptionChangedValue))
        {
            JsonSerializer.Serialize(writer, itemPriceOptionChangedValue, options);
        }
        else if (value.TryGetCustomFieldValueChange(out var customFieldValueChangeValue))
        {
            JsonSerializer.Serialize(writer, customFieldValueChangeValue, options);
        }
        else if (value.TryGetChjsTokenizationSuccess(out var chjsTokenizationSuccessValue))
        {
            JsonSerializer.Serialize(writer, chjsTokenizationSuccessValue, options);
        }
        else if (value.TryGetChjsTokenizationFailure(out var chjsTokenizationFailureValue))
        {
            JsonSerializer.Serialize(writer, chjsTokenizationFailureValue, options);
        }
        else if (value.TryGetUnknown(out var unknownValue))
        {
            unknownValue.WriteTo(writer);
        }
        else
        {
            throw new JsonException($"{nameof(EventSpecificData)} contains no valid value to serialize.");
        }
    }
}
