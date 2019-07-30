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

        public Order CreateOrder(Guid clientKey, Guid shopCartKey)
        {
            Order order = new Order();
            order.client = this.GetClient(clientKey);
            order.shopCart = this.GetShopCart(shopCartKey);
            order.clientId = order.client.Id;
            order.shopCartId = order.shopCart.Id;
            order.Number = GetNumberOrder(order.shopCartId);
            order.Date = DateTime.Now;
            order.orderState = OrderState.New;
            _ordersRepository.Insert(order);
            return order;
        }

        public Client GetClient(Guid key)
        {
            return _clientRepository.Get(key);
        }

        public string GetNumberOrder(long id)
        {
            var strOrder = new string('0', 8) + id.ToString();
            return DateTime.Now.Year + strOrder.Substring(strOrder.Length - 8, strOrder.Length);
        }

        public ShopCart GetShopCart(Guid key)
        {
            return _shopcartRepository.Get(key);
        }
    }
}
