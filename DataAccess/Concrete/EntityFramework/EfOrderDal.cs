using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using InternshipProject2.DataAccess.Abstract;
using InternshipProject2.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternshipProject2.DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, InternshipAppContext>, IOrderDal
    {
    }
}
