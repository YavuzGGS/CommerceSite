using Business.Abstract;
using Entities.Concrete;
using Entities.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CartManager : ICartService
    {
        public void AddToCart(Cart cart, Product product)
        {
            CartContent cartContent = cart.CartContents.FirstOrDefault(c => c.Product.Id == product.Id);
            if (cartContent != null)
            {
                cartContent.Quantity++;
                return;
            }
            else
            {
                cart.CartContents.Add(new CartContent { Product = product, Quantity = 1 });
            }

        }

        public List<CartContent> List(Cart cart)
        {
            return cart.CartContents;
        }

        public void RemoveFromCart(Cart cart, int productId)
        {
            CartContent cartContent = cart.CartContents.FirstOrDefault(c => c.Product.Id == productId);
            if(cartContent.Quantity > 1)
            {
                cartContent.Quantity--;
            }
            else
            {
                cart.CartContents.Remove(item: cart.CartContents.FirstOrDefault(c => c.Product.Id == productId));
            }
            
        }
    }
}
