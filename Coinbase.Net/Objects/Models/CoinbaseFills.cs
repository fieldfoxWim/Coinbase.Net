using Newtonsoft.Json;

namespace Coinbase.Net.Objects.Models;

public class CoinbaseFills
{
    /// <summary>
        /// Id of trade that created the fill.
        /// </summary>
        [JsonProperty("trade_id")]
        public int TradeId { get; set; }

        /// <summary>
        /// Book the order was placed on.
        /// </summary>
        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        /// <summary>
        /// UUID of the order.
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        /// <summary>
        /// Id of user's account.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// Profile ID that placed the order.
        /// </summary>
        [JsonProperty("profile_id")]
        public Guid ProfileId { get; set; }

        /// <summary>
        /// Liquidity type.
        /// </summary>
        [JsonProperty("liquidity")]
        public string Liquidity { get; set; }

        /// <summary>
        /// Price per unit of base currency.
        /// </summary>
        [JsonProperty("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Amount of base currency to buy/sell.
        /// </summary>
        [JsonProperty("size")]
        public decimal Size { get; set; }

        /// <summary>
        /// Fees paid on the current filled amount.
        /// </summary>
        [JsonProperty("fee")]
        public decimal Fee { get; set; }

        /// <summary>
        /// Timestamp of fill.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Side of the trade (buy/sell).
        /// </summary>
        [JsonProperty("side")]
        public string Side { get; set; }

        /// <summary>
        /// Indicates whether funds have been exchanged and settled.
        /// </summary>
        [JsonProperty("settled")]
        public bool Settled { get; set; }

        /// <summary>
        /// Volume in USD.
        /// </summary>
        [JsonProperty("usd_volume")]
        public decimal UsdVolume { get; set; }

        /// <summary>
        /// Market type which the order was filled in.
        /// </summary>
        [JsonProperty("market_type")]
        public string MarketType { get; set; }

        /// <summary>
        /// Funding currency which the order was filled in.
        /// </summary>
        [JsonProperty("funding_currency")]
        public string FundingCurrency { get; set; }
}