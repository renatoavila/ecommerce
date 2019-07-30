using Ecommerce.Domain.Enum;
using Newtonsoft.Json;
using System;
using Dapper.Contrib.Extensions;

namespace Ecommerce.Domain.Entity
{
    [Table("Orders")]
    public class Order : Base.Entity
    {
        public Order()
        {

        }

        public string Number { get; set; }
        public DateTime Date { get; set; }
        public OrderState orderState { get; set; }
        [JsonIgnore]
        public long clientId { get; set; }
        [Write(false)]
        public Client client { get; set; }
        //[JsonIgnore]
        //public int addressId { get; set; }
        //[Write(false)]
        //public Address address { get; set; }
        [JsonIgnore]
        public long shopCartId { get; set; }
        [Write(false)]
        public ShopCart shopCart { get; set; }
    }
}
