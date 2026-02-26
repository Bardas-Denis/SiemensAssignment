using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieMarketManagementSystem
{
    internal class StoreManager
    {
        private readonly SieMarketConfig _config; 
        public List<Order> AllOrders { get; set; } = new List<Order>();

        public StoreManager(SieMarketConfig config)
        {
            _config = config;
        }

        public string? GetTopSpender()
        {
            if (AllOrders == null || !AllOrders.Any())
                return null;

            return AllOrders
                .GroupBy(order => order.Customer.CustomerName)
                .Select(group => new
                {
                    CustomerName = group.Key,
                    TotalSpent = group.Sum(order => order.CalculateFinalPrice(_config))
                })
                .OrderByDescending(customer => customer.TotalSpent)
                .FirstOrDefault()?.CustomerName;
        }

        public Dictionary<string, int> GetPopularProducts()
        {
            if (AllOrders == null || AllOrders.Count == 0)
                return new Dictionary<string, int>();

            return AllOrders
                .SelectMany(order => order.Items)
                .GroupBy(item => item.ProductName)
                .Select(group => new
                {
                    ProductName = group.Key,
                    TotalQuantity = group.Sum(item => item.Quantity)
                })
                .OrderByDescending(product => product.TotalQuantity)
                .ToDictionary(product => product.ProductName, product => product.TotalQuantity);
        }
    }
}
