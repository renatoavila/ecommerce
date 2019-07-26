using Ecommerce.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Entity
{
    public class ShoppingCar : Base.Entity
    {
        public DateTime Date { get; set; }
        public ShopState State { get; set; }
    }
}
