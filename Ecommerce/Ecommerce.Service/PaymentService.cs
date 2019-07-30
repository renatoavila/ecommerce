using Ecommerce.Business.Interface;
using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Enum;
using Ecommerce.Service.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Ecommerce.Service
{
    public class PaymentService : IPaymentServices
    {
        private readonly IPaymentBusiness _paymentBusiness;

        public PaymentService(IPaymentBusiness paymentBusiness)
        {
            _paymentBusiness = paymentBusiness;
        }
    }
}
