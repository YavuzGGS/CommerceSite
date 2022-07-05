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
        [Required(ErrorMessage = "Country Name Required")]
        public string Country { get; set; }
        [Required(ErrorMessage = "City Name Required")]
        public string City { get; set; }
        [Required(ErrorMessage = "Address Information Required")]
        public string DetailedAddress { get; set; }
    }
}
