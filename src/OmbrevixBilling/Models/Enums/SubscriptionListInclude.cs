using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Enum;

namespace OmbrevixBilling.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<SubscriptionListInclude>))]
public sealed record SubscriptionListInclude : OpenStringEnum<SubscriptionListInclude>
{
    private SubscriptionListInclude(string value) : base(value)
    {
    }

    public static readonly SubscriptionListInclude SelfServicePageToken = new("self_service_page_token");

    public TResult Match<TResult>(Func<TResult> onSelfServicePageToken, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == SelfServicePageToken => onSelfServicePageToken(),
            _ => otherwise(Value)
        };

    public void Match(Action onSelfServicePageToken, Action<string> otherwise)
    {
        if (this == SelfServicePageToken) onSelfServicePageToken();
        else otherwise(Value);
    }
}
