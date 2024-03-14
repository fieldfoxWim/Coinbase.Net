using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;

namespace Coinbase.Net;

public class CoinbaseAuthenticationProvider : AuthenticationProvider
{
    public string GetApiKey() => _credentials.Key!.GetString();
    
    public CoinbaseAuthenticationProvider(ApiCredentials credentials) : base(credentials)
    {
    }

    public override void AuthenticateRequest(RestApiClient apiClient, Uri uri, HttpMethod method, Dictionary<string, object> providedParameters, bool auth,
        ArrayParametersSerialization arraySerialization, HttpMethodParameterPosition parameterPosition,
        out SortedDictionary<string, object> uriParameters, out SortedDictionary<string, object> bodyParameters, out Dictionary<string, string> headers)
    {
        throw new NotImplementedException();
    }
}