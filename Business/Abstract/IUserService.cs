using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        int Add(User user);
        void Delete(User user);
        void Update(User user);
        User GetByUsername(string username);
        User GetById(int id);
        List<User> GetAll();
        bool Validate(User user);
        string RoleToString(User user);
    }
}
