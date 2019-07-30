using Dapper.Contrib.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Entity
{
    [Table("ItemCart")]
    public class ItemCart: Base.Entity
    {
        [JsonIgnore]
        public long shopCartId { get; set; }

        /// <summary>
        /// Produto 
        /// </summary>
        [Write(false)]
        public Product product { get; set; }

        [JsonIgnore]
        public long productId { get; set; }
        /// <summary>
        /// Preço unitario do item
        /// </summary>
        public decimal UnitPrice { get; set; }
        /// <summary>
            /// Quantidade de item
            /// </summary>
        public int Amount { get; set; }
    }
}
