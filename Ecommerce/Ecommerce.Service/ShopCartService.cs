using Ecommerce.Business.Interface;
using Ecommerce.Domain.Entity;
using Ecommerce.Service.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Ecommerce.Service
{
    public class ShopCartServices : IShopCartServices
    {
        private readonly IShopCartBusiness _shopCartBusiness;

        public ShopCartServices(IShopCartBusiness shopCartBusiness)
        {
            _shopCartBusiness = shopCartBusiness;
        }
         
        public ShopCart Create()
        {
            return _shopCartBusiness.Create();
        }

        public void AddItem(ShopCart shopCart, ItemCart itemCart)
        {
            itemCart.AddNotification(!_shopCartBusiness.
                                       StockValidate(itemCart,
                                                      Domain.Enum.Operation.Reserved), "");
            if (itemCart.Valid)
            {
              _shopCartBusiness.AddItem(shopCart, itemCart);
            }
           
        }

        public List<ItemCart> ListItem(ShopCart shopCart)
        {
            return _shopCartBusiness.ListItem(shopCart);
        }

        public decimal TotalPrice(ShopCart shopCart)
        {
            return _shopCartBusiness.TotalPrice(shopCart);
        }

        public void RemoveItem(ItemCart item)
        {
            _shopCartBusiness.RemoveItem(item);
        }
    }
}
