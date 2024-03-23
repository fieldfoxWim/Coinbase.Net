using CryptoExchange.Net.CommonObjects;
using Newtonsoft.Json;

namespace Coinbase.Net.Objects;

public class CoinbaseProductTick : Ticker
{
    /// <summary>
    /// Gets or sets the trade ID.
    /// </summary>
    [JsonProperty("trade_id")]
    public long TradeId { get; set; }

    /// <summary>
    /// Gets or sets the price of the trade.
    /// </summary>
    [JsonProperty("price")]
    public string Price { get; set; }

    /// <summary>
    /// Gets or sets the size of the trade.
    /// </summary>
    [JsonProperty("size")]
    public string Size { get; set; }

    /// <summary>
    /// Gets or sets the timestamp of the trade.
    /// </summary>
    [JsonProperty("time")]
    public DateTime Time { get; set; }

    /// <summary>
    /// Gets or sets the bid price.
    /// </summary>
    [JsonProperty("bid")]
    public string Bid { get; set; }

    /// <summary>
    /// Gets or sets the ask price.
    /// </summary>
    [JsonProperty("ask")]
    public string Ask { get; set; }

    /// <summary>
    /// Gets or sets the trading volume.
    /// </summary>
    [JsonProperty("volume")]
    public string Volume { get; set; }

    /// <summary>
    /// Gets or sets the RFQ (Request for Quote) volume.
    /// </summary>
    [JsonProperty("rfq_volume")]
    public string RfqVolume { get; set; }

    /// <summary>
    /// Gets or sets the conversions volume.
    /// </summary>
    [JsonProperty("conversions_volume")]
    public string ConversionsVolume { get; set; }
}