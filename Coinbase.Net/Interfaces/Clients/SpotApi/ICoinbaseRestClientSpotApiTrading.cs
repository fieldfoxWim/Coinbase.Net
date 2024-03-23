using Coinbase.Net.Clients.SpotApi;
using Coinbase.Net.Enums;
using Coinbase.Net.Objects.Models;
using CryptoExchange.Net.Objects;

namespace Coinbase.Net.Interfaces.Clients.SpotApi;

public interface ICoinbaseRestClientSpotApiTrading
{
    Task<WebCallResult<IEnumerable<CoinbaseFills>>> GetAllFillsAsync(CancellationToken ct = default);
    Task<WebCallResult<IEnumerable<CoinbaseOrder>>> GetOpenOrdersAsync(string? symbol, CancellationToken ct = default);
    Task<WebCallResult<IEnumerable<string>>> CancelAllOrdersAsync(CancellationToken ct = default);
    Task<WebCallResult<IEnumerable<string>>> CancelAllOrdersForProductAsync(string symbol,
        CancellationToken ct = default);

    Task<WebCallResult<CoinbaseOrder>> CreateOrderAsync(string symbol,
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
        CancellationToken ct = default);
    Task<WebCallResult<CoinbaseOrder>> GetSingleOrderAsync(string orderId, CancellationToken ct = default);
    Task<WebCallResult<string>> CancelOrderAsync(string orderId, CancellationToken ct = default);
}