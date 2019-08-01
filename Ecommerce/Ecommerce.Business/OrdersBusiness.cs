using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Enum;
using Ecommerce.Repository.Interface;
using System;
using System.Linq;

namespace Ecommerce.Business.Interface
{
    public class OrdersBusiness: IOrdersBusiness

    {

        private readonly IOrdersRepository _ordersRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IShopCartRepository _shopcartRepository;

        public OrdersBusiness(IOrdersRepository ordersRepository, 
                              IClientRepository clientRepository,
                           IShopCartRepository shopcartRepository)

        {
            _ordersRepository = ordersRepository;
            _clientRepository = clientRepository;
            _shopcartRepository = shopcartRepository;


        }

        public Order CreateOrder(Order order)
        { 
            order.client = this.GetClient(order.client.Key);
            order.shopCart = this.GetShopCart(order.shopCart.Key);
            order.clientId = order.client.Id;
            order.shopCartId = order.shopCart.Id;
            order.Number = GetNumberOrder(order.shopCartId);
            order.Date = DateTime.Now;
            order.orderState = OrderState.New;
            _ordersRepository.Insert(order);
            return order;
        }

        public Order Get(Guid key)
        {
            Order ret = _ordersRepository.Get(key);
            ret.client = _clientRepository.Get(ret.clientId);
            ret.shopCart = _shopcartRepository.Get(ret.shopCartId);
            return ret;
        }

        public Client GetClient(Guid key)
        {
            return _clientRepository.Get(key);
        }

        public string GetNumberOrder(long id)
        {
            return DateTime.Now.Year+ id.ToString("00000000");
        }

        public ShopCart GetShopCart(Guid key)
        {
            return _shopcartRepository.Get(key);
        }
    }
}
