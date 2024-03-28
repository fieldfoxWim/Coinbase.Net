using Coinbase.Net.Interfaces.Clients.SpotApi;
using Coinbase.Net.Objects;
using CryptoExchange.Net.Objects;
using Microsoft.Extensions.Logging;

namespace Coinbase.Net.Clients.SpotApi;

public class CoinbaseRestClientSpotApiAccount : ICoinbaseRestClientSpotApiAccount
{
    private const string Wallets = "coinbase-accounts";
    private const string Account = "accounts";
    
    private readonly ILogger _logger;
    private readonly CoinbaseRestClientSpotApi _baseClient;
    internal CoinbaseRestClientSpotApiAccount(ILogger logger, CoinbaseRestClientSpotApi baseClient)
    {
        _logger = logger;
        _baseClient = baseClient;
    }
    
    public async Task<WebCallResult<IEnumerable<CoinbaseWallet>>> GetWalletsAsync(CancellationToken ct)
    {
        return await _baseClient.SendRequestInternal<IEnumerable<CoinbaseWallet>>(
            _baseClient.GetUrl(Wallets),  
            HttpMethod.Get, signed: true, cancellationToken: ct).ConfigureAwait(false);
    }
    
    public async Task<WebCallResult<IEnumerable<CoinbaseAccount>>> GetAccountInfoAsync(CancellationToken ct)
    {
        return await _baseClient.SendRequestInternal<IEnumerable<CoinbaseAccount>>(
            _baseClient.GetUrl(Account),  
            HttpMethod.Get, signed: true, cancellationToken: ct).ConfigureAwait(false);
    }
}