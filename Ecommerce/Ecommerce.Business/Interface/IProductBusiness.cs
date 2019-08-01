using Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Interface
{
    public interface IProductBusiness
    {
        Product GetProduct(Guid key);
        List<Product> GetProduct();

        Guid AddProduct(Product product);

        Guid UpdateProduct(Product product);
    }
}
