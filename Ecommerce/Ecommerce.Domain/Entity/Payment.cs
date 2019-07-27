using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Entity
{
   public class Payment: Base.Entity
    {

        public string State { get; set; }
        public decimal Value { get; set; }
    }
}
