using Coinbase.Net.Interfaces.Clients.SpotAndMarginApi;
using Coinbase.Net.Interfaces.Clients.SpotApi;
using Coinbase.Net.Objects;
using Coinbase.Net.Objects.Models.Spot;
using CryptoExchange.Net.Objects;
using Microsoft.Extensions.Logging;

namespace Coinbase.Net.Clients.SpotApi;

public class CoinbaseRestClientSpotApiExchangeData : ICoinbaseRestClientSpotApiExchangeData
{
   
    // SPOT
    private const string AllCurrencies = "currencies";
    private const string CurrencyDetails = "currencies/{0}";
    private const string Products = "products";
    private const string Ticker = "products/{0}/ticker";
    
    
    private readonly ILogger _logger;
    private readonly CoinbaseRestClientSpotApi _baseClient;
    internal CoinbaseRestClientSpotApiExchangeData(ILogger logger, CoinbaseRestClientSpotApi baseClient)
    {
        _logger = logger;
        _baseClient = baseClient;
    }
    
    #region Spot Currencies
    /// <inheritdoc />
    public async Task<WebCallResult<List<CoinbaseCurrencyDetails>>> GetCurrenciesAsync(CancellationToken ct = default)
    {
        return await _baseClient.SendRequestInternal<List<CoinbaseCurrencyDetails>>(
            _baseClient.GetUrl(AllCurrencies),  
            HttpMethod.Get, ct).ConfigureAwait(false);
    }
    #endregion
    
    #region Spot Currency Detail
    /// <inheritdoc />
    public async Task<WebCallResult<CoinbaseCurrencyDetails>> GetCurrencyDetailsAsync(string currency, CancellationToken ct = default)
    {
        return await _baseClient.SendRequestInternal<CoinbaseCurrencyDetails>(
            _baseClient.GetUrl(string.Format(CurrencyDetails, currency)),  
            HttpMethod.Get, ct).ConfigureAwait(false);
    }

    public async Task<WebCallResult<IEnumerable<CoinbaseAssetDetails>>> GetProductsAsync(CancellationToken ct = default)
    {
        return await _baseClient.SendRequestInternal<IEnumerable<CoinbaseAssetDetails>>(_baseClient.GetUrl(Products), 
            HttpMethod.Get, ct).ConfigureAwait(false);
    }

    #endregion
    
    
    public async Task<WebCallResult<CoinbaseProductTick>> GetTickerAsync(string symbol, CancellationToken ct = default)
    {
        symbol.ValidateCoinbaseSymbol();

        return await _baseClient.SendRequestInternal<CoinbaseProductTick>(_baseClient.GetUrl(string.Format(Ticker,symbol)), HttpMethod.Get, ct, weight: 1).ConfigureAwait(false);
    }
}