﻿using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Enum;
using System;
using System.Collections.Generic;

namespace Ecommerce.Service.Interface
{
    public interface IPaymentServices
    {
        Payment Execute(Payment payment);
    }
}