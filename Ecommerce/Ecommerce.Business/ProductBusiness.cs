using Ecommerce.Business.Interface;
using Ecommerce.Domain.Entity;
using Ecommerce.Repository;
using Ecommerce.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Business
{
    public class ProductBusiness : IProductBusiness
    {

        private readonly IProductRepository _productRepository;
        public ProductBusiness(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Guid AddProduct(Product product)
        {
            _productRepository.Insert(product);

            return product.Key;
        }
        public Product GetProduct(Guid key)
        {
            return _productRepository.Get(key);
        }

        public List<Product> GetProduct()
        {
            return _productRepository.GetAll().ToList();
        }
        public Guid UpdateProduct(Product product)
        {
            _productRepository.Update(product);

            return product.Key;
        }
    }
}
