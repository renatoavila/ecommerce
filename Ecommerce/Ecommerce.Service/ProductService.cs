using Ecommerce.Business.Interface;
using Ecommerce.Domain.Entity;
using Ecommerce.Service.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Ecommerce.Service
{
    public class ProductServices : IProductServices
    {
        private readonly IProductBusiness _productBusiness;

        public ProductServices(IProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }

        public Guid AddProduct(Product product)
        {
            _productBusiness.AddProduct(product);
            return product.Key;
        }

        public Product GetProduct(Guid key)
        {
            return _productBusiness.GetProduct(key);
        }

        public List<Product> GetProduct()
        {
            return _productBusiness.GetProduct();
        }

        public Guid UpdateProduct(Product product)
        {
            _productBusiness.UpdateProduct(product);
            return product.Key;
        }

    }
}
