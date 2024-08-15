using Coinbase.Net.Objects.Internal;
using CryptoExchange.Net;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;

namespace Coinbase.Net.Sockets.Subscriptions;

internal class CoinbaseSubscription<T> : Subscription<CoinbaseSocketQueryResponse, CoinbaseSocketQueryResponse>
{
    /// <inheritdoc />
    public override HashSet<string> ListenerIdentifiers { get; set; }

    private readonly Action<DataEvent<T>> _handler;

    private readonly string _channel;
    private readonly List<string> _topics;

    /// <inheritdoc />
    public override Type? GetMessageType(IMessageAccessor message)
    {
        return typeof(T);
    }

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="topics"></param>
    /// <param name="handler"></param>
    /// <param name="auth"></param>
    public CoinbaseSubscription(ILogger logger, string channel, IEnumerable<string> identifiers, List<string> topics, Action<DataEvent<T>> handler, bool auth) : base(logger, auth)
    {
        _handler = handler;
        _channel = channel;
        ListenerIdentifiers = new HashSet<string>(identifiers);
        _topics = topics;
    }

    /// <inheritdoc />
    public override Query? GetSubQuery(SocketConnection connection)
    {
        return new CoinbaseSystemQuery<CoinbaseSocketQueryResponse>(new CoinbaseSocketRequest
        {
            Type = "subscribe",
            ProductIds = _topics.ToArray(),
            Channels = new List<string>{ _channel }
        }, false);
    }

    /// <inheritdoc />
    public override Query? GetUnsubQuery()
    {
        return new CoinbaseSystemQuery<CoinbaseSocketQueryResponse>(new CoinbaseSocketRequest
        {
            Type = "unsubscribe",
            ProductIds = _topics.ToArray(),
            Channels = new List<string>{ _channel }
        }, false);
    }

    /// <inheritdoc />
    public override CallResult DoHandleMessage(SocketConnection connection, DataEvent<object> message)
    {
        _handler.Invoke(message.As((T)message.Data!, null, null, SocketUpdateType.Update));
        return new CallResult(null);
    }
}