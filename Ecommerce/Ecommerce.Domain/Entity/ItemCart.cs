using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Entity
{
    public class ItemCart: Base.Entity

    {   /// <summary>
        /// Produto 
        /// </summary>
        public Product product { get; set; }
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
