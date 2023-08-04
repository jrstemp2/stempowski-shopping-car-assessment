using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StempowskiShoppingCart
{
    public class Receipt
    {
        public List<MerchandiseItem> MerchandiseItems { get; set; } = new List<MerchandiseItem>();
        public DateTime ReceiptDate { get; set; } = DateTime.Now;
        public decimal SubTotal { get; set; }
        public decimal SalesTax { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
