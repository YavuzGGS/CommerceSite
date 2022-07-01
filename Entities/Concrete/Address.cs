using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class Address : IEntity
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string DetailedAddress { get; set; }
    }
}
