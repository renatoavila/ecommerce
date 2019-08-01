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
            itemCart.AddNotification(!_shopCartBusiness.ReservedStock(itemCart),
                                    "Não tem estoque");

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

        public void RemoveItem(ItemCart itemCart)
        {
            if(itemCart.Id == 0)
            {
                itemCart = _shopCartBusiness.GetItem(itemCart.Key);
            }
            _shopCartBusiness.ReverseStock(itemCart);
            _shopCartBusiness.RemoveItem(itemCart);
        }
    }
}
