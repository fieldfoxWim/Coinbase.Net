using CryptoExchange.Net.Objects.Options;

namespace Coinbase.Net.Objects.Options;

public class CoinbaseSocketOptions : SocketExchangeOptions<CoinbaseEnvironment>
{
    /// <summary>
    /// Default options for new clients
    /// </summary>
    public static CoinbaseSocketOptions Default { get; set; } = new()
    {
        Environment = CoinbaseEnvironment.Live,
        SocketSubscriptionsCombineTarget = 10
    };

    /// <summary>
    /// Options for the Spot API
    /// </summary>
    public CoinbaseSocketApiOptions SpotOptions { get; private set; } = new()
    {
        // RateLimiters = new List<IRateLimiter>
        // {
        //     new RateLimiter()
        //         .AddTotalRateLimit(20, TimeSpan.FromSeconds(1))
        //         .AddConnectionRateLimit("wss://ws-feed.exchange.coinbase.com", 5, TimeSpan.FromSeconds(1))
        // }
    };
    
    internal CoinbaseSocketOptions Copy()
    {
        var options = Copy<CoinbaseSocketOptions>();
        options.SpotOptions = SpotOptions.Copy();
        return options;
    }
}