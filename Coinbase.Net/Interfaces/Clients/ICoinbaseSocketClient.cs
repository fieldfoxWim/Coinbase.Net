using Coinbase.Net.Interfaces.Clients.SpotAndMarginApi;

namespace Coinbase.Net.Interfaces.Clients;

public interface ICoinbaseSocketClient
{
    ICoinbaseSocketClientSpotApi SpotApi { get; set; }
}