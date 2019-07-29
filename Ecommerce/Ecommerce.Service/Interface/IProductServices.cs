using Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;

namespace Ecommerce.Service.Interface
{
    public interface IProductServices
    {
        Product GetProduct(Guid key);
        Guid AddProduct(Product product);

        Guid UpdateProduct(Product product);
    }
}