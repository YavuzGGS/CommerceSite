using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UI.Extensions;
using UI.Helpers;
using UI.Models;

namespace UI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        private ICartService _cartService;
        private ICartSessionHelper _cartSessionHelper;
        public ProductController(ICartService cartService, ICartSessionHelper cartSessionHelper, IProductService productService)
        {
            _cartService = cartService;
            _cartSessionHelper = cartSessionHelper;
            _productService = productService;
        }
        public IActionResult Index(int category)
        {
            var model = new ProductViewModel
            {
                Products = category > 0 ? _productService.GetByCategory(category) : _productService.GetAll(),
                Cart = _cartSessionHelper.GetCart()
                
            };
            return View(model);
        }
        public IActionResult AddToCart(int Id)
        {
            Product product = _productService.GetById(Id); // get the product 
            var cart = _cartSessionHelper.GetCart(); // create and get the cart / or get the existing one
            _cartService.AddToCart(cart,product); // add the product to cart
            _cartSessionHelper.SetCart(cart); // save the cart on session storage
            TempData["message"] = product.ProductName + " added to cart";
            return RedirectToAction("Index", "Product", new { category = product.CategoryId });
        }
        public IActionResult RemoveFromCart(int Id)
        {
            Product product = _productService.GetById(Id); // get the product 
            var cart = _cartSessionHelper.GetCart();
            _cartService.RemoveFromCart(cart, Id);
            _cartSessionHelper.SetCart(cart);
            TempData["message"] = product.ProductName + " removed from cart";
            return RedirectToAction("Index", "Product", new { category = product.CategoryId });
        }
        [Authorize]
        public IActionResult AddProduct()
        {
            var model = new ProductViewModel
            {
                Product = new Product()
            };
            return View(model);
        }
        //maybe add new role that can add products (seller)
        [Authorize]
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
           _productService.Add(product);
           TempData["message"] = product.ProductName + " added to the list";
           return RedirectToAction("AddProduct");
        }

    }
}
