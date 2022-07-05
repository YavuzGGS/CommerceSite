using InternshipProject2.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternshipProject2.Business.Abstract
{
    public interface IOrderService
    {
        int Add(Order order);
        void Delete(Order order);
        Order GetById(int id);
        Order GetByUserId(int id);
        List<Order> GetAll();
    }
}
