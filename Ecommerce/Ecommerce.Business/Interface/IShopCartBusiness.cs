using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Interface
{
    public interface IShopCartBusiness
    {
        ShopCart Create();
        void AddItem(ShopCart shopCart, ItemCart itemCart);
        List<ItemCart> ListItem(ShopCart shopCart);
        decimal TotalPrice(ShopCart shopCart);
        void RemoveItem(ItemCart item);
        bool StockValidate(ItemCart item, Operation operation);


         
    }
}
