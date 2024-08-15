using Coinbase.Net.Objects.Internal;
using Coinbase.Net.Sockets.Subscriptions;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.Sockets;

namespace Coinbase.Net.Sockets;

internal class CoinbaseSystemQuery<T> : Query<T> where T: CoinbaseSocketQueryResponse
{
    public override HashSet<string> ListenerIdentifiers { get; set; }

    public CoinbaseSystemQuery(CoinbaseSocketRequest request, bool authenticated, int weight = 1) : base(request, authenticated, weight)
    {
        ListenerIdentifiers = new HashSet<string> { request.Type };
    }
    
    // public override CallResult<CoinbaseSocketResponse<TResponse>> HandleMessage(SocketConnection connection, DataEvent<GateIoSocketResponse<TResponse>> message)
    // {
    //     if (message.Data.Error != null)
    //         return message.ToCallResult<GateIoSocketResponse<TResponse>>(new ServerError(message.Data.Error.Code, message.Data.Error.Message));
    //
    //     return message.ToCallResult(message.Data);
    // }
}
