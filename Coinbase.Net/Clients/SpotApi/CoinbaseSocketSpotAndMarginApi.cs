using Coinbase.Net.Interfaces.Clients.SpotAndMarginApi;
using Coinbase.Net.Objects.Internal;
using Coinbase.Net.Objects.Models.Spot;
using Coinbase.Net.Objects.Options;
using Coinbase.Net.Sockets.Subscriptions;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.MessageParsing;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Coinbase.Net.Clients.SpotApi;

/// <inheritdoc />
public class CoinbaseSocketSpotApi : SocketApiClient, ICoinbaseSocketClientSpotApi
{
    #region fields
    /// <inheritdoc />
    public new CoinbaseSocketOptions ClientOptions => (CoinbaseSocketOptions)base.ClientOptions;
    /// <inheritdoc />
    public new CoinbaseSocketApiOptions ApiOptions => (CoinbaseSocketApiOptions)base.ApiOptions;
    #endregion
    
    #region constructor/destructor
    
    public ICoinbaseSocketSpotApiExchangeData ExchangeData { get; }

    internal CoinbaseSocketSpotApi(ILogger logger, CoinbaseSocketOptions options) :
        base(logger, options.Environment.SpotAndMarginSocketAddress, options, options.SpotOptions)
    {
        ExchangeData = new CoinbaseSocketSpotApiExchangeData(logger, this);
    }
    #endregion

    protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
    {
        throw new NotImplementedException();
    }

    public override string FormatSymbol(string baseAsset, string quoteAsset)
    {
        throw new NotImplementedException();
    }

    internal Task<CallResult<UpdateSubscription>> SubscribeAsync<T>(string url, string channel,  IEnumerable<string> topics, Action<DataEvent<T>> onData, CancellationToken ct)
    {
        var subscription = new CoinbaseSubscription<T>(_logger, channel, topics.Select(x => "ticker." + x),  topics.ToList(), onData, false);
        return SubscribeAsync(url, subscription, ct);
    }
    
    private static readonly MessagePath _type = MessagePath.Get().Property("type");
    private static readonly MessagePath _channel = MessagePath.Get().Property("channel");
    private static readonly MessagePath _productId = MessagePath.Get().Property("product_id");

    
    public override string GetListenerIdentifier(IMessageAccessor message)
    {
        var type = message.GetValue<string>(_type);

        if (type.Equals("subscriptions"))
        {
            return "subscribe";
        } else if (type.Equals("ticker") || type.Equals("ticker_batch"))
        { 
            var productId = message.GetValue<string>(_productId);

            return $"ticker.{productId}";
        }
        
        return "unknown";// message.GetValue<string>(_streamPath);
    }
}

