using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieMarketManagementSystem
{
    internal class Order
    {
        public int OrderId { get; set; }
        public required Customer Customer { get; set; }

        private List<OrderItem> _items = new List<OrderItem>();
        public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();
        public void AddItem(OrderItem item)
        {
            if (item != null)
            {
                _items.Add(item);
            }
        }

        public decimal CalculateFinalPrice(SieMarketConfig config)
        {
            decimal totalValue = Items.Sum(item => item.Quantity * item.UnitPrice);

            if (totalValue > config.DiscountThreshold)
            {
                return totalValue * config.DiscountValue;
            }

            return totalValue;
        }
    }
}
