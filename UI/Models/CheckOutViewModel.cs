using Entities.Concrete;
using Entities.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class CheckOutViewModel
    {
        public User User { get; set; }
        public List<User> Users { get; set; }
        public Address Address { get; set; }
        public Cart Cart { get; set; }
        public string Total { get; set; }
    }
}
