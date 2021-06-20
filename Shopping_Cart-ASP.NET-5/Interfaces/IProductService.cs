using Shopping_Cart_ASP.NET_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart_ASP.NET_5.Interfaces
{
    public interface IProductService
    {
        public IEnumerable<Product> GetProducts();
        public Product GetProduct(string sku);
    }
}
