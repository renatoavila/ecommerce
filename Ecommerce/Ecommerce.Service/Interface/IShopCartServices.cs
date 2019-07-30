using Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;

namespace Ecommerce.Service.Interface
{
    public interface IShopCartServices
    {
        ShopCart Create();
        void AddItem(ShopCart shopCart, ItemCart itemCart);
        List<ItemCart> ListItem(ShopCart shopCart);
        decimal TotalPrice(ShopCart shopCart);
        void RemoveItem(ItemCart item); 
    }
}