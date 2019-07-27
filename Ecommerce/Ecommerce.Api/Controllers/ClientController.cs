using AutoMapper;
using Ecommerce.Api.Model;
using Ecommerce.Domain.Entity;
using Ecommerce.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientServices _clientServices;

        private readonly ILogger<ClientController> _logger;

        private readonly IMapper _mapper;

        public ClientController(IClientServices clientServices, 
                                ILogger<ClientController> logger, 
                                IMapper mapper)
        {
            _clientServices = clientServices;
            _clientServices = clientServices;
            _mapper = mapper;
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
        public ActionResult<ClientModel> Get(Guid key)
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
        public ActionResult<Guid> Post([FromBody] ClientModel clientModel)
        {
            try
            {
                Client client =  _mapper.Map<Client>(clientModel);
                Guid key = _clientServices.ChangeClient(client);

                if (client.Invalid)
                {
                    return BadRequest(new { notifications = client.Notifications.ToArray() });
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