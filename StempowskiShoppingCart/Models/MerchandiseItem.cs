using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StempowskiShoppingCart.Models
{
    public class MerchandiseItem
    {
        public string? ItemName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsTaxExempt { get; set; }
        public bool IsImported { get; set; }
        public int Quantity { get; set; }
    }
}
