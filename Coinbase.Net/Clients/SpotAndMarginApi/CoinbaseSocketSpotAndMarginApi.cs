using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using Coinbase.Net.Interfaces.Clients.SpotAndMarginApi;
using Coinbase.Net.Objects.Internal;
using Coinbase.Net.Objects.Options;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Coinbase.Net.Clients.SpotAndMarginApi;

/// <inheritdoc />
public class CoinbaseSocketSpotAndMarginApi : SocketApiClient, ICoinbaseSocketClientSpotAndMarginApi
{
    #region fields
    /// <inheritdoc />
    public new CoinbaseSocketOptions ClientOptions => (CoinbaseSocketOptions)base.ClientOptions;
    /// <inheritdoc />
    public new CoinbaseSocketApiOptions ApiOptions => (CoinbaseSocketApiOptions)base.ApiOptions;
    #endregion
    
    #region constructor/destructor
    
    public ICoinbaseSocketSpotApiExchangeData ExchangeData { get; }

    internal CoinbaseSocketSpotAndMarginApi(ILogger logger, CoinbaseSocketOptions options) :
        base(logger, options.Environment.SpotAndMarginSocketAddress, options, options.SpotOptions)
    {
        SetDataInterpreter(_ => string.Empty, null);
        
        ExchangeData = new CoinbaseSocketSpotApiExchangeData(logger, this);
    }
    #endregion

    protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
    {
        throw new NotImplementedException();
    }
    
    internal Task<CallResult<UpdateSubscription>> SubscribeAsync<T>(string url, string channel, IEnumerable<string> symbols, Action<DataEvent<T>> onData, CancellationToken ct)
    {
        var request = new CoinbaseSocketRequest
        {
            Type = "subscribe",
            ProductIds = symbols.ToArray(),
            Channels = new List<string>{ channel }
        };

        return SubscribeAsync(url, request, null, false, onData, ct);
    }

    protected override bool HandleQueryResponse<T>(SocketConnection socketConnection, object request, JToken data, out CallResult<T>? callResult)
    {
        throw new NotImplementedException();
    }

    protected override bool HandleSubscriptionResponse(SocketConnection socketConnection,
        SocketSubscription subscription, object request,
        JToken data, out CallResult<object>? callResult)
    {
        callResult = null!;
        if (data.Type != JTokenType.Object)
            return false;
        var response = data.ToObject<CoinbaseSocketErrorResponse>();

        if (response != null && response.Type.Equals("error"))
        {
            callResult = new CallResult<object>(new ServerError(0, $"{response.Message}: {response.Reason}"));
            return true;
        }
        
        _logger.Log(LogLevel.Trace, $"Socket {socketConnection.SocketId} Subscription completed");
        callResult = new CallResult<object>(new object());
        return true;
    }

    protected override bool MessageMatchesHandler(SocketConnection socketConnection, JToken message, object request)
    {
        return true;
    }

    protected override bool MessageMatchesHandler(SocketConnection socketConnection, JToken message, string identifier)
    {
        return true;
    }

    protected override Task<CallResult<bool>> AuthenticateSocketAsync(SocketConnection socketConnection)
    {
        throw new NotImplementedException();
    }

    protected override Task<bool> UnsubscribeAsync(SocketConnection connection, SocketSubscription subscriptionToUnsub)
    {
        throw new NotImplementedException();
    }
}