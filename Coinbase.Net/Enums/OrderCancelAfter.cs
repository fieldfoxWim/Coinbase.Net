using CryptoExchange.Net.Attributes;

namespace Coinbase.Net.Enums;

public enum OrderCancelAfter
{
    /// <summary>
    /// Min
    /// </summary>
    [Map("min")]
    Min,
    /// <summary>
    /// Hour
    /// </summary>
    [Map("hour")]
    Hour,
    /// <summary>
    /// Day
    /// </summary>
    [Map("day")]
    Day,
}