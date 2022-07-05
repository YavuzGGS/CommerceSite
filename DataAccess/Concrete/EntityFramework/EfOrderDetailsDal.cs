using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using InternshipProject2.DataAccess.Abstract;
using InternshipProject2.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace InternshipProject2.DataAccess.Concrete.EntityFramework
{
    public class EfOrderDetailsDal : EfEntityRepositoryBase<OrderDetails, InternshipAppContext>, IOrderDetailsDal

    {
    }
}
