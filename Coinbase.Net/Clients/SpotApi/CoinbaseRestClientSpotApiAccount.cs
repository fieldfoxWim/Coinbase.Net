using Coinbase.Net.Interfaces.Clients.SpotApi;
using CryptoExchange.Net.Objects;
using Microsoft.Extensions.Logging;

namespace Coinbase.Net.Clients.SpotApi;

public class CoinbaseRestClientSpotApiAccount : ICoinbaseRestClientSpotApiAccount
{
    private const string AccountInfo = "coinbase-accounts";
    
    private readonly ILogger _logger;
    private readonly CoinbaseRestClientSpotApi _baseClient;
    internal CoinbaseRestClientSpotApiAccount(ILogger logger, CoinbaseRestClientSpotApi baseClient)
    {
        _logger = logger;
        _baseClient = baseClient;
    }
    
    public async Task<WebCallResult<IEnumerable<CoinbaseWallet>>> GetAccountInfoAsync(CancellationToken ct)
    {
        return await _baseClient.SendRequestInternal<IEnumerable<CoinbaseWallet>>(
            _baseClient.GetUrl(AccountInfo),  
            HttpMethod.Get, signed: true, cancellationToken: ct).ConfigureAwait(false);
    }
}