using Coinbase.Net.Converters;
using Coinbase.Net.Enums;
using Coinbase.Net.Interfaces.Clients.SpotApi;
using Coinbase.Net.Objects.Models;
using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Coinbase.Net.Clients.SpotApi;

public class CoinbaseRestClientSpotApiTrading : ICoinbaseRestClientSpotApiTrading
{
    // Orders
    private const string Orders = "orders";
    private const string Fills = "fills";
    private const string SingleOrder = "orders/{0}?market_type=spot";
    private const string Order = "orders/{0}?product_id={1}";
    
    private readonly CoinbaseRestClientSpotApi _baseClient;
    private readonly ILogger _logger;

    internal CoinbaseRestClientSpotApiTrading(ILogger logger, CoinbaseRestClientSpotApi baseClient)
    {
        _baseClient = baseClient;
        _logger = logger;
    }
    
    public async Task<WebCallResult<IEnumerable<CoinbaseFills>>> GetAllFillsAsync(CancellationToken ct)
    {
        return await _baseClient.SendRequestInternal<IEnumerable<CoinbaseFills>>(_baseClient.GetUrl(Fills), 
            HttpMethod.Get, ct, signed:true).ConfigureAwait(false);
    }
    
    public async Task<WebCallResult<IEnumerable<CoinbaseOrder>>> GetOpenOrdersAsync(string? symbol, CancellationToken ct)
    {
        symbol?.ValidateCoinbaseSymbol();

        var parameters = new Dictionary<string, object>();
        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("limit", 100);
        parameters.AddOptionalParameter("status", "open");
        

        return await _baseClient.SendRequestInternal<IEnumerable<CoinbaseOrder>>(_baseClient.GetUrl(Orders), 
            HttpMethod.Get, ct, parameters, true).ConfigureAwait(false);
    }
    
    public async Task<WebCallResult<IEnumerable<string>>> CancelAllOrdersAsync(CancellationToken ct)
    {
        return await _baseClient.SendRequestInternal<IEnumerable<string>>(_baseClient.GetUrl(Orders), 
            HttpMethod.Delete, ct, signed: true).ConfigureAwait(false);
    }
    
    public async Task<WebCallResult<IEnumerable<string>>> CancelAllOrdersForProductAsync(string symbol, CancellationToken ct)
    {
        symbol.ValidateCoinbaseSymbol();
        
        var parameters = new Dictionary<string, object>
        {
            { "product_id", symbol }
        };
        
        return await _baseClient.SendRequestInternal<IEnumerable<string>>(_baseClient.GetUrl(Orders), 
            HttpMethod.Delete, ct, parameters, postPosition:HttpMethodParameterPosition.InUri, signed: true).ConfigureAwait(false);
    }
    
    public async Task<WebCallResult<CoinbaseOrder>> CreateOrderAsync(string symbol,
        OrderSide side,
        OrderType type,
        decimal size,
        decimal? price,
        decimal? stopPrice = null,
        OrderTimeInForce timeInForce = OrderTimeInForce.GoodTillCanceled,
        bool? postOnly = null,
        decimal? maxFloor = null,
        OrderStop orderStop = OrderStop.Loss,
        decimal? stopLimitPrice = null,
        bool? useMarketFunds = null,
        CancellationToken ct = default)
    { 
        symbol.ValidateCoinbaseSymbol();
        
        var parameters = new Dictionary<string, object>
        {
            { "product_id", symbol },
            { "type", JsonConvert.SerializeObject(type, new OrderTypeConverter(false)) },
            { "side", JsonConvert.SerializeObject(side, new OrderSideConverter(false)) }
        };

        switch (type)
        {
            case OrderType.Limit:
                parameters.AddParameter("price", price);
                parameters.AddParameter("size", size);
                parameters.AddOptionalParameter("time_in_force", timeInForce);
                parameters.AddOptionalParameter("cancel_after", OrderCancelAfter.Min); //  Requires time_in_force to be GTT
                parameters.AddOptionalParameter("post_only", postOnly); // Invalid when time_in_force is IOC or FOK
                parameters.AddOptionalParameter("max_floor", maxFloor);
                break;
            case OrderType.Market:
                parameters.AddParameter(useMarketFunds.GetValueOrDefault() ? "funds" : "size", size);
                break;
            case OrderType.Stop:
                parameters.AddParameter("price", price);
                parameters.AddParameter("stop", orderStop);
                parameters.AddOptionalParameter("stop_price", stopPrice);
                parameters.AddOptionalParameter("stop_limit_price", stopLimitPrice);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }

        return await _baseClient.SendRequestInternal<CoinbaseOrder>(_baseClient.GetUrl(Orders), 
            HttpMethod.Post, ct, parameters, signed: true).ConfigureAwait(false);
    }
    
    public async Task<WebCallResult<CoinbaseOrder>> GetSingleOrderAsync(string orderId, CancellationToken ct)
    {
        return await _baseClient.SendRequestInternal<CoinbaseOrder>(_baseClient.GetUrl(string.Format(SingleOrder, orderId)), 
            HttpMethod.Get, ct, signed: true).ConfigureAwait(false);
    }
    
    public async Task<WebCallResult<string>> CancelOrderAsync(string orderId, CancellationToken ct)
    {
        
        return await _baseClient.SendRequestInternal<string>(_baseClient.GetUrl(string.Format(Order, orderId, "USDT-EUR")), 
            HttpMethod.Delete, ct, signed: true).ConfigureAwait(false);
    }
}