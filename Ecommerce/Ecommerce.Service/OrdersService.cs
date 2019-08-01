using Ecommerce.Business.Interface;
using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Enum;
using Ecommerce.Service.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Ecommerce.Service
{
    public class OrdersService : IOrdersServices
    {
        private readonly IOrdersBusiness _ordersBusiness;

        public OrdersService(IOrdersBusiness orderskBusiness)
        {
            _ordersBusiness = orderskBusiness;
        }

        public Order CreateOrder(Order order)
        {
           return _ordersBusiness.CreateOrder(order);
        }
    }
}
