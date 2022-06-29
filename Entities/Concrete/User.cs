using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Username Required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Email Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }
        public int Role { get; set; }
    }
}
