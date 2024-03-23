namespace Coinbase.Net.Interfaces.Clients.SpotAndMarginApi;

public interface ICoinbaseSocketClientSpotApi
{
    /// <summary>
    /// Exchange data streams and queries
    /// </summary>
    ICoinbaseSocketSpotApiExchangeData ExchangeData { get; }
}