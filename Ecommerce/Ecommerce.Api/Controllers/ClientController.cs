using Ecommerce.Domain.Entity;
using Ecommerce.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;


namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ClientController'
    public class ClientController : ControllerBase
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ClientController'
    {
        private readonly IClientServices _clientServices;

        private readonly ILogger<ClientController> _logger;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ClientController.ClientController(IClientServices, ILogger<ClientController>)'
        public ClientController(IClientServices clientServices, 
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ClientController.ClientController(IClientServices, ILogger<ClientController>)'
                                ILogger<ClientController> logger)
        {
            _clientServices = clientServices;
            _logger = logger; 
        }

        
        // Get api/Client
        /// <summary>
        /// Return a Client
        /// </summary>
        /// <param name="key">Key of client</param>
        /// <returns>Return a Client</returns>
        /// <response code="200">Return a Client</response>
        /// <response code="500">Internal error</response>
        [HttpGet]
        public ActionResult<Client> Get(Guid key)
        {
            try
            { 
                return Ok(_clientServices.GetClient(key));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }
        }

        // POST api/Client
        /// <summary>
        /// Insert new client
        /// </summary>
        /// <param name="client"></param>
        /// <returns>Um novo item criado</returns>
        /// <response code="200">Return client of key </response>
        /// <response code="400">Fail request</response>
        /// <response code="500">Internal error</response>
        [HttpPost]
        public ActionResult<Guid> Post([FromBody] Client client)
        {
            try
            { 
                Guid key = _clientServices.ChangeClient(client);

                if (client.Invalid)
                {
                    return BadRequest(new { notifications = client.GetNotification() });
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