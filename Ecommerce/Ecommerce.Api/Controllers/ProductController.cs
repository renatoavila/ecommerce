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
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductServices productServices, 
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
        /// <summary>
        /// Insert new product
        /// </summary>
        /// <param name="Product"></param>
        /// <returns>Um novo item criado</returns>
        /// <response code="200">Return product of key </response>
        /// <response code="400">Fail request</response>
        /// <response code="500">Internal error</response>
        [HttpPost]
        public ActionResult<Guid> Post([FromBody] Product product)
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
        /// <summary>
        /// Update new product
        /// </summary>
        /// <param name="Product"></param>
        /// <returns>Um novo item criado</returns>
        /// <response code="200">Return product of key </response>
        /// <response code="400">Fail request</response>
        /// <response code="500">Internal error</response>
        [HttpPatch]
        public ActionResult<Guid> Patch([FromBody] Product product)
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