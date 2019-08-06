using Ecommerce.Domain.Entity;
using Ecommerce.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ProductController'
    public class ProductController : ControllerBase
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ProductController'
    {
        private readonly IProductServices _productServices;

        private readonly ILogger<ProductController> _logger;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ProductController.ProductController(IProductServices, ILogger<ProductController>)'
        public ProductController(IProductServices productServices, 
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ProductController.ProductController(IProductServices, ILogger<ProductController>)'
                                ILogger<ProductController> logger)
        {
            _productServices = productServices;
            
        }

        // Get api/Product
        /// <summary>
        /// Return a Product
        /// </summary>
        /// <param name="key">Key of product</param>
        /// <returns>Return a Product</returns>
        /// <response code="200">Return a Product</response>
        /// <response code="500">Internal error</response>
        [HttpGet("{key}")]
        public ActionResult<Product> Get([FromRoute] Guid key)
        {
            try
            { 
                return Ok(_productServices.GetProduct(key));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        // Get api/Product
        /// <summary>
        /// Return list Product
        /// </summary>
        /// <returns>Return list Product</returns>
        /// <response code="200">Return list Product</response>
        /// <response code="500">Internal error</response>
        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            try
            {
                return Ok(_productServices.GetProduct());
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        // POST api/Product
#pragma warning disable CS1572 // XML comment has a param tag for 'Product', but there is no parameter by that name
        /// <summary>
        /// Insert new product
        /// </summary>
        /// <param name="Product"></param>
        /// <returns>Um novo item criado</returns>
        /// <response code="200">Return product of key </response>
        /// <response code="400">Fail request</response>
        /// <response code="500">Internal error</response>
        [HttpPost]
#pragma warning restore CS1572 // XML comment has a param tag for 'Product', but there is no parameter by that name
#pragma warning disable CS1573 // Parameter 'product' has no matching param tag in the XML comment for 'ProductController.Post(Product)' (but other parameters do)
        public ActionResult<Guid> Post([FromBody] Product product)
#pragma warning restore CS1573 // Parameter 'product' has no matching param tag in the XML comment for 'ProductController.Post(Product)' (but other parameters do)
        {
            try
            { 
                Guid key = _productServices.AddProduct(product);

                if (product.Invalid)
                {
                    return BadRequest(new { notifications = product.GetNotification() });
                }

                return Ok(new { key = key });
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }

        }

        // PATCH api/Product
#pragma warning disable CS1572 // XML comment has a param tag for 'Product', but there is no parameter by that name
        /// <summary>
        /// Update new product
        /// </summary>
        /// <param name="Product"></param>
        /// <returns>Um novo item criado</returns>
        /// <response code="200">Return product of key </response>
        /// <response code="400">Fail request</response>
        /// <response code="500">Internal error</response>
        [HttpPatch]
#pragma warning restore CS1572 // XML comment has a param tag for 'Product', but there is no parameter by that name
#pragma warning disable CS1573 // Parameter 'product' has no matching param tag in the XML comment for 'ProductController.Patch(Product)' (but other parameters do)
        public ActionResult<Guid> Patch([FromBody] Product product)
#pragma warning restore CS1573 // Parameter 'product' has no matching param tag in the XML comment for 'ProductController.Patch(Product)' (but other parameters do)
        {
            try
            {
                Guid key = _productServices.UpdateProduct(product);

                if (product.Invalid)
                {
                    return BadRequest(new { notifications = product.GetNotification() });
                }

                return Ok(new { key = key });
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }

        }
    }
}