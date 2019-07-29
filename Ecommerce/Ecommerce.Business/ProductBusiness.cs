﻿using Ecommerce.Business.Interface;
using Ecommerce.Domain.Entity;
using Ecommerce.Repository;
using Ecommerce.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business
{
    public class ProductBusiness : IProductBusiness
    {

        private readonly ProductRepository _productRepository;
        public ProductBusiness(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Guid AddProduct(Product product)
        {
            _productRepository.Add(product);

            return product.Key;
        }
        public Product GetProduct(Guid key)
        {
            return _productRepository.Get(key);
        }
        public Guid UpdateProduct(Product product)
        {
            _productRepository.Update(product);

            return product.Key;
        }
    }
}