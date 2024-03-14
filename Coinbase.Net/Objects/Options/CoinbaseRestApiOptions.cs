using CryptoExchange.Net.Objects.Options;

namespace Coinbase.Net.Objects.Options;

public class CoinbaseRestApiOptions : RestApiOptions
{
    internal CoinbaseRestApiOptions Copy()
    {
        var result = base.Copy<CoinbaseRestApiOptions>();
        return result;
    }
}