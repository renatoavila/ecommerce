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
        ItemCart GetItem(Guid key);
        decimal TotalPrice(ShopCart shopCart);
        void RemoveItem(ItemCart item);
        bool ReservedStock(ItemCart item);
        void ReverseStock(ItemCart item);
    }
}
