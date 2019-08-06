using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.Entity;
using Ecommerce.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ShopCartController'
    public class ShopCartController : ControllerBase
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ShopCartController'
    {

        private readonly IShopCartServices _shopCartServices;

        private readonly ILogger<ShopCartController> _logger;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ShopCartController.ShopCartController(IShopCartServices, ILogger<ShopCartController>)'
        public ShopCartController(IShopCartServices shopCartServices,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ShopCartController.ShopCartController(IShopCartServices, ILogger<ShopCartController>)'
                                ILogger<ShopCartController> logger)
        {
            _shopCartServices = shopCartServices;
            _logger = logger;
        }

        // Get api/ShopCart
        /// <summary>
        /// Create new Shop Cart
        /// </summary>
        /// <returns>new Shop Cart</returns>
        /// <response code="200">Return Shop Cart of key </response>
        /// <response code="400">Fail request</response>
        /// <response code="500">Internal error</response>
        [HttpGet]
        public ActionResult<ShopCart> Get()
        {
            try
            {
                return Ok(_shopCartServices.Create());
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpPost("{key}/additem")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ShopCartController.AddItem(Guid, ItemCart)'
        public ActionResult<Guid> AddItem([FromRoute] Guid key, [FromBody] ItemCart itemCart)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ShopCartController.AddItem(Guid, ItemCart)'
        {
            try
            {
                _shopCartServices.AddItem(new ShopCart() { Key = key }, itemCart);

                if (itemCart.Invalid)
                {
                    return BadRequest(new { notifications = itemCart.GetNotification() });
                }

                return Ok(new { key = itemCart.Key });
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpGet("{key}/listitem")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ShopCartController.ListItem(Guid)'
        public ActionResult<List<ItemCart>> ListItem([FromRoute] Guid key)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ShopCartController.ListItem(Guid)'
        {
            try
            { 
                return Ok(_shopCartServices.ListItem(new ShopCart() { Key = key }));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            } 
        }

        [HttpGet("{key}/totalprice")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ShopCartController.TotalPrice(Guid)'
        public ActionResult<decimal> TotalPrice([FromRoute] Guid key)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ShopCartController.TotalPrice(Guid)'
        {
            try
            {
                return Ok(_shopCartServices.TotalPrice(new ShopCart() { Key = key }));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpDelete("deleteitem/{key}")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ShopCartController.RemoveItem(Guid)'
        public ActionResult<string> RemoveItem([FromRoute] Guid key)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ShopCartController.RemoveItem(Guid)'
        {
            try
            {
                _shopCartServices.RemoveItem(new ItemCart() { Key = key });
                return Ok("success");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
             
        }

    }
}