using Coinbase.Net.Enums;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Converters.JsonNet;

namespace Coinbase.Net.Converters
{
    internal class OrderTimeInForceConverter : BaseConverter<OrderTimeInForce>
    {
        public OrderTimeInForceConverter(): this(true) { }
        public OrderTimeInForceConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<OrderTimeInForce, string>> Mapping => new()
        {
            new KeyValuePair<OrderTimeInForce, string>(OrderTimeInForce.FillOrKill, "FOK"),
            new KeyValuePair<OrderTimeInForce, string>(OrderTimeInForce.GoodTillCanceled, "GTC"),
            new KeyValuePair<OrderTimeInForce, string>(OrderTimeInForce.GoodTillTime, "GTT"),
            new KeyValuePair<OrderTimeInForce, string>(OrderTimeInForce.ImmediateOrCancel, "IOC"),
          
        };
    }
}
