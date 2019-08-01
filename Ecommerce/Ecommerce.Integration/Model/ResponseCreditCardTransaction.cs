using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Integration.Model
{ 
    public class ResponseCreditCardTransaction
    {
        public Creditcardtransaction creditCardTransaction { get; set; }
        public string requestKey { get; set; }
        public DateTime createDate { get; set; }
        public float internalTimeMs { get; set; }
    }

    public class Creditcardtransaction
    {
        public string affiliationKey { get; set; }
        public string reference { get; set; }
        public int amountInCents { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime authorizedAt { get; set; }
        public Creditcard creditCard { get; set; }
        public int id { get; set; }
        public string key { get; set; }
    }

    public class Creditcard
    {
        public string branch { get; set; }
        public string number { get; set; }
        public string expirationDate { get; set; }
        public string securityCode { get; set; }
        public string holderName { get; set; }
        public int status { get; set; }
        public int id { get; set; }
        public string key { get; set; }
    }

}
