using Core.DataAccess.Abstract;
using Entities.Concrete;
using InternshipProject2.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternshipProject2.DataAccess.Abstract
{
    public interface IOrderDetailsDal : IEntityRepository<OrderDetails>
    {
    }
}
