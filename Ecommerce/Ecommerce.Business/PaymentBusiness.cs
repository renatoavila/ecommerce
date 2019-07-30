﻿using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Enum;
using Ecommerce.Repository.Interface;
using System;
using System.Linq;

namespace Ecommerce.Business.Interface
{
    public class PaymentBusiness: IPaymentBusiness

    {

        private readonly IOrdersRepository _ordersRepository;
        private readonly IPaymentRepository _paymentRepository;
      

        public PaymentBusiness(IOrdersRepository ordersRepository,
                              IPaymentRepository paymentRepository)

        {
            _ordersRepository = ordersRepository;
            _paymentRepository = paymentRepository;
          }

    }
}
