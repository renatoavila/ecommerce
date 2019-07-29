using Ecommerce.Domain.Entity;
using Ecommerce.Repository.Base;
using Ecommerce.Repository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Ecommerce.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly IRepository<Product> _productRepository;

        public ProductRepository(IConfiguration config,
                                 IRepository<Product> productRepository) : base(config)
        {
            _productRepository = productRepository;
        }

        public long Add(Product product)
        {
            return base.Insert(product);
        }

        public bool Update(Product product)
        {
            product.Id = base.Get(product.Key)?.Id ?? 0;
            return base.Update(product);
        }

        public Product Get(Guid key)
        {
           return base.Get(key);
        }

    }
}
