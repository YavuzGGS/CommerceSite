using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _productDal.GetList(filter: p => p.CategoryId == categoryId);
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.Id == id);
        }

        public Product GetByProductName(string product)
        {
            return _productDal.Get(p => p.ProductName == product);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
