using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Helpers;
using UI.Models;

namespace UI.Controllers
{
    public class CartController : Controller
    {
        private IProductService _productService;
        private ICartService _cartService;
        private ICartSessionHelper _cartSessionHelper;
        public CartController(ICartService cartService, ICartSessionHelper cartSessionHelper, IProductService productService)
        {
            _cartService = cartService;
            _cartSessionHelper = cartSessionHelper;
            _productService = productService;
        }
        public IActionResult Cart()
        {
            var model = new CartViewModel
            {
                Cart = _cartSessionHelper.GetCart()
            };
            return View(model);
        }
        public IActionResult AddToCart(int Id)
        {
            Product product = _productService.GetById(Id); // get the product 
            var cart = _cartSessionHelper.GetCart(); // create and get the cart / or get the existing one
            _cartService.AddToCart(cart, product); // add the product to cart
            _cartSessionHelper.SetCart(cart); // save the cart on session storage
            return RedirectToAction("Cart", "Cart");
        }
        //add remove product, clear cart, new controller? cart view etc.
        public IActionResult RemoveFromCart(int Id)
        {
            var cart = _cartSessionHelper.GetCart();
            _cartService.RemoveFromCart(cart, Id);
            _cartSessionHelper.SetCart(cart);
            return RedirectToAction("Cart", "Cart");
        }
    }
}
