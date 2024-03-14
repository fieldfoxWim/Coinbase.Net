using Coinbase.Net.Interfaces.Clients.SpotAndMarginApi;

namespace Coinbase.Net.Interfaces.Clients;

public interface ICoinbaseSocketClient
{
    ICoinbaseSocketClientSpotAndMarginApi SpotAndMarginApi { get; set; }
}