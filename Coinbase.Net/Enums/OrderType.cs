using CryptoExchange.Net.Attributes;

namespace Coinbase.Net.Enums;

public enum OrderType
{
    /// <summary>
    /// Limit
    /// </summary>
    [Map("limit")]
    Limit,
    /// <summary>
    /// Market
    /// </summary>
    [Map("market")]
    Market,
    /// <summary>
    /// Stop
    /// </summary>
    [Map("stop")]
    Stop
}