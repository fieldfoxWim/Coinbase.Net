using Coinbase.Net.Objects;
using Coinbase.Net.Objects.Models.Spot;
using CryptoExchange.Net.Objects;

namespace Coinbase.Net.Interfaces.Clients.SpotApi;

public interface ICoinbaseRestClientSpotApiExchangeData
{
    /// <inheritdoc />
    Task<WebCallResult<List<CoinbaseCurrencyDetails>>> GetCurrenciesAsync(CancellationToken ct = default);

    /// <inheritdoc />
    Task<WebCallResult<CoinbaseCurrencyDetails>> GetCurrencyDetailsAsync(string currency, CancellationToken ct = default);
    
    Task<WebCallResult<IEnumerable<CoinbaseAssetDetails>>> GetProductsAsync(CancellationToken ct = default);

    Task<WebCallResult<CoinbaseProductTick>> GetTickerAsync(string symbol, CancellationToken ct = default);
}
