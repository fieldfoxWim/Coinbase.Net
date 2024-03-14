namespace Coinbase.Net.Interfaces.Clients.SpotAndMarginApi;

public interface ICoinbaseSocketClientSpotAndMarginApi
{
    /// <summary>
    /// Exchange data streams and queries
    /// </summary>
    ICoinbaseSocketSpotApiExchangeData ExchangeData { get; }
}