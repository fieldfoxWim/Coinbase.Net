using CryptoExchange.Net.Objects.Options;

namespace Coinbase.Net.Objects.Options;

public class CoinbaseSocketApiOptions : SocketApiOptions
{
    internal CoinbaseSocketApiOptions Copy()
    {
        var result = Copy<CoinbaseSocketApiOptions>();
        return result;
    }
}