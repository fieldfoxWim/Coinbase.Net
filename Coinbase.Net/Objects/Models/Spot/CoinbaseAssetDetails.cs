using Newtonsoft.Json;

namespace Coinbase.Net.Objects.Models.Spot;

public class CoinbaseAssetDetails
{
    /// <summary>
    /// Unique identifier for the trading pair.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }

    /// <summary>
    /// Base currency of the trading pair.
    /// </summary>
    [JsonProperty("base_currency")]
    public string BaseCurrency { get; set; }

    /// <summary>
    /// Quote currency of the trading pair.
    /// </summary>
    [JsonProperty("quote_currency")]
    public string QuoteCurrency { get; set; }

    /// <summary>
    /// Min order price (a.k.a. price increment).
    /// </summary>
    [JsonProperty("quote_increment")]
    public string QuoteIncrement { get; set; }

    /// <summary>
    /// Min order quantity (a.k.a. quantity increment).
    /// </summary>
    [JsonProperty("base_increment")]
    public string BaseIncrement { get; set; }

    /// <summary>
    /// Display name of the trading pair.
    /// </summary>
    [JsonProperty("display_name")]
    public string DisplayName { get; set; }

    /// <summary>
    /// Minimum funds required to place an order.
    /// </summary>
    [JsonProperty("min_market_funds")]
    public string MinMarketFunds { get; set; }

    /// <summary>
    /// Indicates whether margin trading is enabled for the trading pair.
    /// </summary>
    [JsonProperty("margin_enabled")]
    public bool MarginEnabled { get; set; }

    /// <summary>
    /// Indicates whether only post-only orders are allowed.
    /// </summary>
    [JsonProperty("post_only")]
    public bool PostOnly { get; set; }

    /// <summary>
    /// Indicates whether only limit orders are allowed.
    /// </summary>
    [JsonProperty("limit_only")]
    public bool LimitOnly { get; set; }

    /// <summary>
    /// Indicates whether only cancel-only orders are allowed.
    /// </summary>
    [JsonProperty("cancel_only")]
    public bool CancelOnly { get; set; }

    /// <summary>
    /// Current status of the trading pair.
    /// </summary>
    [JsonProperty("status")]
    public string Status { get; set; }

    /// <summary>
    /// Additional message regarding the status of the trading pair.
    /// </summary>
    [JsonProperty("status_message")]
    public string StatusMessage { get; set; }

    /// <summary>
    /// Indicates whether trading is disabled for the trading pair.
    /// </summary>
    [JsonProperty("trading_disabled")]
    public bool TradingDisabled { get; set; }

    /// <summary>
    /// Indicates whether the quote currency is a stablecoin.
    /// </summary>
    [JsonProperty("fx_stablecoin")]
    public bool FxStablecoin { get; set; }

    /// <summary>
    /// Max slippage percentage for the trading pair.
    /// </summary>
    [JsonProperty("max_slippage_percentage")]
    public string MaxSlippagePercentage { get; set; }

    /// <summary>
    /// Indicates whether auction mode is enabled for the trading pair.
    /// </summary>
    [JsonProperty("auction_mode")]
    public bool AuctionMode { get; set; }

    /// <summary>
    /// Percentage to calculate highest price for limit buy order (Stable coin trading pair only).
    /// </summary>
    [JsonProperty("high_bid_limit_percentage")]
    public string HighBidLimitPercentage { get; set; }
}