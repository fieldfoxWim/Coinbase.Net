using System.Globalization;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using Coinbase.Net.Interfaces.Clients.SpotAndMarginApi;
using Coinbase.Net.Objects.Models.Spot;
using Microsoft.Extensions.Logging;

namespace Coinbase.Net.Clients.SpotAndMarginApi;

public class CoinbaseRestClientSpotApiExchangeData : ICoinbaseRestClientSpotApiExchangeData
{

    private const string marginApi = "margin";
    
    // SPOT
    private const string allCurrencies = "currencies";
    private const string currencyDetails = "currencies/{0}";
    private const string products = "products";
    
    // MARGIN

    
    
    private readonly ILogger _logger;
    private readonly CoinbaseRestClientSpotAndMarginApi _baseClient;
    internal CoinbaseRestClientSpotApiExchangeData(ILogger logger, CoinbaseRestClientSpotAndMarginApi baseClient)
    {
        _logger = logger;
        _baseClient = baseClient;
    }
    
    #region Spot Currencies
    /// <inheritdoc />
    public async Task<WebCallResult<List<CoinbaseCurrencyDetails>>> GetCurrenciesAsync(CancellationToken ct = default)
    {
        return await _baseClient.SendRequestInternal<List<CoinbaseCurrencyDetails>>(
            _baseClient.GetUrl(allCurrencies),  
            HttpMethod.Get, ct).ConfigureAwait(false);
    }
    #endregion
    
    #region Spot Currency Detail
    /// <inheritdoc />
    public async Task<WebCallResult<CoinbaseCurrencyDetails>> GetCurrencyDetailsAsync(string currency, CancellationToken ct = default)
    {
        return await _baseClient.SendRequestInternal<CoinbaseCurrencyDetails>(
            _baseClient.GetUrl(string.Format(currencyDetails, currency)),  
            HttpMethod.Get, ct).ConfigureAwait(false);
    }

    public async Task<WebCallResult<IEnumerable<CoinbaseAssetDetails>>> GetProductsAsync(CancellationToken ct = default)
    {
        return await _baseClient.SendRequestInternal<IEnumerable<CoinbaseAssetDetails>>(_baseClient.GetUrl(products), 
            HttpMethod.Get, ct).ConfigureAwait(false);
    }

    #endregion
}