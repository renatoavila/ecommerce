using Dapper.Contrib.Extensions;
using Ecommerce.Domain.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Entity
{
    [Table("Stock")]
    public class Stock : Base.Entity
    {
        public int AmountStock { get; set; }
        public int AmountReserved { get; set; }
        [Write(false)]
        public Product product { get; set; }
        [JsonIgnore]
        public int productId { get; set; }
    }
}
