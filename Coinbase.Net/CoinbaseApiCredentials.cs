using System.Security;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;

namespace Coinbase.Net;

public class CoinbaseApiCredentials : ApiCredentials
{
    /// <summary>The passphrase to authenticate requests</summary>
    public SecureString? Passphrase { get; }
    
    public CoinbaseApiCredentials(SecureString key, SecureString secret, SecureString passphrase) : base(key, secret)
    {
        Passphrase = passphrase;
    }

    public CoinbaseApiCredentials(SecureString key, SecureString secret, SecureString? passphrase, ApiCredentialsType credentialsType) : base(key, secret, credentialsType)
    {
        Passphrase = passphrase;
    }

    public CoinbaseApiCredentials(string key, string secret, string passphrase) : base(key, secret)
    {
        Passphrase = passphrase.ToSecureString();
    }

    public CoinbaseApiCredentials(string key, string secret,  string passphrase, ApiCredentialsType credentialsType) 
        : base(key, secret, credentialsType)
    {
        Passphrase = passphrase.ToSecureString();;
    }

    public CoinbaseApiCredentials(Stream inputStream, string? passphrase, string? identifierKey = null, string? identifierSecret = null) : base(inputStream, identifierKey, identifierSecret)
    {
        Passphrase = (passphrase ?? string.Empty).ToSecureString();
    }

    public override ApiCredentials Copy()
    {
        return new CoinbaseApiCredentials(Key.GetString(), Secret.GetString(), Passphrase.GetString(), this.CredentialType);
    }
}