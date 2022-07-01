using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AddressManager : IAddressService
    {
        private IAddressDal _addressDal;
        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }
        public void Add(Address address)
        {
            _addressDal.Add(address);
        }

        public void Delete(Address address)
        {
            _addressDal.Delete(address);
        }

        public Address GetAddress(int UserID)
        {
            Address address = GetById(UserID);
            if (address != null)
                return address;
            else
                return new Address();
        }

        public List<Address> GetAll()
        {
            return _addressDal.GetList();
        }

        public Address GetById(int id)
        {
            return _addressDal.Get(a => a.UserID == id);
        }

        public void Update(Address address)
        {
            _addressDal.Update(address);
        }
    }
}
