using Coinbase.Net.Objects.Models.Spot;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;

namespace Coinbase.Net.Interfaces.Clients.SpotAndMarginApi;

public interface ICoinbaseSocketSpotApiExchangeData
{
    /// <inheritdoc />
    Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, 
        Action<DataEvent<CoinbaseTick>> onMessage, 
        CancellationToken ct = default);
    
    /// <inheritdoc />
    Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(List<string> symbol, 
        Action<DataEvent<CoinbaseTick>> onMessage, 
        CancellationToken ct = default);

    Task<CallResult<UpdateSubscription>> SubscribeToBatchedTickerUpdatesAsync(List<string> symbols,
        Action<DataEvent<CoinbaseTick>> onMessage,
        CancellationToken ct = default);

}