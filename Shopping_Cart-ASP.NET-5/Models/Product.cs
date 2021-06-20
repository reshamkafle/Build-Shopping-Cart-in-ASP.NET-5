using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart_ASP.NET_5.Models
{
    public class Product
    {
        public string Sku { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
