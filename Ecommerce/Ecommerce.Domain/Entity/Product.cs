﻿using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic; 
using System.Text;
namespace Ecommerce.Domain.Entity
{
    [Dapper.Contrib.Extensions.Table("product")]
    public class Product : Base.Entity
    {
        /// <summary>
        /// Titulo do produto
        /// </summary> 
        public string Title { get; set; }
        /// <summary>
        /// Marca do produto
        /// </summary> 
        public string Brand { get; set; }
        /// <summary>
        /// Modelo do Produto
        /// </summary> 
        public string Model { get; set; }
        /// <summary>
        /// Preço de custo do produto
        /// </summary> 
        public decimal  CostPrice { get; set; }
        /// <summary>
        /// Preco de venda do produto
        /// </summary> 
        public decimal SalePrice { get; set; }

    }
}
