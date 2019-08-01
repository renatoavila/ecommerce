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
        private readonly IStockBusiness _stockBusiness;
        public ShopCartBusiness(IShopCartRepository shopCartRepository,
                                IItemCartRepository itemCartRepository,
                                 IStockBusiness stockBusiness)
        {
            _shopCartRepository = shopCartRepository;
            _itemCartRepository = itemCartRepository;
            _stockBusiness = stockBusiness;
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

        public bool ReservedStock(ItemCart item)
        {
           return _stockBusiness.ReservedStock(item);
        }

        public void ReverseStock(ItemCart item)
        {
            _stockBusiness.ReverseStock(item);
        }

        public ItemCart GetItem(Guid key)
        {
          return _itemCartRepository.Get(key);
        }
    }
}
