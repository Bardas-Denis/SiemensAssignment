using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieMarketManagementSystem
{
    internal class OrderItem
    {
        public string ProductName { get; set; } = string.Empty;
        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set => _quantity = value > 0 ? value : throw new ArgumentException("Quantity must be at least 1.");
        }
        private decimal _unitPrice;
        public decimal UnitPrice
        {
            get => _unitPrice;
            set => _unitPrice = value >= 0 ? value : throw new ArgumentException("Price cannot be negative.");
        }
    }
}
