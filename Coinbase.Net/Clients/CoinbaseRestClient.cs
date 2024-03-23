using Coinbase.Net.Clients.SpotApi;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using Coinbase.Net.Interfaces.Clients;
using Coinbase.Net.Interfaces.Clients.SpotAndMarginApi;
using Coinbase.Net.Interfaces.Clients.SpotApi;
using Coinbase.Net.Objects.Options;
using Microsoft.Extensions.Logging;

namespace Coinbase.Net.Clients;

/// <inheritdoc cref="ICoinbaseRestClient" />
public class CoinbaseRestClient : BaseRestClient, ICoinbaseRestClient
{
    #region Api clients

    /// <inheritdoc />
    public ICoinbaseRestClientSpotApi SpotApi { get; }
    #endregion
    
    #region constructor/destructor

    /// <summary>
    /// Create a new instance of the CoinbaseRestClient using provided options
    /// </summary>
    /// <param name="optionsDelegate">Option configuration delegate</param>
    public CoinbaseRestClient(Action<CoinbaseRestOptions> optionsDelegate) : this(null, null, optionsDelegate)
    {
    }

    /// <summary>
    /// Create a new instance of the CoinbaseRestClient using provided options
    /// </summary>
    public CoinbaseRestClient(ILoggerFactory? loggerFactory = null, HttpClient? httpClient = null) : this(httpClient, loggerFactory, null)
    {
    }

    /// <summary>
    /// Create a new instance of the CoinbaseRestClient using provided options
    /// </summary>
    /// <param name="optionsDelegate">Option configuration delegate</param>
    /// <param name="loggerFactory">The logger factory</param>
    /// <param name="httpClient">Http client for this client</param>
    public CoinbaseRestClient(HttpClient? httpClient, ILoggerFactory? loggerFactory, Action<CoinbaseRestOptions>? optionsDelegate = null) : base(loggerFactory, "Gate.io")
    {
        var options = CoinbaseRestOptions.Default.Copy();
        if (optionsDelegate != null)
            optionsDelegate(options);
        Initialize(options);

        SpotApi = AddApiClient(new CoinbaseRestClientSpotApi(_logger, httpClient, options));
       }

    #endregion
    
    /// <summary>
    /// Set the default options to be used when creating new clients
    /// </summary>
    /// <param name="optionsDelegate">Option configuration delegate</param>
    public static void SetDefaultOptions(Action<CoinbaseRestOptions> optionsDelegate)
    {
        var options = CoinbaseRestOptions.Default.Copy();
        optionsDelegate(options);
        CoinbaseRestOptions.Default = options;
    }
    
    /// <inheritdoc />
    public void SetApiCredentials(ApiCredentials credentials)
    {
        SpotApi.SetApiCredentials(credentials);
    }
}