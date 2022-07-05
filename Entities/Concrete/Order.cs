using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternshipProject2.Entities.Concrete
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public int UserID { get; set; }

        public DateTime DateTime { get; set; }
    }
}
