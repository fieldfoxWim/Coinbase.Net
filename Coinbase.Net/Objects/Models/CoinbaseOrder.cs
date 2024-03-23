using Coinbase.Net.Converters;
using Coinbase.Net.Enums;
using Newtonsoft.Json;

namespace Coinbase.Net.Objects.Models;

public class CoinbaseOrder
{
    /// <summary>
    /// Unique identifier for the order.
    /// </summary>
    [JsonProperty("id")]
    public Guid Id { get; set; }

    /// <summary>
    /// Price of the order.
    /// </summary>
    [JsonProperty("price")]
    public decimal Price { get; set; }

    /// <summary>
    /// Size of the order.
    /// </summary>
    [JsonProperty("size")]
    public decimal Size { get; set; }

    /// <summary>
    /// Product ID associated with the order.
    /// </summary>
    [JsonProperty("product_id")]
    public string ProductId { get; set; }

    /// <summary>
    /// Profile ID associated with the order.
    /// </summary>
    [JsonProperty("profile_id")]
    public Guid ProfileId { get; set; }

    /// <summary>
    /// Side of the order (buy/sell).
    /// </summary>
    [JsonProperty("side"), JsonConverter(typeof(OrderSideConverter))]
    public OrderSide Side { get; set; }

    /// <summary>
    /// Type of the order.
    /// </summary>
    [JsonProperty("type"), JsonConverter(typeof(OrderTypeConverter))]
    public OrderType Type { get; set; }

    /// <summary>
    /// Time in force for the order.
    /// </summary>
    [JsonProperty("time_in_force"), JsonConverter(typeof(OrderTimeInForceConverter))]
    public OrderTimeInForce TimeInForce { get; set; }

    /// <summary>
    /// Indicates whether the order is post-only.
    /// </summary>
    [JsonProperty("post_only")]
    public bool PostOnly { get; set; }

    /// <summary>
    /// Maximum floor for the order.
    /// </summary>
    [JsonProperty("max_floor")]
    public int MaxFloor { get; set; }

    /// <summary>
    /// Timestamp when the order was created.
    /// </summary>
    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Fill fees associated with the order.
    /// </summary>
    [JsonProperty("fill_fees")]
    public decimal FillFees { get; set; }

    /// <summary>
    /// Filled size of the order.
    /// </summary>
    [JsonProperty("filled_size")]
    public decimal FilledSize { get; set; }

    /// <summary>
    /// Executed value of the order.
    /// </summary>
    [JsonProperty("executed_value")]
    public decimal ExecutedValue { get; set; }

    /// <summary>
    /// Status of the order.
    /// </summary>
    [JsonProperty("status"), JsonConverter(typeof(OrderStatusConverter))]
    public OrderStatus Status { get; set; }

    /// <summary>
    /// Indicates whether the order is settled.
    /// </summary>
    [JsonProperty("settled")]
    public bool Settled { get; set; }
}