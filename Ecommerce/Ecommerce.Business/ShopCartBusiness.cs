using Ecommerce.Business.Interface;
using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Enum;
using Ecommerce.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecommerce.Business
{
    public class ShopCartBusiness : IShopCartBusiness
    {
        private readonly IShopCartRepository _shopCartRepository;
        private readonly IItemCartRepository _itemCartRepository;
        public ShopCartBusiness(IShopCartRepository shopCartRepository,
                                IItemCartRepository itemCartRepository)
        {
            _shopCartRepository = shopCartRepository;
            _itemCartRepository = itemCartRepository;
        }

        public ShopCart Create()
        {
            ShopCart shopCart = new ShopCart(DateTime.Now, ShopState.New);
            _shopCartRepository.Insert(shopCart);
            return shopCart;
        }

        public void AddItem(ShopCart shopCart, ItemCart itemCart)
        {
            itemCart.shopCartId = this.GetId(shopCart);
            _itemCartRepository.Insert(itemCart);
        }

        public List<ItemCart> ListItem(ShopCart shopCart)
        {
            shopCart.Id = this.GetId(shopCart);
            return _itemCartRepository.GetAll(shopCart.Id).ToList();
        }

        public decimal TotalPrice(ShopCart shopCart)
        {
            return this.ListItem(shopCart).Sum(x => x.UnitPrice * x.Amount);
        }

        public void RemoveItem(ItemCart item)
        {
            _itemCartRepository.Delete(item);
        }

        private long GetId(ShopCart shopCart)
        {
            shopCart = _shopCartRepository.Get(shopCart.Key);
            return shopCart.Id;
        }
    }
}
