using Coinbase.Net.Interfaces.Clients.SpotAndMarginApi;
using CryptoExchange.Net.Authentication;

namespace Coinbase.Net.Interfaces.Clients.SpotApi;

public interface ICoinbaseRestClientSpotApi
{
    /// <summary>
    /// Exchange data streams and queries
    /// </summary>
    ICoinbaseRestClientSpotApiExchangeData ExchangeData { get; }

    ICoinbaseRestClientSpotApiTrading Trading { get; }
    
    void SetApiCredentials<T>(T credentials) where T : ApiCredentials;
}