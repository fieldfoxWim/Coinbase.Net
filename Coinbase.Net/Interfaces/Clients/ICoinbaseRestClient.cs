using Coinbase.Net.Interfaces.Clients.SpotAndMarginApi;
using Coinbase.Net.Interfaces.Clients.SpotApi;

namespace Coinbase.Net.Interfaces.Clients;

public interface ICoinbaseRestClient
{/// <summary>
    /// Spot and Margin API endpoints
    /// </summary>
    ICoinbaseRestClientSpotApi SpotApi { get; }
}