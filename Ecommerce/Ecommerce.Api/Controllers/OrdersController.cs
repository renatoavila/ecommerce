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
    public class OrdersController : ControllerBase
    {

        private readonly IOrdersServices _ordersServices;

        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IOrdersServices ordersServices,
                                ILogger<OrdersController> logger)
        {
            _ordersServices = ordersServices;
            _logger = logger;
        }

        // POST api/Client
        /// <summary>
        /// Insert new Order
        /// </summary>
        /// <param name="client"></param>
        /// <returns>Um novo Order </returns>
        /// <response code="200">Return Order of key </response>
        /// <response code="400">Fail request</response>
        /// <response code="500">Internal error</response>
        [HttpPost]
        public ActionResult<Order> Post([FromBody] Order order)
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