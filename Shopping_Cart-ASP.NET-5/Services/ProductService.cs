using Shopping_Cart_ASP.NET_5.Interfaces;
using Shopping_Cart_ASP.NET_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart_ASP.NET_5.Services
{
    public class ProductService : IProductService
    {
        public Product GetProduct(string sku)
        {
            return GetProducts().Where(w => w.Sku == sku).FirstOrDefault();
        }

        public IEnumerable<Product> GetProducts()
        {
            return new List<Product>
        {
            new Product{Sku = "sku1", Name="iphone 10", Price=800},
            new Product{Sku = "sku2", Name="iphone 11", Price=900},
            new Product{Sku = "sku3", Name="iphone 12", Price=1000},
            new Product{Sku = "sku4", Name="iphone 12 Pro", Price=1200},
        };
        }
    }
}
