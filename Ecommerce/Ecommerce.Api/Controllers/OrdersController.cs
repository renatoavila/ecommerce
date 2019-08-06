using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Enum;
using Ecommerce.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'OrdersController'
    public class OrdersController : ControllerBase
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'OrdersController'
    {

        private readonly IOrdersServices _ordersServices;

        private readonly ILogger<OrdersController> _logger;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'OrdersController.OrdersController(IOrdersServices, ILogger<OrdersController>)'
        public OrdersController(IOrdersServices ordersServices,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'OrdersController.OrdersController(IOrdersServices, ILogger<OrdersController>)'
                                ILogger<OrdersController> logger)
        {
            _ordersServices = ordersServices;
            _logger = logger;
        }

        // POST api/Client
#pragma warning disable CS1572 // XML comment has a param tag for 'client', but there is no parameter by that name
        /// <summary>
        /// Insert new Order
        /// </summary>
        /// <param name="client"></param>
        /// <returns>Um novo Order </returns>
        /// <response code="200">Return Order of key </response>
        /// <response code="400">Fail request</response>
        /// <response code="500">Internal error</response>
        [HttpPost]
#pragma warning restore CS1572 // XML comment has a param tag for 'client', but there is no parameter by that name
#pragma warning disable CS1573 // Parameter 'order' has no matching param tag in the XML comment for 'OrdersController.Post(Order)' (but other parameters do)
        public ActionResult<Order> Post([FromBody] Order order)
#pragma warning restore CS1573 // Parameter 'order' has no matching param tag in the XML comment for 'OrdersController.Post(Order)' (but other parameters do)
        {
            try
            {
                var  ret = _ordersServices.CreateOrder(order);
                return Ok(new { Order = ret });
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }

        }
    }
}