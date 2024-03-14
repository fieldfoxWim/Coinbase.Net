using Newtonsoft.Json;

namespace Coinbase.Net.Objects.Models.Spot;

public class CoinbaseTick
{
    public string Type { get; set; } = string.Empty;
    public long Sequence { get; set; }
    [JsonProperty("product_id")]
    public string ProductId { get; set; } = string.Empty;
    public string Price { get; set; } = string.Empty;
    [JsonProperty("open_24h")]
    public string Open24H { get; set; } = string.Empty;
    [JsonProperty("volume_24h")]
    public string Volume24H { get; set; } = string.Empty;
    [JsonProperty("low_24h")]
    public string Low24H { get; set; } = string.Empty;
    [JsonProperty("high_24h")]
    public string High24H { get; set; } = string.Empty;
    [JsonProperty("volume_30d")]
    public string Volume30D { get; set; } = string.Empty;
    [JsonProperty("best_bid")]
    public string BestBid { get; set; } = string.Empty;
    [JsonProperty("best_bid_size")]
    public string BestBidSize { get; set; } = string.Empty;
    [JsonProperty("best_ask")]
    public string BestAsk { get; set; } = string.Empty;
    [JsonProperty("best_ask_size")]
    public string BestAskSize { get; set; } = string.Empty;
    public string Side { get; set; } = string.Empty;
    public DateTime Time { get; set; }
    [JsonProperty("trade_id")]
    public long TradeId { get; set; }
    [JsonProperty("last_size")]
    public string LastSize { get; set; } = string.Empty;
}