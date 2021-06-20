using Microsoft.AspNetCore.Mvc;
using Shopping_Cart_ASP.NET_5.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart_ASP.NET_5.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            var products = _productService.GetProducts(); //get the list of products
            return View(products); //return to view
        }
    }
}
