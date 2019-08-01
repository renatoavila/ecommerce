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
    public class StockController : ControllerBase
    {

        private readonly IStockServices _stockServices;

        private readonly ILogger<StockController> _logger;

        public StockController(IStockServices stockServices,
                                ILogger<StockController> logger)
        {
            _stockServices = stockServices;
            _logger = logger;
        }

        // Get api/ShopCart
        /// <summary>
        /// Create new stock
        /// </summary>
        /// <returns>Saldo do Estoque</returns>
        /// <response code="200">Return saldo estoque </response>
        /// <response code="400">Fail request</response>
        /// <response code="500">Internal error</response>
        [HttpPost]
        public ActionResult<Guid> AddItem([FromBody] Product product, int amount, Operation operation)
        {
            try
            {
                var result =  _stockServices.ChangeStock(product,amount, operation);

                return Ok(new { result = result });
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

    }
}