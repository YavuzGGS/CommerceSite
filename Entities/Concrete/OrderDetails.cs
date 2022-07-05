using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternshipProject2.Entities.Concrete
{
    public class OrderDetails : IEntity
    {
        public int Id { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
