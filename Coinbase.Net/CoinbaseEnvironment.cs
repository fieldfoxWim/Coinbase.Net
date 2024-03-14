using CryptoExchange.Net.Objects;

namespace Coinbase.Net;

public class CoinbaseEnvironment : TradeEnvironment
{
    /// <summary>
    /// Spot And Margin Rest API address
    /// </summary>
    public string SpotAndMarginRestAddress { get; }

    /// <summary>
    /// Spot And Margin Socket Streams address
    /// </summary>
    public string SpotAndMarginSocketAddress { get; }
    
    protected CoinbaseEnvironment(
        string name, 
        string spotAndMarginRestAddress, 
        string spotAndMarginSocketAddress ) : base(name)
    {
        SpotAndMarginRestAddress = spotAndMarginRestAddress;
        SpotAndMarginSocketAddress = spotAndMarginSocketAddress;
    }
    
    /// <summary>
    /// Live environment
    /// </summary>
    public static CoinbaseEnvironment Live { get; } 
        = new CoinbaseEnvironment(TradeEnvironmentNames.Live, 
            CoinbaseApiAddresses.Default.RestClientAddress,
            CoinbaseApiAddresses.Default.SocketClientAddress
            );
    
    /// <summary>
    /// Testnet environment
    /// </summary>
    public static CoinbaseEnvironment Testnet { get; }
        = new CoinbaseEnvironment(TradeEnvironmentNames.Testnet,
            CoinbaseApiAddresses.TestNet.RestClientAddress,
            CoinbaseApiAddresses.TestNet.SocketClientAddress
            );
}