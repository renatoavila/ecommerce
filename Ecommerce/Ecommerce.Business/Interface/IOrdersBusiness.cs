using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Interface
{
    public interface IOrdersBusiness
    {
        Order CreateOrder(Guid clientKey, Guid shopCartKey);

        Client GetClient(Guid key);

        ShopCart GetShopCart(Guid key);

        string GetNumberOrder(long id);
    }
}
