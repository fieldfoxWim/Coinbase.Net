using Coinbase.Net.Interfaces.Clients.SpotAndMarginApi;

namespace Coinbase.Net.Interfaces.Clients;

public interface ICoinbaseRestClient
{/// <summary>
    /// Spot and Margin API endpoints
    /// </summary>
    ICoinbaseRestClientSpotAndMarginApi SpotAndMarginApi { get; }
}