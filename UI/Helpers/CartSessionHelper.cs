using Entities.DomainModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Extensions;

namespace UI.Helpers
{
    public class CartSessionHelper : ICartSessionHelper
    {
        private IHttpContextAccessor _httpContextAccessor;
        public CartSessionHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void Clear()
        {
            _httpContextAccessor.HttpContext.Session.Remove("cart");
        }

        public Cart GetCart()
        {
            Cart cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            if (cartToCheck == null)
            {
                SetCart(new Cart());
                cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            }
            return cartToCheck;
        }

        public void SetCart(Cart cart)
        {
            _httpContextAccessor.HttpContext.Session.SetObject("cart", cart);
        }
    }
}
