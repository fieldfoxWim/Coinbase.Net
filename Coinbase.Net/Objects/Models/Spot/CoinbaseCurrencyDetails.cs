using Newtonsoft.Json;

namespace Coinbase.Net.Objects.Models.Spot;

public class CoinbaseCurrencyDetails
{
        public string Id { get; set; }
        public string Name { get; set; }
        [JsonProperty("min_size")]
        public string MinSize { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        [JsonProperty("max_precision")]
        public string MaxPrecision { get; set; }
        [JsonProperty("convertible_to")]
        public List<string> ConvertibleTo { get; set; }
        //public Details details { get; set; }
        [JsonProperty("default_network")]
        public string DefaultNetwork { get; set; }
        //public List<SupportedNetwork> supported_networks { get; set; }
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
}