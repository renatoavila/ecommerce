using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.Entity;
using Ecommerce.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoServices _produtoServices;

        private readonly ILogger<ProdutosController> _logger;

        public ProdutosController(IProdutoServices ProdutoServices, ILogger<ProdutosController> logger)
        {
            _produtoServices = ProdutoServices;
            _logger = logger;
        }

        // Get api/Produtos
        /// <summary>
        /// Retorna uma lista de produtos
        /// </summary>
        /// <remarks>         
        /// </remarks>
        /// <returns>Retorna uma lista de produtos</returns>
        /// <response code="200">Retorna uma lista de produtos</response>
        /// <response code="500">Erro inesperado</response>
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            try
            {
                return Ok(_produtoServices.List());
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        // POST api/Produtos
        /// <summary>
        /// Cria um item
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Um novo item criado</returns>
        /// <response code="200">Retorna status</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPost]
        public ActionResult<string> Post([FromBody] Produto Produto)
        {
            try
            {
                _produtoServices.Insert(Produto);
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
