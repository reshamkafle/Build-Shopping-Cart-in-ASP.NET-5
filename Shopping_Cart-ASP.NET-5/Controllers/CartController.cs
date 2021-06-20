using Microsoft.AspNetCore.Mvc;
using Shopping_Cart_ASP.NET_5.Interfaces;
using Shopping_Cart_ASP.NET_5.Models;
using Shopping_Cart_ASP.NET_5.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart_ASP.NET_5.Controllers
{
    public class CartController : Controller
    {

        private readonly IProductService _productService;

        public CartController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.Get<List<Product_Item>>("cart");
            if (cart != null)
            {
                ViewBag.total = cart.Sum(s => s.Quantity * s.Product.Price);
            }
            else
            {
                cart = new List<Product_Item>();
                ViewBag.total = 0;
            }

            return View(cart);
        }


        public IActionResult Buy(string sku)
        {
            var product = _productService.GetProduct(sku);
            var cart = HttpContext.Session.Get<List<Product_Item>>("cart");

            if (cart == null) //no item in the cart
            {
                cart = new List<Product_Item>();
                cart.Add(new Product_Item { Product = product, Quantity = 1 });
            }
            else
            {
                int index = cart.FindIndex(w => w.Product.Sku == sku);

                if (index != -1) //if item already in the 
                {
                    cart[index].Quantity++; //increment by 1
                }
                else
                {
                    cart.Add(new Product_Item { Product = product, Quantity = 1 });
                }
            }

            HttpContext.Session.Set<List<Product_Item>>("cart", cart);
            return RedirectToAction("Index");
        }


        public IActionResult Add(string sku)
        {
            var product = _productService.GetProduct(sku);
            var cart = HttpContext.Session.Get<List<Product_Item>>("cart");

            int index = cart.FindIndex(w => w.Product.Sku == sku);
            cart[index].Quantity++; //increment by 1

            HttpContext.Session.Set<List<Product_Item>>("cart", cart);
            return RedirectToAction("Index");
        }


        public IActionResult Minus(string sku)
        {
            var product = _productService.GetProduct(sku);
            var cart = HttpContext.Session.Get<List<Product_Item>>("cart");

            int index = cart.FindIndex(w => w.Product.Sku == sku);

            if (cart[index].Quantity == 1) //last item of a product
            {
                cart.RemoveAt(index); //remove it
            }
            else
            {
                cart[index].Quantity--; //reduce by 1
            }


            HttpContext.Session.Set<List<Product_Item>>("cart", cart);
            return RedirectToAction("Index");
        }


        public IActionResult Remove(string sku)
        {
            var product = _productService.GetProduct(sku);
            var cart = HttpContext.Session.Get<List<Product_Item>>("cart");

            int index = cart.FindIndex(w => w.Product.Sku == sku);
            cart.RemoveAt(index);

            HttpContext.Session.Set<List<Product_Item>>("cart", cart);

            return RedirectToAction("Index");
        }
    }
}
