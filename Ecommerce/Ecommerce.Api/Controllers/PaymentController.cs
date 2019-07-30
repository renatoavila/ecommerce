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
    public class PaymentController : ControllerBase
    {

        private readonly IPaymentServices _paymentServices;

        private readonly ILogger<PaymentController> _logger;

        public PaymentController(IPaymentServices paymentServices,
                                ILogger<PaymentController> logger)
        {
            _paymentServices = paymentServices;
            _logger = logger;
        }
    }
}