using System.Security;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;

namespace Coinbase.Net;

public class CoinbaseApiCredentials : ApiCredentials
{
    /// <summary>The passphrase to authenticate requests</summary>
    public string? Passphrase { get; }
    
    public CoinbaseApiCredentials(string key, string secret, string passphrase) : base(key, secret)
    {
        Passphrase = passphrase;
    }

    public CoinbaseApiCredentials(string key, string secret, string? passphrase, ApiCredentialsType credentialsType) : base(key, secret, credentialsType)
    {
        Passphrase = passphrase;
    }

    public CoinbaseApiCredentials(Stream inputStream, string? passphrase, string? identifierKey = null, string? identifierSecret = null) : base(inputStream, identifierKey, identifierSecret)
    {
        Passphrase = passphrase ?? string.Empty;
    }

    public override ApiCredentials Copy()
    {
        return new CoinbaseApiCredentials(Key, Secret, Passphrase, CredentialType);
    }
}