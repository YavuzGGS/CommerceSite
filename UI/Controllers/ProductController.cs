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
                Products = category > 0 ? _productService.GetByCategory(category) : _productService.GetAll()
            };
            return View(model);
        }
        public IActionResult AddToCart(int Id)
        {
            Product product = _productService.GetById(Id);
            var cart = _cartSessionHelper.GetCart();
            _cartService.AddToCart(cart,product);
            _cartSessionHelper.SetCart(cart);
            return RedirectToAction("Index", "Product");
        }

    }
}
