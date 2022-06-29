using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DomainModels
{
    public class Cart : IDomainModel
    {
        public Cart()
        {
            CartContents = new List<CartContent>();
        }
        public List<CartContent> CartContents { get; set; }
    }
}
