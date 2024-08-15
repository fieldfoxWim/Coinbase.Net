using Coinbase.Net.Enums;
using CryptoExchange.Net.Converters.JsonNet;

namespace Coinbase.Net.Converters
{
    internal class OrderStatusConverter : BaseConverter<OrderStatus>
    {
        public OrderStatusConverter(): this(true) { }
        public OrderStatusConverter(bool quotes) : base(quotes) { }

        protected override List<KeyValuePair<OrderStatus, string>> Mapping => new()
        {
            new KeyValuePair<OrderStatus, string>(OrderStatus.Active, "active"),
            new KeyValuePair<OrderStatus, string>(OrderStatus.All, "all"),
            new KeyValuePair<OrderStatus, string>(OrderStatus.Done, "done"),
            new KeyValuePair<OrderStatus, string>(OrderStatus.Open, "open"),
            new KeyValuePair<OrderStatus, string>(OrderStatus.Received, "received"),
            new KeyValuePair<OrderStatus, string>(OrderStatus.Pending, "pending"),
            new KeyValuePair<OrderStatus, string>(OrderStatus.Rejected, "rejected"),
        };
    }
}
