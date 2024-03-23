using Coinbase.Net.Interfaces.Clients.SpotAndMarginApi;
using Coinbase.Net.Objects.Models.Spot;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;

namespace Coinbase.Net.Clients.SpotApi;

public class CoinbaseSocketSpotApiExchangeData : ICoinbaseSocketSpotApiExchangeData
{
    private readonly ILogger _logger;
    private readonly CoinbaseSocketSpotApi _client;
    internal CoinbaseSocketSpotApiExchangeData(ILogger logger, CoinbaseSocketSpotApi client)
    {
        _client = client;
        _logger = logger;
    }

    public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol,
        Action<DataEvent<CoinbaseTick>> onMessage, CancellationToken ct = default) => 
        await SubscribeToTickerUpdatesAsync(new List<string> { symbol }, onMessage, ct).ConfigureAwait(false);

    public async Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(List<string> symbols, 
        Action<DataEvent<CoinbaseTick>> onMessage, 
        CancellationToken ct = default)
    {
        symbols.ValidateNotNull(nameof(symbols));
        foreach (var symbol in symbols)
            symbol.ValidateCoinbaseSymbol();
        
        var handler = new Action<DataEvent<CoinbaseTick>>(data => 
            onMessage(data.As(data.Data, data.Data.ProductId)));
        
        return await _client.SubscribeAsync(
                _client.BaseAddress, "ticker", symbols, handler, ct)
            .ConfigureAwait(false);
    }
    
    public async Task<CallResult<UpdateSubscription>> SubscribeToBatchedTickerUpdatesAsync(List<string> symbols, 
        Action<DataEvent<CoinbaseTick>> onMessage, 
        CancellationToken ct = default)
    {
        symbols.ValidateNotNull(nameof(symbols));
        foreach (var symbol in symbols)
            symbol.ValidateCoinbaseSymbol();
        
        var handler = new Action<DataEvent<CoinbaseTick>>(data => 
            onMessage(data.As(data.Data, data.Data.ProductId)));
        
        return await _client.SubscribeAsync(
                _client.BaseAddress, "ticker_batch", symbols, handler, ct)
            .ConfigureAwait(false);
    }
}