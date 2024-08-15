using Coinbase.Net.Clients.SpotApi;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using Coinbase.Net.Interfaces.Clients;
using Coinbase.Net.Interfaces.Clients.SpotAndMarginApi;
using Coinbase.Net.Objects.Options;
using CryptoExchange.Net.Clients;
using Microsoft.Extensions.Logging;

namespace Coinbase.Net.Clients;

/// <inheritdoc cref="ICoinbaseSocketClient" />
public class CoinbaseSocketClient : BaseSocketClient, ICoinbaseSocketClient
{
    #region Api clients

    /// <inheritdoc />
    public ICoinbaseSocketClientSpotApi SpotApi { get; set; }
    
    #endregion
    
    public CoinbaseSocketClient(ILoggerFactory? logger, string name) : base(logger, name)
    {
    }
    
    #region constructor/destructor
    /// <summary>
    /// Create a new instance of BinanceSocketClient
    /// </summary>
    /// <param name="loggerFactory">The logger factory</param>
    public CoinbaseSocketClient(ILoggerFactory? loggerFactory = null) : this((x) => { }, loggerFactory)
    {
    }

    /// <summary>
    /// Create a new instance of BinanceSocketClient
    /// </summary>
    /// <param name="optionsDelegate">Option configuration delegate</param>
    public CoinbaseSocketClient(Action<CoinbaseSocketOptions> optionsDelegate) : this(optionsDelegate, null)
    {
    }

    /// <summary>
    /// Create a new instance of GateioSocketClient
    /// </summary>
    /// <param name="loggerFactory">The logger factory</param>
    /// <param name="optionsDelegate">Option configuration delegate</param>
    public CoinbaseSocketClient(Action<CoinbaseSocketOptions> optionsDelegate, ILoggerFactory? loggerFactory = null) : base(loggerFactory, "Gate.io")
    {
        var options = CoinbaseSocketOptions.Default.Copy();
        optionsDelegate(options);
        Initialize(options);

        SpotApi = AddApiClient(new CoinbaseSocketSpotApi(_logger, options));
    }
    #endregion
    
    /// <summary>
    /// Set the default options to be used when creating new clients
    /// </summary>
    /// <param name="optionsDelegate">Option configuration delegate</param>
    public static void SetDefaultOptions(Action<CoinbaseSocketOptions> optionsDelegate)
    {
        var options = CoinbaseSocketOptions.Default.Copy();
        optionsDelegate(options);
        CoinbaseSocketOptions.Default = options;
    }

    /// <inheritdoc />
    public void SetApiCredentials(ApiCredentials credentials)
    {
    }
}