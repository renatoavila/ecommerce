using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Integration.Model
{ 
    public class ResponsePaymentSlipTransation
    {
        public Paymentsliptransaction paymentSlipTransaction { get; set; }
        public string requestKey { get; set; }
        public DateTime createDate { get; set; }
        public float internalTimeMs { get; set; }
    }

    public class Paymentsliptransaction
    {
        public string reference { get; set; }
        public string affiliationKey { get; set; }
        public int amountInCents { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime authorizedAt { get; set; }
        public Paymentslip paymentSlip { get; set; }
        public int id { get; set; }
        public string key { get; set; }
    }

    public class Paymentslip
    {
        public DateTime dueDate { get; set; }
        public string barCode { get; set; }
        public int status { get; set; }
        public int id { get; set; }
        public string key { get; set; }
    }

}
