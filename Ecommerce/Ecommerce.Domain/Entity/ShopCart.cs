using Dapper.Contrib.Extensions;
using Ecommerce.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Entity
{
    [Table("Shopcart")]
    public class ShopCart : Base.Entity
    {
        public ShopCart()
        {
        }
        public ShopCart(DateTime date, ShopState state)
        {
            Date = date;
            State = state;
        }

        public DateTime Date { get; set; }
        public ShopState State { get; set; }

        [Write(false)]
        public Order Order { get; set; }
    }
}
