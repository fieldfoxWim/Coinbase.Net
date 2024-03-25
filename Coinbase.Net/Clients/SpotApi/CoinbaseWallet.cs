using Newtonsoft.Json;

namespace Coinbase.Net.Clients.SpotApi;

public class CoinbaseWallet
{
    /// <summary>
    /// Gets or sets a value indicating whether the wallet is available on consumer.
    /// </summary>
    [JsonProperty("available_on_consumer")]
    public bool AvailableOnConsumer { get; set; }

    /// <summary>
    /// Gets or sets the hold balance of the wallet.
    /// </summary>
    [JsonProperty("hold_balance")]
    public string HoldBalance { get; set; }

    /// <summary>
    /// Gets or sets the ID of the wallet.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the currency of the hold balance.
    /// </summary>
    [JsonProperty("hold_currency")]
    public string HoldCurrency { get; set; }

    /// <summary>
    /// Gets or sets the balance of the wallet.
    /// </summary>
    [JsonProperty("balance")]
    public string Balance { get; set; }

    /// <summary>
    /// Gets or sets the currency of the wallet.
    /// </summary>
    [JsonProperty("currency")]
    public string Currency { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the wallet is primary.
    /// </summary>
    [JsonProperty("primary")]
    public bool Primary { get; set; }

    /// <summary>
    /// Gets or sets the name of the wallet.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the type of the wallet.
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the wallet is active.
    /// </summary>
    [JsonProperty("active")]
    public bool Active { get; set; }
}