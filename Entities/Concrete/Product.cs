using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Product Name Required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Category Id Required")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Stock Amount Required")]
        public int Stock { get; set; }
        [Required(ErrorMessage = "Price Required Required")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Quantity Required Required")]
        public string QuantityPerUnit { get; set; }

    }
    
}
