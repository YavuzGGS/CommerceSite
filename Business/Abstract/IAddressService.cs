using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAddressService
    {
        void Add(Address address);
        void Delete(Address address);
        void Update(Address address);
        Address GetById(int id);
        List<Address> GetAll();
        Address GetAddress(int UserID);
    }
}
