using CryptoExchange.Net.Objects;
using Coinbase.Net.Objects.Models.Spot;

namespace Coinbase.Net.Interfaces.Clients.SpotAndMarginApi;

public interface ICoinbaseRestClientSpotApiExchangeData
{
    /// <inheritdoc />
    Task<WebCallResult<List<CoinbaseCurrencyDetails>>> GetCurrenciesAsync(CancellationToken ct = default);

    /// <inheritdoc />
    Task<WebCallResult<CoinbaseCurrencyDetails>> GetCurrencyDetailsAsync(string currency, CancellationToken ct = default);
    
    Task<WebCallResult<IEnumerable<CoinbaseAssetDetails>>> GetProductsAsync(CancellationToken ct = default);
}