using CryptoExchange.Net.Attributes;

namespace Coinbase.Net.Enums;

public enum OrderTimeInForce
{
    /// <summary>
    /// GTC
    /// </summary>
    [Map("GTC")]
    GoodTillCanceled,
    /// <summary>
    /// GTC
    /// </summary>
    [Map("GTT")]
    GoodTillTime,
    /// <summary>
    /// IOC
    /// </summary>
    [Map("IOC")]
    ImmediateOrCancel,
    /// <summary>
    /// FOK
    /// </summary>
    [Map("FOK")]
    FillOrKill
}