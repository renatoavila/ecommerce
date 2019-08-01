using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Integration.Model
{ 
    public class RequestCreditCardTransation
    {
        public string reference { get; set; }
        public int amountInCents { get; set; }
        public string branch { get; set; }
        public string number { get; set; }
        public string expirationDate { get; set; }
        public string securityCode { get; set; }
        public string holderName { get; set; }
        public DateTime createDate { get; set; }
    }

}
