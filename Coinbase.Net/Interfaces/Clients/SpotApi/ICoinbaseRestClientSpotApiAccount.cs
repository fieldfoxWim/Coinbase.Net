using Coinbase.Net.Clients.SpotApi;
using CryptoExchange.Net.Objects;

namespace Coinbase.Net.Interfaces.Clients.SpotApi;

public interface ICoinbaseRestClientSpotApiAccount
{

    Task<WebCallResult<IEnumerable<CoinbaseWallet>>> GetAccountInfoAsync(CancellationToken ct);
}