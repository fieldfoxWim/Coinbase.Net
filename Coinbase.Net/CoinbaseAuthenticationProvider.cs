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
    
    public override void AuthenticateRequest(RestApiClient apiClient, Uri uri, HttpMethod method, ref IDictionary<string, object>? uriParameters,
        ref IDictionary<string, object>? bodyParameters, ref Dictionary<string, string>? headers, bool auth, ArrayParametersSerialization arraySerialization,
        HttpMethodParameterPosition parameterPosition, RequestBodyFormat requestBodyFormat)
    {
        headers = new Dictionary<string, string>();
        
        if (!auth)
            return;
        
        var timestamp = DateTimeOffset.Now.ToUnixTimeSeconds() ; // Convert.ToUInt64(GetTimestamp(apiClient).Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
        var body = bodyParameters != null ? bodyParameters.Any() ? JsonConvert.SerializeObject(bodyParameters) : string.Empty : string.Empty;
        var data = $"{timestamp}{method.ToString().ToUpper()}{uri.PathAndQuery}{body}";
        
        headers.Add("CB-ACCESS-KEY", _credentials.Key);
        headers.Add("CB-ACCESS-SIGN", GetSignHmacsha256(data));
        headers.Add("CB-ACCESS-TIMESTAMP", timestamp.ToString());
        headers.Add("CB-ACCESS-PASSPHRASE",_credentials.Passphrase!);
    }

    private string GetSignHmacsha256(string data)
    {
        using var hmacshA256 = new HMACSHA256(Convert.FromBase64String(_credentials.Secret));
        var hash = hmacshA256.ComputeHash(Encoding.UTF8.GetBytes(data));
        return BytesToBase64String(hash);
    }
    
}