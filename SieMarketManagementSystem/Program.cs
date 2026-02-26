using System;
using System.Collections.Generic;

namespace SieMarketManagementSystem
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SieMarketConfig config = new SieMarketConfig();

            Customer customer1 = new Customer { CustomerId = 1, CustomerName = "Marcel Pop" };
            Customer customer2 = new Customer { CustomerId = 2, CustomerName = "Vasile Ionescu" };
            Customer customer3 = new Customer { CustomerId = 3, CustomerName = "Ion Popescu" };


            var marcelOrder = new Order
            {
                OrderId = 101,
                Customer = customer1
            };
            marcelOrder.AddItem(new OrderItem { ProductName = "Wireless Mouse", Quantity = 2, UnitPrice = 25m });
            marcelOrder.AddItem(new OrderItem { ProductName = "Mechanical Keyboard", Quantity = 1, UnitPrice = 100m });


            var vasileOrder = new Order
            {
                OrderId = 102,
                Customer = customer2
            };
            vasileOrder.AddItem(new OrderItem { ProductName = "Gaming Laptop", Quantity = 1, UnitPrice = 750m });
            vasileOrder.AddItem(new OrderItem { ProductName = "USB Hub", Quantity = 2, UnitPrice = 25m });

            var ionOrder1 = new Order
            {
                OrderId = 103,
                Customer = customer3
            };
            ionOrder1.AddItem(new OrderItem { ProductName = "Display", Quantity = 1, UnitPrice = 450m });
            ionOrder1.AddItem(new OrderItem { ProductName = "Wireless Mouse", Quantity = 1, UnitPrice = 25m });


            var ionOrder2 = new Order
            {
                OrderId = 104,
                Customer = customer3
            };
            ionOrder2.AddItem(new OrderItem { ProductName = "SSD", Quantity = 1, UnitPrice = 300m });
            ionOrder2.AddItem(new OrderItem { ProductName = "Mouse Pad", Quantity = 1, UnitPrice = 25m });

            var storeManager = new StoreManager(config);
            storeManager.AllOrders.Add(marcelOrder);
            storeManager.AllOrders.Add(vasileOrder);
            storeManager.AllOrders.Add(ionOrder1);
            storeManager.AllOrders.Add(ionOrder2);

            Console.WriteLine("Order values:");
            Console.WriteLine($"{marcelOrder.Customer.CustomerName}: {marcelOrder.CalculateFinalPrice(config):C}");
            Console.WriteLine($"{vasileOrder.Customer.CustomerName}: {vasileOrder.CalculateFinalPrice(config):C}");
            Console.WriteLine($"{ionOrder1.Customer.CustomerName}: {ionOrder1.CalculateFinalPrice(config):C}");
            Console.WriteLine($"{ionOrder2.Customer.CustomerName}: {ionOrder2.CalculateFinalPrice(config):C}");

            Console.WriteLine("\nTop spender:");
            string topSpender = storeManager.GetTopSpender();
            Console.WriteLine($"The customer who spent the most is: {topSpender}");

            Console.WriteLine("\nPopular products:");
            var popularProducts = storeManager.GetPopularProducts();
            foreach (var product in popularProducts)
            {
                Console.WriteLine($"{product.Key}: {product.Value} units sold");
            }
        }
    }
}
