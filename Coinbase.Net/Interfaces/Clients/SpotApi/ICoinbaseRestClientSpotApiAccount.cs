using Coinbase.Net.Clients.SpotApi;
using Coinbase.Net.Objects;
using CryptoExchange.Net.Objects;

namespace Coinbase.Net.Interfaces.Clients.SpotApi;

public interface ICoinbaseRestClientSpotApiAccount
{

    Task<WebCallResult<IEnumerable<CoinbaseWallet>>> GetWalletsAsync(CancellationToken ct);
    Task<WebCallResult<IEnumerable<CoinbaseAccount>>> GetAccountInfoAsync(CancellationToken ct);
    
}