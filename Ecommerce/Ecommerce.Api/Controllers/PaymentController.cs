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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PaymentController'
    public class PaymentController : ControllerBase
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PaymentController'
    {

        private readonly IPaymentServices _paymentServices;

        private readonly ILogger<PaymentController> _logger;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PaymentController.PaymentController(IPaymentServices, ILogger<PaymentController>)'
        public PaymentController(IPaymentServices paymentServices,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PaymentController.PaymentController(IPaymentServices, ILogger<PaymentController>)'
                                ILogger<PaymentController> logger)
        {
            _paymentServices = paymentServices;
            _logger = logger;
        }

        [HttpPost("billet")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PaymentController.Post(Billet)'
        public ActionResult<Guid> Post([FromBody] Billet billet)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PaymentController.Post(Billet)'
        {
            try
            {
                Payment payment = _paymentServices.Execute(billet);

                if (billet.Invalid)
                {
                    return BadRequest(new { notifications = billet.GetNotification() });
                }

                return Ok(payment);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }

        }

        [HttpPost("credcard")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PaymentController.Post(CredCard)'
        public ActionResult<Guid> Post([FromBody] CredCard credCard)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PaymentController.Post(CredCard)'
        {
            try
            {
                Payment payment = _paymentServices.Execute(credCard);

                if (credCard.Invalid)
                {
                    return BadRequest(new { notifications = credCard.GetNotification() });
                }

                return Ok(payment);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return new StatusCodeResult(500);
            }

        }
    }
}