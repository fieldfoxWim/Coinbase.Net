using CryptoExchange.Net.CommonObjects;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;

namespace Coinbase.Net.Interfaces.Clients.SpotAndMarginApi;

public interface ICoinbaseRestClientSpotAndMarginApi : IRestApiClient, IDisposable
{
    Task<WebCallResult<IEnumerable<Symbol>>> GetSymbolsAsync(CancellationToken ct = new CancellationToken());
    Task<WebCallResult<Symbol>> GetSymbolsAsync(string currency, CancellationToken ct = new CancellationToken());
}