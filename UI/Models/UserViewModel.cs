using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class UserViewModel
    {
        public User User { get; set; }
        public List<User> Users { get; set; }
    }
}
