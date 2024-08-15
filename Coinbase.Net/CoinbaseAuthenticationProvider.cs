using System.Security.Cryptography;
using System.Text;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Objects;
using Newtonsoft.Json;

namespace Coinbase.Net;

public class CoinbaseAuthenticationProvider : AuthenticationProvider
{
    private new readonly CoinbaseApiCredentials _credentials;
    
    public CoinbaseAuthenticationProvider(CoinbaseApiCredentials credentials) : base(credentials)
    {
        _credentials = credentials;
    }
    
    public override void AuthenticateRequest(RestApiClient apiClient, Uri uri, HttpMethod method, IDictionary<string, object> uriParameters,
        IDictionary<string, object> bodyParameters, Dictionary<string, string> headers, bool auth, ArrayParametersSerialization arraySerialization,
        HttpMethodParameterPosition parameterPosition, RequestBodyFormat requestBodyFormat)
    {
        uriParameters = parameterPosition == HttpMethodParameterPosition.InUri ? new SortedDictionary<string, object>(uriParameters) : new SortedDictionary<string, object>();
        bodyParameters = parameterPosition == HttpMethodParameterPosition.InBody ? new SortedDictionary<string, object>(uriParameters) : new SortedDictionary<string, object>();
        headers = new Dictionary<string, string>();
        
        if (!auth)
            return;
        
        var timestamp = DateTimeOffset.Now.ToUnixTimeSeconds() ; // Convert.ToUInt64(GetTimestamp(apiClient).Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
        var body = bodyParameters.Any() ? JsonConvert.SerializeObject(bodyParameters) : string.Empty;
        var data = $"{timestamp}{method.ToString().ToUpper()}{uri.PathAndQuery}{body}";
        
        headers.Add("CB-ACCESS-KEY", _credentials.Key.GetString());
        headers.Add("CB-ACCESS-SIGN", GetSignHmacsha256(data));
        headers.Add("CB-ACCESS-TIMESTAMP", timestamp.ToString());
        headers.Add("CB-ACCESS-PASSPHRASE",_credentials.Passphrase.GetString());
    }

    private string GetSignHmacsha256(string data)
    {
        using var hmacshA256 = new HMACSHA256(Convert.FromBase64String(_credentials.Secret.GetString()));
        var hash = hmacshA256.ComputeHash(Encoding.UTF8.GetBytes(data));
        return BytesToBase64String(hash);
    }

   
}