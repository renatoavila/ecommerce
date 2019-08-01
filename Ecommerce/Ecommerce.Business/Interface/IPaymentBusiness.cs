using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.Interface
{
    public interface IPaymentBusiness
    {
        long Insert(Payment payment);
        bool Update(Payment payment);
    }
}
