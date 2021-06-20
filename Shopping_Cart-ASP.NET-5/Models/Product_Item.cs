using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart_ASP.NET_5.Models
{
    public class Product_Item
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        private decimal _SubTotal;
        public decimal SubTotal
        {
            get { return _SubTotal; }
            set { _SubTotal = Product.Price * Quantity; }
        }
    }
}
