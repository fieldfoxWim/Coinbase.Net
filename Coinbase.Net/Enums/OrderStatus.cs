using CryptoExchange.Net.Attributes;

namespace Coinbase.Net.Enums;

public enum OrderStatus
{
    /// <summary>
    /// Open
    /// </summary>
    [Map("open")]
    Open,
    /// <summary>
    /// Pending
    /// </summary>
    [Map("pending")]
    Pending,
    /// <summary>
    /// Rejected
    /// </summary>
    [Map("rejected")]
    Rejected,
    /// <summary>
    /// Rejected
    /// </summary>
    [Map("done")]
    Done,
    /// <summary>
    /// Active
    /// </summary>
    [Map("active")]
    Active,
    /// <summary>
    /// Received
    /// </summary>
    [Map("received")]
    Received,
    /// <summary>
    /// All
    /// </summary>
    [Map("all")]
    All
}