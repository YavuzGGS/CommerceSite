using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private IUserService _userService;
        private IAddressService _addressService;
        public CartController(ICartService cartService, ICartSessionHelper cartSessionHelper, IProductService productService, 
            IUserService userService, IAddressService addressService)
        {
            _cartService = cartService;
            _cartSessionHelper = cartSessionHelper;
            _productService = productService;
            _userService = userService;
            _addressService = addressService;
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
        public IActionResult EmptyCart()
        {
            _cartSessionHelper.Clear();
            return RedirectToAction("Cart", "Cart");
        }
        [Authorize]
        public IActionResult Continue()
        {
            string username = User.Claims.FirstOrDefault(c => c.Type == "user").Value;
            var user = _userService.GetByUsername(username);
            var model = new CheckOutViewModel
            {
                User = user,
                Address =_addressService.GetAddress(user.Id),
                Cart = _cartSessionHelper.GetCart()
            };
            decimal num = 0;
            foreach (var item in model.Cart.CartContents)
            {
                num += item.Product.Price*item.Quantity;
            }
            model.Total = num.ToString("0.00");
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Continue(Address address)
        {
            string username = User.Claims.FirstOrDefault(c => c.Type == "user").Value;
            var user = _userService.GetByUsername(username);
            address.UserID = user.Id;
            Address dbAddress = _addressService.GetById(address.UserID);
            if (dbAddress != null)
            {
                address.Id = dbAddress.Id;
                _addressService.Update(address);
            }
            else if (dbAddress != null)
                {
                    _addressService.Add(address);
                }
            _cartSessionHelper.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
