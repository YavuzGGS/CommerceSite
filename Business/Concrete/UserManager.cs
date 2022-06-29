using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public int Add(User newUser)
        {
            var users = _userDal.GetList();
            foreach (var user in users)
            {
                if (user.Email.Trim() == newUser.Email)
                {
                    return 0;
                }
                if (user.Username.Trim() == newUser.Username)
                {
                    return 1;
                }
            }
            _userDal.Add(newUser);
            return 2;
        }

        public void Delete(User user)
        {
            _userDal.Delete(user);
        }

        public List<User> GetAll()
        {
            return _userDal.GetList();
        }

        public User GetById(int id)
        {
            return _userDal.Get(u => u.Id == id);
        }

        public User GetByUsername(string username)
        {
            return _userDal.Get(u => u.Username == username);
        }

        public string RoleToString(User user)
        {
            switch (user.Role)
            {
                case 0:
                    return "Standard";
                case 1:
                    return "Admin";
                case 2:
                    return "SuperAdmin";
            }
            return "Standard";
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }

        public bool Validate(User user)
        {
            var users = _userDal.GetList();
            foreach (var usr in users)
            {
                if (usr.Username.Trim() == user.Username && usr.Password.Trim() == user.Password)
                {
                    user.Role = usr.Role;
                    return true;
                }
            }
            return false;
        }
    }
}
