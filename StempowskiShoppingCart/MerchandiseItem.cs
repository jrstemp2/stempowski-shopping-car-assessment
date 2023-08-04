using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StempowskiShoppingCart
{
    public class MerchandiseItem
    {
        public string? ItemName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsBook { get; set; }
        public int Quantity {get; set; }

        public IEnumerable<object> TypeOf()
        {
            throw new NotImplementedException();
        }
    }
}
