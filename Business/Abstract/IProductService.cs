using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        void Add(Product product);
        void Delete(Product product);
        void Update(Product product);
        Product GetByProductName(string product);
        Product GetById(int id);
        List<Product> GetByCategory(int categoryId);
        List<Product> GetAll();
    }
}
