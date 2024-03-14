using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Options;

namespace Coinbase.Net.Objects.Options;

public class CoinbaseRestOptions : RestExchangeOptions<CoinbaseEnvironment>
{
    /// <summary>
    /// Default options for new clients
    /// </summary>
    public static CoinbaseRestOptions Default { get; set; } = new CoinbaseRestOptions()
    {
        Environment = CoinbaseEnvironment.Live,
        AutoTimestamp = true
    };
    
    /// <summary>
    /// Spot API options
    /// </summary>
    public CoinbaseRestApiOptions SpotAndMarginOptions { get; private set; } = new CoinbaseRestApiOptions
    {
        RateLimiters = new List<IRateLimiter>
        {
            new RateLimiter()
                .AddPartialEndpointLimit("/", 200, TimeSpan.FromSeconds(10))
                //.AddPartialEndpointLimit("/sapi/", 180000, TimeSpan.FromMinutes(1))
                //.AddEndpointLimit("/api/v3/order", 50, TimeSpan.FromSeconds(10), HttpMethod.Post, true)
        }
    };
    
    internal CoinbaseRestOptions Copy()
    {
        var options = Copy<CoinbaseRestOptions>();
        options.SpotAndMarginOptions = SpotAndMarginOptions.Copy();
        return options;
    }
}