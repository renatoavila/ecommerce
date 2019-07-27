using Ecommerce.Domain.Enum;
using System;*;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Entity
{
    public class Order: Base.Entity
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public OrderState orderState { get; set; }
    }
}
