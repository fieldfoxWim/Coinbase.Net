using Coinbase.Net.Clients;
using Coinbase.Net.Objects.Models.Spot;
using CryptoExchange.Net.Sockets;
using NUnit.Framework;

namespace Coinbase.Net.UnitTests;

[TestFixture]
public class IntegrationTest
{
    [Test]
    public async Task CurrenciesTest()
    {
        var client = new CoinbaseRestClient(options => {  });
        var symbols = await client.SpotAndMarginApi.GetSymbolsAsync();
        Assert.IsNotEmpty(symbols.ToString());
    }
    
    [TestCase("BTC")]
    [TestCase("EUR")]
    [TestCase("ETH")]
    [TestCase("USD")]
    public async Task CurrencyTest(string currency)
    {
        var client = new CoinbaseRestClient(options => {  });
        var symbol = await client.SpotAndMarginApi.GetSymbolsAsync(currency);
        Assert.IsNotNull(symbol.Data.Name);
    }
    
    [Test]
    public async Task TickerTest()
    {
        var client = new CoinbaseSocketClient(options => {  });
        var symbols = await client.SpotAndMarginApi.ExchangeData
            .SubscribeToTickerUpdatesAsync("BTC-EUR", OnMessage);
        
        await Task.Delay(100000);

        Assert.IsNotNull(symbols);
    }
    
    [Test]
    public async Task BatchTickerTest()
    {
        var client = new CoinbaseSocketClient(options => {  });
        var symbols = await client.SpotAndMarginApi.ExchangeData
            .SubscribeToBatchedTickerUpdatesAsync(new List<string>{"BTC-EUR", "BTC-USDT"}, OnMessage);
        
        await Task.Delay(10000);

        Assert.IsNotNull(symbols);
    }
    
    private void OnMessage(DataEvent<CoinbaseTick> obj)
    {
        Assert.IsNotNull(obj.Data);
    }
}