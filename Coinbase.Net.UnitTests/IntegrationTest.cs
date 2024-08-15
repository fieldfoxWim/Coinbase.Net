using System.Net;
using Coinbase.Net.Clients;
using Coinbase.Net.Objects.Models.Spot;
using CryptoExchange.Net.Interfaces.CommonClients;
using CryptoExchange.Net.Objects.Sockets;
using NUnit.Framework;

namespace Coinbase.Net.UnitTests;

[TestFixture]
public class IntegrationTest
{
    [Test]
    public async Task CurrenciesTest()
    {
        var client = new CoinbaseRestClient(options => {  });
        var symbols = await client.SpotApi.ExchangeData.GetCurrenciesAsync();
        Assert.IsNotEmpty(symbols.ToString());
    }
    
    [TestCase("BTC")]
    [TestCase("EUR")]
    [TestCase("ETH")]
    [TestCase("USD")]
    public async Task CurrencyTest(string currency)
    {
        var client = new CoinbaseRestClient(options => {  });
        var symbol = await client.SpotApi.ExchangeData.GetCurrenciesAsync();
        Assert.IsNotNull(symbol.Data);
    }

    [Test]
    public async Task TickerTest()
    {
        var client = new CoinbaseSocketClient(options => {  });
        var symbols = await client.SpotApi.ExchangeData
            .SubscribeToBatchedTickerUpdatesAsync(new List<string>{"BTC-EUR"}, OnMessage);
        
        await Task.Delay(2000);

        Assert.IsNotNull(symbols);
    }

    [Test]
    public async Task GetSymbolsTest()
    {
        var client = new CoinbaseRestClient(options => {  });
        var symbols = await client.SpotApi.ExchangeData.GetProductsAsync();
        
        Assert.IsNotEmpty(symbols.Data);
    }
    
    [Test]
    [Ignore("long test")]
    public async Task BatchTickerTest()
    {
        var client = new CoinbaseSocketClient(options => {  });
        var symbols = await client.SpotApi.ExchangeData
            .SubscribeToBatchedTickerUpdatesAsync(new List<string>{"BTC-EUR", "BTC-USDT"}, OnMessage);
        
        await Task.Delay(10000);

        Assert.IsNotNull(symbols);
    }

    [Test]
    public async Task GetOpenOrdersTest()
    {
        var client = new CoinbaseRestClient(options =>
        {
            options.Environment = CoinbaseEnvironment.Live;
            options.ApiCredentials = new CoinbaseApiCredentials("c62ed0aa3f9b558e8adc8a24bc8ff1aa","tRxnjpCTNXtEO9u4ExCSyEfyxhgVTuqz7j7+uGcrpOSg2ZaWFhDHdq8Id7sOv2YmvTXimvYQyiKVmrf16oVTlg==", "b0a9rrdz9e9");
        });
        
        var orders = await ((ISpotClient)client.SpotApi).GetOpenOrdersAsync("BTC-EUR");
        
        Assert.AreEqual(orders.ResponseStatusCode, HttpStatusCode.OK);
    }

    private void OnMessage(DataEvent<CoinbaseTick> obj)
    {
        Assert.IsNotNull(obj.Data);
    }
    
    [Test]
    public async Task DeleteOrderTest()
    {
        var client = new CoinbaseRestClient(options =>
        {
            options.Environment = CoinbaseEnvironment.Live;
            options.ApiCredentials = new CoinbaseApiCredentials("4f672c388695967f302ab507444c7c17","w0i5kNODR5iHE4y6gjqvQ51+kK1cLsXYN+DauUOwU6syjQT+2ytmTb7CfrmK9jS/n4iAhz38SQt/YF/87IkYEA==", "4w9ql5bscow");
        });
        
        var order = await ((ISpotClient)client.SpotApi).CancelOrderAsync("0391dfb6-d98d-4e75-b4b0-288e8550e644");
        //var order = await ((ISpotClient)client.SpotApi).GetOrderAsync("0391dfb6-d98d-4e75-b4b0-288e8550e644");
        
        Assert.AreEqual(order.ResponseStatusCode, HttpStatusCode.OK);
    }
    
    [Test]
    public async Task GetBalanceTest()
    {
        // b4a6c4c7-47f0-4eda-9729-8e67ec70a0a0
        // organizations/441a61ad-3b60-48b8-9aca-b3b9e04829b3/apiKeys/b4a6c4c7-47f0-4eda-9729-8e67ec70a0a0
        
        // -----BEGIN EC PRIVATE KEY-----\nMHcCAQEEIGEb5+unzlDFsniDof+9JByw31uUJiOn23uB83B/wnqJoAoGCCqGSM49\nAwEHoUQDQgAE+aTmaZlon1zMlMTpAplhYE6Okgd9/sLCrhX68SrTTq4j5svXcwsm\nYHuzH0I3GQtyt/D4u8u3MV5LJDbsw2V/kA==\n-----END EC PRIVATE KEY-----\n
        
        var client = new CoinbaseRestClient(options =>
        {
            options.Environment = CoinbaseEnvironment.Live;
            options.ApiCredentials = new CoinbaseApiCredentials("c62ed0aa3f9b558e8adc8a24bc8ff1aa","tRxnjpCTNXtEO9u4ExCSyEfyxhgVTuqz7j7+uGcrpOSg2ZaWFhDHdq8Id7sOv2YmvTXimvYQyiKVmrf16oVTlg==", "b0a9rrdz9e9");
        });
        
        var balance = await ((ISpotClient)client.SpotApi).GetBalancesAsync();
        //var order = await ((ISpotClient)client.SpotApi).GetOrderAsync("0391dfb6-d98d-4e75-b4b0-288e8550e644");
        
        Assert.AreEqual(balance.ResponseStatusCode, HttpStatusCode.OK);
    }
    
}