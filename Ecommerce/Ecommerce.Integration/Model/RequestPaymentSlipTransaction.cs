using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Integration.Model
{ 
    public class RequestPaymentSlipTransaction
    {
        public string reference { get; set; }
        public int amountInCents { get; set; }
        public DateTime createDate { get; set; }
    }

}
