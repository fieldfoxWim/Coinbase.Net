namespace Coinbase.Net;

public class CoinbaseApiAddresses
{
    /// <summary>
    /// The address used by the CoinbaseClient for the Spot API
    /// </summary>
    public string RestClientAddress { get; set; } = string.Empty;
    /// <summary>
    /// The address used by the CoinbaseSocketClient for the Spot streams
    /// </summary>
    public string SocketClientAddress { get; set; } = string.Empty;
    
    /// <summary>
    /// The default addresses to connect to the binance.com API
    /// </summary>
    public static CoinbaseApiAddresses Default = new CoinbaseApiAddresses
    {
        RestClientAddress = "https://api.exchange.coinbase.com/",
        SocketClientAddress = "wss://ws-feed.exchange.coinbase.com",
    };
    
    /// <summary>
    /// The addresses to connect to the binance testnet
    /// </summary>
    public static CoinbaseApiAddresses TestNet = new CoinbaseApiAddresses
    {
        RestClientAddress = "https://api-public.sandbox.exchange.coinbase.com",
        SocketClientAddress = "wss://ws-feed-public.sandbox.exchange.coinbase.com"
    };
    
}