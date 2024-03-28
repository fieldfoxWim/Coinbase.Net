using Newtonsoft.Json;

namespace Coinbase.Net.Objects;

public class CoinbaseAccount
{
    /// <summary>
    /// Gets or sets the unique identifier of the account.
    /// </summary>
    [JsonProperty("id")]
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the currency associated with the account.
    /// </summary>
    [JsonProperty("currency")]
    public string Currency { get; set; }

    /// <summary>
    /// Gets or sets the balance of the account.
    /// </summary>
    [JsonProperty("balance")]
    public decimal Balance { get; set; }

    /// <summary>
    /// Gets or sets the amount currently on hold in the account.
    /// </summary>
    [JsonProperty("hold")]
    public decimal Hold { get; set; }

    /// <summary>
    /// Gets or sets the available balance in the account.
    /// </summary>
    [JsonProperty("available")]
    public decimal Available { get; set; }

    /// <summary>
    /// Gets or sets the profile identifier associated with the account.
    /// </summary>
    [JsonProperty("profile_id")]
    public Guid ProfileId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether trading is enabled for the account.
    /// </summary>
    [JsonProperty("trading_enabled")]
    public bool TradingEnabled { get; set; }
}