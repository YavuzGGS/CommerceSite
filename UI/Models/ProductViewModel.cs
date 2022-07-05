using Entities.Concrete;
using Entities.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class ProductViewModel
    {
       public List<Product> Products { get; set; }
       public Cart Cart { get; set; }
       public Product Product { get; set; }
    }
}
