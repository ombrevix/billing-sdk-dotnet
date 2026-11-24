using System;
using System.Text.Json.Serialization;
using OmbrevixBilling.Core.Enum;

namespace OmbrevixBilling.Servers;

[JsonConverter(typeof(StringEnumConverter<ServerEnvironment>))]
public sealed record ServerEnvironment : ClosedStringEnum<ServerEnvironment>
{
    private ServerEnvironment(string value) : base(value)
    {
    }

    /// <summary>
    /// Default Ombrevix Billing environment hosted in US. Valid for the majority of our customers.
    /// </summary>
    public static readonly ServerEnvironment Us = new("US");

    /// <summary>
    /// Ombrevix Billing environment hosted in EU. Use only when you requested EU hosting for your AB account.
    /// </summary>
    public static readonly ServerEnvironment Eu = new("EU");

    /// <summary>
    /// Access Ombrevix Billing through a Ombrevix API Gateway connector. Authenticate with your connector Bearer token instead of Basic auth. Events-Usage Billing ingestion does not go through the gateway and keeps its direct URL.
    /// </summary>
    public static readonly ServerEnvironment OmbrevixApiGateway = new("Ombrevix API Gateway");

    public static ServerEnvironment Default() => Us;

    internal TResult Match<TResult>(Func<TResult> onUs, Func<TResult> onEu, Func<TResult> onOmbrevixApiGateway) =>
        this switch
        {
            _ when this == Us => onUs(),
            _ when this == Eu => onEu(),
            _ when this == OmbrevixApiGateway => onOmbrevixApiGateway(),
            _ => throw new InvalidOperationException($"{nameof(ServerEnvironment)} holds no known value.")
        };
}
