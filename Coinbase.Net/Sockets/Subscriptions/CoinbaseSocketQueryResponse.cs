using Newtonsoft.Json;

namespace Coinbase.Net.Sockets.Subscriptions;

public class CoinbaseSocketQueryResponse
{
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("channels")]
    public IEnumerable<Channel> Channels { get; set; }
}

public class Channel
{
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("product_ids")]
    public IEnumerable<string> ProductIds { get; set; }
}