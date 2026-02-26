using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieMarketManagementSystem
{
    internal class SieMarketConfig
    {
        public int Id { get; set; }
        public decimal DiscountThreshold { get; set; } = 500m;
        public decimal DiscountValue { get; set; } = 0.90m;

    }
}
