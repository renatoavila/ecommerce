using Dapper.Contrib.Extensions;
using Ecommerce.Domain.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Entity
{
    [Table("Payment")]
    public class Payment: Base.Entity
    {
        [Write(false)]
        public Order Order { get; set; }

        [JsonIgnore]
        public long OrderId { get; set; }
        public string State { get; set; }
        public decimal Value { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
