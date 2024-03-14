using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.CommonObjects;
using CryptoExchange.Net.Interfaces.CommonClients;
using CryptoExchange.Net.Objects;
using Coinbase.Net.Interfaces.Clients.SpotAndMarginApi;
using Coinbase.Net.Objects.Options;
using Microsoft.Extensions.Logging;

namespace Coinbase.Net.Clients.SpotAndMarginApi;

/// <inheritdoc cref="ICoinbaseSpotAndMarginApi" />
public class CoinbaseRestClientSpotAndMarginApi : RestApiClient, ICoinbaseRestClientSpotAndMarginApi, ISpotClient
{
    #region fields 
    /// <inheritdoc />
    public new CoinbaseRestApiOptions ApiOptions => (CoinbaseRestApiOptions)base.ApiOptions;
    /// <inheritdoc />
    public new CoinbaseRestOptions ClientOptions => (CoinbaseRestOptions)base.ClientOptions;
    #endregion
    
    #region Api clients
    /// <inheritdoc />
    public ICoinbaseRestClientSpotApiExchangeData ExchangeData { get; }
    
    public string ExchangeName => "Gate.io";
    #endregion
    
    public CoinbaseRestClientSpotAndMarginApi(ILogger logger, HttpClient? httpClient, CoinbaseRestOptions options) 
        : base(logger, httpClient, options.Environment.SpotAndMarginRestAddress, options, options.SpotAndMarginOptions)
    {
        ExchangeData = new CoinbaseRestClientSpotApiExchangeData(logger, this);
    }
    
    internal Uri GetUrl(string endpoint)
    {
        return new Uri(BaseAddress.AppendPath(endpoint));
    }

    protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
    {
        throw new NotImplementedException();
    }

    public override TimeSyncInfo? GetTimeSyncInfo()
    {
        throw new NotImplementedException();
    }

    public override TimeSpan? GetTimeOffset()
    {
        throw new NotImplementedException();
    }

    public string GetSymbolName(string baseAsset, string quoteAsset)
    {
        return $"{baseAsset}-{quoteAsset}".ToUpper();
    }

    public async Task<WebCallResult<IEnumerable<Symbol>>> GetSymbolsAsync(CancellationToken ct = new CancellationToken())
    {
        var assets = await ExchangeData.GetProductsAsync(ct: ct).ConfigureAwait(false);
        if (!assets)
            return assets.As<IEnumerable<Symbol>>(null);

        return assets.As(assets.Data.Select(s =>
            new Symbol()
            {
                SourceObject = s,
                Name = s.DisplayName,
                MinTradeQuantity = Convert.ToDecimal(s.BaseIncrement)
            }));
    }
    
    public async Task<WebCallResult<Symbol>> GetSymbolsAsync(string currency, CancellationToken ct = new CancellationToken())
    {
        var currencyDetails = await ExchangeData.GetCurrencyDetailsAsync(currency, ct: ct).ConfigureAwait(false);
        if (!currencyDetails)
            return currencyDetails.As<Symbol>(null);

        return currencyDetails.As(new Symbol
            {
                SourceObject = currencyDetails.Data,
                Name = currencyDetails.Data.Id
            });
    }

    public Task<WebCallResult<Ticker>> GetTickerAsync(string symbol, CancellationToken ct = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task<WebCallResult<IEnumerable<Ticker>>> GetTickersAsync(CancellationToken ct = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task<WebCallResult<IEnumerable<Kline>>> GetKlinesAsync(string symbol, TimeSpan timespan, DateTime? startTime = null, DateTime? endTime = null,
        int? limit = null, CancellationToken ct = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task<WebCallResult<OrderBook>> GetOrderBookAsync(string symbol, CancellationToken ct = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task<WebCallResult<IEnumerable<Trade>>> GetRecentTradesAsync(string symbol, CancellationToken ct = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task<WebCallResult<IEnumerable<Balance>>> GetBalancesAsync(string? accountId = null, CancellationToken ct = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task<WebCallResult<Order>> GetOrderAsync(string orderId, string? symbol = null, CancellationToken ct = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task<WebCallResult<IEnumerable<UserTrade>>> GetOrderTradesAsync(string orderId, string? symbol = null, CancellationToken ct = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task<WebCallResult<IEnumerable<Order>>> GetOpenOrdersAsync(string? symbol = null, CancellationToken ct = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task<WebCallResult<IEnumerable<Order>>> GetClosedOrdersAsync(string? symbol = null, CancellationToken ct = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task<WebCallResult<OrderId>> CancelOrderAsync(string orderId, string? symbol = null, CancellationToken ct = new CancellationToken())
    {
        throw new NotImplementedException();
    }
    
    public event Action<OrderId>? OnOrderPlaced;
    public event Action<OrderId>? OnOrderCanceled;

    public Task<WebCallResult<OrderId>> PlaceOrderAsync(string symbol, CommonOrderSide side, CommonOrderType type, decimal quantity, decimal? price = null,
        string? accountId = null, string? clientOrderId = null, CancellationToken ct = new CancellationToken())
    {
        throw new NotImplementedException();
    }
    
    internal async Task<WebCallResult<T>> SendRequestInternal<T>(Uri uri, HttpMethod method, CancellationToken cancellationToken,
        Dictionary<string, object>? parameters = null, bool signed = false, HttpMethodParameterPosition? postPosition = null,
        ArrayParametersSerialization? arraySerialization = null, int weight = 1, bool ignoreRateLimit = false) where T : class
    {
        var result = await SendRequestAsync<T>(uri, 
            method, cancellationToken, parameters, signed, 
            postPosition, arraySerialization, weight, 
            additionalHeaders: new Dictionary<string, string>
            {
                //{"Content-Type", "application/json"}, 
                { "User-Agent", Guid.NewGuid().ToString() }
            },
            ignoreRatelimit: ignoreRateLimit).ConfigureAwait(false);
        return result;                    
    }
}